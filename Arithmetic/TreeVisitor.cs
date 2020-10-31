using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    public class TreeVisitor : GrammarBaseVisitor<Expression>
    {

        public override Expression VisitExpression([NotNull] GrammarParser.ExpressionContext context)
        {
            // if it's a number
            if (context.number != null)
            {
                // get the number
                var n = (NumExpression)Visit(context.number);

                // multiply by the sign
                n.Value *= SignRecogniser(context.sign.GetText());

                // return the number
                return n;
            }

            // if it's a function ...
            if (context.fParam1 != null)
            {
                // get function name
                var fName = context.funcName?.GetText() ?? "";

                // create an empty list
                List<Expression> expressions = new List<Expression>();

                // add params
                expressions.Add(Visit(context.fParam1));
                expressions.AddRange((ExpressionTuple)Visit(context.fOtherParams));

                // return a new function
                return new FunctionExpression(fName, expressions);
            }

            // if it's a binary operation ...
            if (context.op != null)
            {
                // get left, right sides
                var left = Visit(context.left);
                var right = Visit(context.right);

                // get operator
                var op = context.op.Text;

                // return a new binary operation expression
                return new BinaryOperationExpression(left, right, Extensions.ParseBinaryOperationType(op));
            }

            // if none of the above recognizes the context then return an unknown expression object
            return new UnknownExpression();
        }

        private static int SignRecogniser(string sign)
            => sign.Count(c => c == '-') % 2 == 0 ? 1 : -1;


        public override Expression VisitAtom([NotNull] GrammarParser.AtomContext context)
        {
            // return a NumExpression with the text parsed to a double
            return new NumExpression(double.Parse(context.GetText()));
        }

        public override Expression VisitMultExpression([NotNull] GrammarParser.MultExpressionContext context)
        {
            // create a new empty list
            List<Expression> exprs = new List<Expression>();

            // if there are children add them to the list
            if (context.children != null)
                foreach (var ch in context.children)
                    exprs.Add(Visit(ch));

            // return the list a tuple
            return new ExpressionTuple(exprs);
        }

        public override Expression VisitMultExprPart([NotNull] GrammarParser.MultExprPartContext context)
        {
            return Visit(context.expr);
        }

        public override Expression VisitRoot([NotNull] GrammarParser.RootContext context)
        {
            return Visit(context.expression());
        }
    }
}
