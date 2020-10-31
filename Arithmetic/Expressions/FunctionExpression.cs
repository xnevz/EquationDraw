using System.Collections.Generic;
using System.Linq;

namespace EquationDraw
{
    public class FunctionExpression : Expression
    {
        /// <summary>
        /// List of arguments of the function
        /// </summary>
        public List<Expression> Arguments { get; set; }

        /// <summary>
        /// Function's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FunctionExpression(string name, List<Expression> arguments)
        {
            Arguments = arguments;
            Name = name;
        }

        public override Number GetUI()
        {
            if (Name is null || Name == "")
            {
                var op = new GroupOperation
                {
                    Separator = ""
                };

                Arguments.Select(arg => arg.GetUI()).ForEach(arg => op.Operators.Add(arg));

                return op;
            }
            else if (Name == "sqrt")
                return new SquareRootOperation
                {
                    Child = Arguments[0].GetUI()
                };

            return null;
        }
    }
}
