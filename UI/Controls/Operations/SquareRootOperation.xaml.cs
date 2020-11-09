using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace EquationDraw
{
    /// <summary>
    /// Interaction logic for SquareRootOperation.xaml
    /// </summary>
    [ContentProperty(nameof(Child))]
    public partial class SquareRootOperation : UnaryOperation
    {
        #region Dependency Properties

        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(SquareRootOperation), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        #endregion Dependency Properties

        public SquareRootOperation()
        {
            InitializeComponent();
        }
    }
}