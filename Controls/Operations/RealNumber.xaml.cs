using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace EquationDraw
{
    /// <summary>
    /// Interaction logic for RealNumber.xaml
    /// </summary>
   [ContentProperty(nameof(Value))]
    public partial class RealNumber : Number
    {

        #region Dependency Properties

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(RealNumber), new PropertyMetadata(0d));

        #endregion

        public RealNumber()
        {
            InitializeComponent();
        }
    }
}
