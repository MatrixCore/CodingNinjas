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
using System.Windows.Shapes;
using System.IO;

namespace MeansTest
{
    /// <summary>
    /// Interaction logic for InitalCapture.xaml
    /// </summary>
    public partial class InitialCapture : Window
    {
        List<Client> ClientList;
        public InitialCapture()
        {
            InitializeComponent();
            ClientList = new List<Client>();
            if (!File.Exists("Clients"))
            {
                File.CreateText("Clients");
            }
            else
            {
                Load();
            }
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
            if (Verify())
            {
                Save();
                if (EmployNo.IsChecked == true && IncomeNo.IsChecked == true && AssetNo.IsChecked == true)
                {
                    MessageBox.Show("Information Captured. Client Qualifies for Legal Aid", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                    Appointments temp = new Appointments();
                    temp.Owner = this;
                    temp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Infomation Captured", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Continue on to the means test from here
                    MainWindow temp = new MainWindow();
                    temp.Owner = this;
                    temp.Show();
                    this.Hide();
                    //Hides current window and shows the Means Test Windows
                }
            }
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter("Clients.txt", true);
            bool Checkes; //Records the answer the client gives for the questions 
            string check;
            if (EmployNo.IsChecked == true && IncomeNo.IsChecked == true && AssetNo.IsChecked == true)
            {
                Checkes = true;
                check = "Yes";
            }
            else
            {
                Checkes = false;
                check = "No";
            }
            write.WriteLine($"{SurnameBox.Text},{nameBox.Text},{idBox.Text},{dayBox.Text},{monthBox.Text},{yearBox.Text},{check}");
            Client temp = new Client(nameBox.Text, SurnameBox.Text, idBox.Text, dayBox.Text, monthBox.Text, yearBox.Text, Checkes);
            ClientList.Add(temp);
            write.Close();
        }

        public void Load()
        {
            StreamReader read = new StreamReader("Clients.txt");
            while (!read.EndOfStream)
            {
                string[] lines = read.ReadLine().Split(',');
                Client temp = new Client(lines[1], lines[0], lines[2], lines[3], lines[4], lines[5], (lines[6] == "Yes"));
                ClientList.Add(temp);
            }

            read.Close();
        }

        public bool Verify()
        {
            try
            {
                if (nameBox.Text == "" || (SurnameBox.Text == "") || idBox.Text == "" || dayBox.Text == "" || monthBox.Text == "" || yearBox.Text == "")
                {
                    throw new ApplicationException("A field is missing text");
                }
                if ((Convert.ToInt32(dayBox.Text) > 31 || Convert.ToInt32(dayBox.Text) < 0))
                {
                    throw new ApplicationException("Birth day is invalid");
                }
                if ((Convert.ToInt32(monthBox.Text) > 12 || Convert.ToInt32(monthBox.Text) < 0))
                {
                    throw new ApplicationException("Birth month is invalid");
                }
                if (idBox.Text.Length != 13)
                {
                    throw new ApplicationException("ID Number is invalid");
                }
                if (yearBox.Text.Length != 4)
                {
                    throw new ApplicationException("Year must be four digits long");
                }
                if (idBox.Text.Substring(0, 2) != yearBox.Text.Substring(2, 2))
                {
                    throw new ApplicationException("Birth year does not match ID Number");
                }
                if (idBox.Text.Substring(2, 2) != monthBox.Text)
                {
                    throw new ApplicationException("Birth month does not match ID number");
                }
                if (idBox.Text.Substring(4, 2) != dayBox.Text)
                {
                    throw new ApplicationException("Birth day does not match ID number");
                }
                if (IncomeYes.IsChecked == false && IncomeNo.IsChecked == false)
                {
                    throw new ApplicationException("Only tick one option per question");
                }
                if (EmployYes.IsChecked == false && EmployNo.IsChecked == false)
                {
                    throw new ApplicationException("Only tick one option per question");
                }
                if (AssetNo.IsChecked == false && AssetYes.IsChecked == false)
                {
                    throw new ApplicationException("Only tick one option per question");
                }
                return true;
            }
            catch (ApplicationException AppEx)
            {
                MessageBox.Show(AppEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
