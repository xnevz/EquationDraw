using System.Windows;
using System.Windows.Controls;

namespace EquationDraw
{
    /// <summary>
    /// Interaction logic for DivisionOperation.xaml
    /// </summary>
    public partial class DivisionOperation : Number
    {
        #region Dependency Properties

        public Number Top
        {
            get { return (Number)GetValue(TopProperty); }
            set { SetValue(TopProperty, value); }
        }

        public static readonly DependencyProperty TopProperty =
            DependencyProperty.Register("Top", typeof(Number), typeof(DivisionOperation), new PropertyMetadata(null));

        public Number Bottom
        {
            get { return (Number)GetValue(BottomProperty); }
            set { SetValue(BottomProperty, value); }
        }

        public static readonly DependencyProperty BottomProperty =
            DependencyProperty.Register("Bottom", typeof(Number), typeof(DivisionOperation), new PropertyMetadata(null));

        #endregion Dependency Properties

        public DivisionOperation()
        {
            InitializeComponent();
        }
    }
}