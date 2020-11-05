using System.Windows;
using System.Windows.Controls;

namespace EquationDraw
{
    public class PlusOperation : BinaryOperation
    {
        public PlusOperation()
        {
            Separator = BinaryOperationType.Add.GetOperatorSymbol();
        }
    }
    public class MinusOperation : BinaryOperation
    {
        public MinusOperation()
        {
            Separator = BinaryOperationType.Sub.GetOperatorSymbol();

        }
    }
    public class MultiplicationOperation : BinaryOperation
    {
        public MultiplicationOperation()
        {
            Separator = BinaryOperationType.Mult.GetOperatorSymbol();
        }
    }

    public class UnaryOperation : Number
    {

        public Number Child
        {
            get { return (Number)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }

        public static readonly DependencyProperty ChildProperty =
            DependencyProperty.Register("Child", typeof(Number), typeof(UnaryOperation), new PropertyMetadata(null));

    }

}
