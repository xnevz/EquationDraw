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

            // setting the parent of the left & right expressions
            Left.Parent = Right.Parent = this;
        }

        public override Number GetUI()
            => BaseBinaryOperation.ConstructBinaryOperation(Type, Left.GetUI(), Right.GetUI());

        public override Expression Optimise()
        {
            // optimise left & right
            Right = Right.Optimise();
            Left = Left.Optimise();

            return this;
        }
    }
}
