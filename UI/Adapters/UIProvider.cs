using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationDraw
{
    public class UIProvider : IUIProvider
    {
        public BaseBinaryOperation ConstructBinaryOperation(BinaryOperationType type, Number left, Number right)
        {
            // init a new binaryOP
            BaseBinaryOperation op = null;

            // switch type
            switch (type)
            {
                case BinaryOperationType.Div:
                    return new DivisionOperation(left, right);
                case BinaryOperationType.Pow:
                    op = new PowerOperation();
                    break;
                case BinaryOperationType.Mult:
                case BinaryOperationType.Add:
                case BinaryOperationType.Sub:
                    op = new BinaryOperation
                    {
                        /* get separator from type */
                        Separator = type.GetOperatorSymbol()
                    };
                    break;
                default:
                    return null;
            }

            op.Left = left;
            op.Right = right;

            return op;
        }
    }
}
