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

namespace GUI2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EvaluateMeans_Click(object sender, RoutedEventArgs e)
        {
            /* 
            Based on the figures entered, it can be determined whether or not the client in question qualifies for aid
            One of three outcomes then may be dediced upon by the client
            1. Client Qualifies and books appointment
            2. Client doesn’t qualify but requires advice
            3. Client doesn't qualify but doesn’t want advice
            */
        }

        private void Appointment_Click(object sender, RoutedEventArgs e)
        {
            /*
            We will need to design a way to manage and add appointments
            This button should only be enabled if the means test as already been completed
            */
        }

        private void Meeting_Click(object sender, RoutedEventArgs e)
        {
            /*
            Same as the Appointment Button
            What's the difference between a meeting and an appointment
            */
        }
    }

}