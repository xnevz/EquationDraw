using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    public class BinaryOperationExpression : Expression
    {
        /// <summary>
        /// Left side of the operation
        /// </summary>
        public Expression Left { get; set; }

        /// <summary>
        /// Right Side of the operation
        /// </summary>
        public Expression Right { get; set; }

        /// <summary>
        /// type of operation
        /// </summary>
        public BinaryOperationType Type { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public BinaryOperationExpression(Expression left, Expression right, BinaryOperationType type)
        {
            Left = left;
            Right = right;
            Type = type;
        }

        public override Number GetUI()
        {
            switch (Type)
            {
                case BinaryOperationType.Div:
                    return new DivisionOperation
                    {
                        Top = Left.GetUI(),
                        Bottom = Right.GetUI()
                    };
                default:

                    var op = new GroupOperation()
                    {
                        Separator = Type.GetOperatorSymbol()
                    };

                    op.Operators.Add(Left.GetUI());
                    op.Operators.Add(Right.GetUI());

                    return op;
            }
        }


    }
}
