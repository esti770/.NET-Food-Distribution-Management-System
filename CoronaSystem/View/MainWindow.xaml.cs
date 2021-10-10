﻿using CoronaSystem.ViewModel;
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

namespace CoronaSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindowVM mainWindowVM;
        public MainWindow()
        {
            InitializeComponent();
            mainWindowVM = new MainWindowVM();
            this.DataContext = mainWindowVM;
        }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
