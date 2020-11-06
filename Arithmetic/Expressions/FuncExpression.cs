using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace EquationDraw
{
    public class FuncExpression : Expression
    {
        /// <summary>
        /// List of parameters of the function
        /// </summary>
        public List<Expression> Params { get; set; }

        /// <summary>
        /// Function's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FuncExpression(string name, List<Expression> arguments)
        {
            Params = arguments;
            Name = name;

            // setting parent of the params
            Params?.ForEach(p => p.SetParent(this));
        }

        public override Number GetUI()
        {
            if (Name is null || Name == "")
            {
                var op = new FunctionOperation
                {
                    FuncName = "",
                    Child = Params[0].GetUI()
                };

                return op;
            }
            else if (Name == "sqrt")
                return new SquareRootOperation
                {
                    Child = Params[0].GetUI()
                };

            return null;
        }

        public override Expression Optimise()
        {

            // if it's parenthesis ...
            if (IsOrdinaryParenthesis())
            {
                // optimise it's content
                var content = Params[0] = Params[0].Optimise();

                // if it's content is a number ...
                if (content is NumExpression)
                    // return that number
                    return Params[0];

                // if it's content is a binary expression & it's parent is also a binary expression
                // and they(parent + child) have the same type then we can remove these parenthesis by returning
                // the content itself
                else if (content is BinaryOperationExpression childBinaryExp &&
                    Parent is BinaryOperationExpression parentBinaryExp &&
                    childBinaryExp.Type.CanRemoveParenthesisdWhenPreceededWith(parentBinaryExp.Type))
                    return content;
            }

            // optimise all params
            for (int i = 0; i < Params.Count; i++)
                Params[i] = Params[i].Optimise();

            // return self
            return this;
        }

        /// <summary>
        /// Checks whether this FuncExpression is an ordinary parenthesis expression
        /// </summary>
        /// <returns></returns>
        public bool IsOrdinaryParenthesis() => Name == "" && Params?.Count == 1;
    }
}
