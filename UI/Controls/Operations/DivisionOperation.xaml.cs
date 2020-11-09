using System;
using System.Windows;
using System.Windows.Controls;

namespace EquationDraw
{
    /// <summary>
    /// Interaction logic for DivisionOperation.xaml
    /// </summary>
    public partial class DivisionOperation : BaseBinaryOperation
    {
        public DivisionOperation()
        {
            InitializeComponent();
        }

        public DivisionOperation(Number left, Number right)
        {
            Left = left;
            Right = right;

            InitializeComponent();
        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            var max = Math.Max(top.ActualHeight, bottom.ActualHeight);
            top.Height = bottom.Height = max;

        }
    }
}