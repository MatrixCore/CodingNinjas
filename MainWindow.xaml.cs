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

namespace MeansTest
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
            double Ssalary = Convert.ToDouble(textBox.Text);
            if (Ssalary >0)
            {
                textBox19_Copy1.Text = Convert.ToString(7000);
            }
            double Sallowance = Convert.ToDouble(textBox5.Text);
            double Ssubsidy = Convert.ToDouble(textBox1.Text);
            double Sinterest = Convert.ToDouble(textBox3.Text);
            double Srental = Convert.ToDouble(textBox2.Text);
            double Smaintenance = Convert.ToDouble(textBox6.Text);
            double Sincome = Convert.ToDouble(textBox4.Text);

            double Sgrossincome = Ssalary + Sallowance + Ssubsidy + Sinterest + Srental + Smaintenance + Sincome;

            double Psalary = Convert.ToDouble(textBox8.Text);
            if (Ssalary > 0 && Psalary>0)
            {
                textBox19_Copy1.Text = Convert.ToString(7500);
            }
            double Rebate = Convert.ToDouble(textBox19_Copy1.Text);
            double Pallowance = Convert.ToDouble(textBox9.Text);
            double Psubsidy = Convert.ToDouble(textBox10.Text);
            double Pinterest = Convert.ToDouble(textBox11.Text);
            double Prental = Convert.ToDouble(textBox12.Text);
            double Pmaintenance = Convert.ToDouble(textBox13.Text);
            double Pincome = Convert.ToDouble(textBox14.Text);

            double Pgrossincome = Psalary + Pallowance + Psubsidy + Pinterest + Prental + Pmaintenance + Pincome;

            double Totgrossincome = Sgrossincome + Pgrossincome;

            double Sdeduction = Convert.ToDouble(textBox17.Text);
            double Pdeduction = Convert.ToDouble(textBox18.Text);

            double Totdeduction = Sdeduction + Pdeduction;

            double Total = Totgrossincome - Totdeduction;
           
            double Balance = Total - Rebate;

            textBox7.Text = Convert.ToString(Sgrossincome);
            textBox15.Text = Convert.ToString(Pgrossincome);
            textBox17.Text = Convert.ToString(Sdeduction);
            textBox18.Text = Convert.ToString(Pdeduction);
            textBox16.Text = Convert.ToString(Totgrossincome);
            textBox19.Text = Convert.ToString(Totdeduction);
            textBox19_Copy.Text = Convert.ToString(Total);
            textBox19_Copy2.Text = Convert.ToString(Balance);

            double Sfixproperty = Convert.ToDouble(textBox20.Text);
            double Sbonds = Convert.ToDouble(textBox20_Copy.Text);
            double Ssavings = Convert.ToDouble(textBox20_Copy2.Text);
            double Smonies = Convert.ToDouble(textBox20_Copy3.Text);

            double Ssubtotal = Sfixproperty - Sbonds;
            double Snetvalue = Ssubtotal + Ssavings + Smonies;

            double Pfixproperty = Convert.ToDouble(textBox20_Copy8.Text);
            double Pbonds = Convert.ToDouble(textBox20_Copy7.Text);
            double Psavings = Convert.ToDouble(textBox20_Copy5.Text);
            double Pmonies = Convert.ToDouble(textBox20_Copy4.Text);

            double Psubtotal = Pfixproperty - Pbonds;
            double Pnetvalue = Psubtotal + Psavings + Pmonies;

            double Totnetvalue = Snetvalue + Pnetvalue;

            if (Sfixproperty > 0 || Pfixproperty > 0)
            {
                textBox23.Text = Convert.ToString(500000);
            }

            double Propdiscount = Convert.ToDouble(textBox23.Text);

            double BalanceAssets = Totnetvalue - Propdiscount;

            textBox20_Copy1.Text = Convert.ToString(Ssubtotal);
            textBox20_Copy6.Text = Convert.ToString(Psubtotal);
            textBox21.Text = Convert.ToString(Snetvalue);
            textBox21_Copy.Text = Convert.ToString(Pnetvalue);
            textBox22.Text = Convert.ToString(Totnetvalue);
            textBox24.Text = Convert.ToString(BalanceAssets);

            //If the balance of a client's income and assets are positive, then they do not qualify for aid
            if (Balance <= 0 && BalanceAssets <= 0)
            {
                MessageBox.Show("Client qualifies for financial aid");
                qualifyBox.Clear();
                qualifyBox.Text = "Client Qualifies";

            }
            else
            {
                MessageBox.Show("Client does not qualifies for financial aid");
                qualifyBox.Clear();
                qualifyBox.Text = "Client does not Qualify";
            }
        }

        private void Appointment_Click(object sender, RoutedEventArgs e)
        {
            /*
            We will need to design a way to manage and add appointments
            This button should only be enabled if the means test as already been completed
            */
            Appointments temp = new Appointments();
            temp.Owner = this;
            temp.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog().GetValueOrDefault(false))
            {
                printDialog.PrintVisual(toPrint, "test");
            }
        }
    }

}