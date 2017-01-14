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

namespace MDFast.Views
{
    /// <summary>
    /// Interação lógica para ErrorControl.xam
    /// </summary>
    public partial class ErrorControl : UserControl
    {
        public ErrorControl()
        {
            InitializeComponent();
        }

        public string ErrMessage
        {
            get { return (string)GetValue(ErrMessageProperty); }
            set { SetValue(ErrMessageProperty, value); }
        }

        public static DependencyProperty ErrMessageProperty =
           DependencyProperty.Register("ErrMessage", typeof(string), typeof(UserControl));

    }
}
