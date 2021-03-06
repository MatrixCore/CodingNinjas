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
using System.Windows.Shapes;

namespace MeansTest
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void ExistClient_Click(object sender, RoutedEventArgs e)
        {
            //Direct to Appointments window
            Appointments temp = new Appointments();
            temp.Owner = this;
            temp.Show();
            this.Hide();
        }

        private void NewClient_Click(object sender, RoutedEventArgs e)
        {
            //Direct to Initial Capture Window
            InitialCapture temp = new InitialCapture();
            temp.Owner = this;
            temp.Show();
            this.Hide();
        }
    }
}
