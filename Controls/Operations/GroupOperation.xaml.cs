using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquationDraw
{
    /// <summary>
    /// Interaction logic for PlusOperation.xaml
    /// </summary>
    [ContentProperty(nameof(Operators))]
    public partial class GroupOperation : Number
    {

        #region Dependency Properties

        public ObservableCollection<Number> Operators
        {
            get { return (ObservableCollection<Number>)GetValue(OperatorsProperty); }
            set { SetValue(OperatorsProperty, value); }
        }

        public static readonly DependencyProperty OperatorsProperty =
            DependencyProperty.Register("Operators", typeof(ObservableCollection<Number>), typeof(GroupOperation), new PropertyMetadata(null, OperatorsPropertyChanged));

        public string Separator
        {
            get { return (string)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        public static readonly DependencyProperty SeparatorProperty =
            DependencyProperty.Register("Separator", typeof(string), typeof(GroupOperation), new PropertyMetadata(" N "));

        #endregion

        private static void OperatorsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is ObservableCollection<Number> coll)
            {
                setIsFirstToFirst(coll);
                coll.CollectionChanged += (s, ev) => setIsFirstToFirst(coll);
            }
        }

        private static void setIsFirstToFirst(ObservableCollection<Number> coll)
        {
            if (coll.Count > 0 && coll[0] != null)
                coll[0].IsFirst = true;

            for (int i = 1; i < coll.Count; i++)
                coll[i].IsFirst = false;
        }

        public GroupOperation()
        {
            Operators = new ObservableCollection<Number>();
            InitializeComponent();
        }
    }
}
