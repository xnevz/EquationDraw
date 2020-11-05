﻿using System;
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
    /// Interaction logic for ParenthesisOperation.xaml
    /// </summary>
    public partial class FunctionOperation
    {
        #region DP

        /// <summary>
        /// name of the function
        /// </summary>
        public string FuncName
        {
            get { return (string)GetValue(FuncNameProperty); }
            set { SetValue(FuncNameProperty, value); }
        }

        public static readonly DependencyProperty FuncNameProperty =
            DependencyProperty.Register("FuncName", typeof(string), typeof(FunctionOperation), new PropertyMetadata(""));

        #endregion

        public FunctionOperation()
        {
            InitializeComponent();
        }
    }
}
