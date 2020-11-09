using System.Windows;
using System.Windows.Controls;

namespace EquationDraw
{
    /// <summary>
    /// the base class for all kinds of numbers
    /// </summary>
    public class Number : UserControl
    {
        public bool IsFirst
        {
            get { return (bool)GetValue(IsFirstProperty); }
            set { SetValue(IsFirstProperty, value); }
        }

        public static readonly DependencyProperty IsFirstProperty =
            DependencyProperty.Register("IsFirst", typeof(bool), typeof(Number), new PropertyMetadata(false));
    }
}