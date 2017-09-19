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

namespace GUI
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

        private void Capture_Click(object sender, RoutedEventArgs e)
        {
            /*
            Begins the initial capture of a clients infomation

            Checks will need to be made such as if the ID number provided is valid and matches the date of birth
            Another important check to consider is if the client is already present in the Clinic's database meaning it is a return visit
            Consider making these checks as methods rather than coding within the buttonClick event

            Based on the client's answers to the three questions, they will continue on to the means test and the active window should switch
            the means test's GUI
            If they answer no to the first three questions then there is no need to continue and complete the means test

            Here is where the client's inital info will be added to our text file storage
            */
        }
    }
}
