using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EquationDraw
{
    /// <summary>
    /// Interaction logic for VariableOperation.xaml
    /// </summary>
    public partial class VariableOperation : Number
    {
        #region DP

        public string VarName
        {
            get { return (string)GetValue(VarNameProperty); }
            set { SetValue(VarNameProperty, value); }
        }

        public static readonly DependencyProperty VarNameProperty =
            DependencyProperty.Register("VarName", typeof(string), typeof(VariableOperation), new PropertyMetadata("x"));

        #endregion

        public VariableOperation()
        {
            InitializeComponent();
        }
    }
}
