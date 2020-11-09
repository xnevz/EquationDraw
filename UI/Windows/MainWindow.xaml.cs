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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IStartupWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowWindow()
        {
            Show();
        }


        private void tBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tree = TreeGenerator.GenerateTree(tBox.Text.Trim(), true);
            if (!(tree is null))
            {
                container.Children.Clear();
                container.Children.Add(tree.GetUI());
            }
        }
        
    }
}
