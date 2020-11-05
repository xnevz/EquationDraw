using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquationDraw
{
    public class BaseBinaryOperation : Number
    {
        public static readonly DependencyProperty LeftProperty =
            DependencyProperty.Register("Left", typeof(Number), typeof(BaseBinaryOperation), new PropertyMetadata(null));
        public static readonly DependencyProperty RightProperty =
            DependencyProperty.Register("Right", typeof(Number), typeof(BaseBinaryOperation), new PropertyMetadata(null));
        public static readonly DependencyProperty SeparatorProperty =
            DependencyProperty.Register("Separator", typeof(object), typeof(BinaryOperation), new PropertyMetadata(null));

        public Number Left
        {
            get { return (Number)GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }

        public Number Right
        {
            get { return (Number)GetValue(RightProperty); }
            set { SetValue(RightProperty, value); }
        }

        public object Separator
        {
            get { return GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }


        public static BaseBinaryOperation ConstructBinaryOperation(BinaryOperationType type, Number left, Number right)
        {
            // init a new binaryOP
            BaseBinaryOperation op = null;

            // switch type
            switch (type)
            {
                case BinaryOperationType.Div:
                    op = new DivisionOperation();
                    break;
                case BinaryOperationType.Pow:
                case BinaryOperationType.Mult:
                case BinaryOperationType.FloorDiv:
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
