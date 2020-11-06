using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EquationDraw.GrammarParser;

namespace EquationDraw
{
    public class TreeVisitor : GrammarBaseVisitor<Expression>
    {
        /// <summary>
        /// a boolean value that indicates whether to optimise the <see cref="Expression"/> tree that would be returned
        /// from the Visiting function
        /// </summary>
        public bool OptimiseExpressionWhenVisiting { get; set; }

        /// <summary>
        /// Decides whether to optimise the expression or not
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private Expression HandleOptimisation(Expression exp)
            => OptimiseExpressionWhenVisiting ? exp.Optimise() : exp;

        public Expression VisitExpression([NotNull] ExpressionContext context, Expression parent = null)
        {
            Expression res;

            // if it's a number
            if (context.number != null)
            {
                // get the number
                var n = VisitAtom(context.number, parent) as NumExpression;

                // multiply by the sign
                n.Value *= SignRecogniser(context.sign.GetText());

                // return the number
                res = n;
            }
            else
            // if it's a function ...
            if (context.fParam1 != null)
            {
                // get function name
                var fName = context.funcName?.GetText() ?? "";

                // create an empty list of expressions to hold function params
                var fParams = new List<Expression>();

                // add the first param of the function
                fParams.Add(VisitExpression(context.fParam1));

                // other params of the functions (set parent to null, ctor of the FuncExpression will handle it)
                var otherParams = (context.fOtherParams?.children as List<IParseTree>)?
                    .Select(o => VisitMultExprPart(o as MultExprPartContext, null));

                // add other params
                if (otherParams != null)
                    fParams.AddRange(otherParams);

                // return a new function
                res = new FuncExpression(fName, fParams);
            }
            else
            // if it's a binary operation ...
            if (context.op != null)
            {
                // get left, right sides
                var left = VisitExpression(context.left);
                var right = VisitExpression(context.right);

                // get operator
                var op = context.op.Text;

                // return a new binary operation expression (parent is set throught Ctor of BinaryOp)
                res = new BinaryOperationExpression(left, right, Extensions.ParseBinaryOperationType(op));
            }
            else
                // if none of the above recognizes the context then return an unknown expression object
                res = new UnknownExpression();

            // return the expression with Optimisation handled & parent set
            return HandleOptimisation(res?.SetParent(parent));
        }

        public Expression VisitAtom(AtomContext context, Expression parent = null)
            // return a NumExpression with the text parsed to a double
            => HandleOptimisation(new NumExpression(double.Parse(context.GetText())).SetParent(parent));

        public Expression VisitMultExprPart([NotNull] MultExprPartContext context, Expression parent = null)
            => HandleOptimisation(VisitExpression(context.expr).SetParent(parent));

        public Expression VisitRoot([NotNull] RootContext context, Expression parent = null)
            => HandleOptimisation(VisitExpression(context.expression()).SetParent(parent));

        private static int SignRecogniser(string sign)
            => sign.Count(c => c == BinaryOperationType.Sub.GetStringOperatorSymbol().First()) % 2 == 0 ? 1 : -1;

    }
}
