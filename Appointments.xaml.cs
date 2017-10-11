using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
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
using System.Threading;
using System.IO;
using Google.Apis.Http;

namespace MeansTest
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        List<Client> ClientList;
        public Appointments()
        {
            InitializeComponent();
            ClientList = new List<Client>();
            Load();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = System.IO.Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 40;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            if (Picky.SelectedDate == null)
            {
                request.TimeMin = DateTime.Now;
            }
            else
            {
                request.TimeMin = Picky.SelectedDate;
                request.TimeMax = Picky.SelectedDate + new TimeSpan(1, 0, 0, 0);
            }

            

            // List events.
            textBox.Clear();
            Events events = request.Execute();

            if (events.Items != null && events.Items.Count > 0)
            {
                textBox.Text = "Existing Appointments: \n";
                foreach (var eventItem in events.Items)
                {
                    DateTime testing;
                    if (eventItem.Start.DateTime.HasValue)
                    {
                        testing = eventItem.Start.DateTime.Value;
                        string when = testing.ToString("g");
                        if (String.IsNullOrEmpty(when))
                        {
                            when = eventItem.Start.Date.ToString();
                        }
                        textBox.AppendText(when + ": " + eventItem.Summary + "\n");
                    }
                }
            }
            else
            {
                textBox.Text = "No Existing Appointments";
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            {
                // Necessary code for api 
                UserCredential credential;
                using (var stream =
                    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = System.IO.Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;

                }

                // Create Google Calendar API service.
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                //Code for creating a new Google Calendar event

                EventsResource.ListRequest request = service.Events.List("primary");
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 1;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
                request.TimeMin = selectDateTime.Value - new TimeSpan(0, 0, 0, 59);
                request.TimeMax = selectDateTime.Value + new TimeSpan(0, 0, 0, 59);
                Events events = request.Execute();

                if (events.Items.Count == 0)
                {
                    Event myEvent = new Event
                    {
                        Summary = "First Consultation - " + ClientBox.SelectedItem,
                        Location = "41 New Street, Grahamstown",
                        Description = practitionerNotes.Text,
                        Start = new EventDateTime()
                        {
                            DateTime = selectDateTime.Value,
                        },
                        End = new EventDateTime()
                        {
                            DateTime = selectDateTime.Value + new TimeSpan(0, 1, 0, 0),
                        }
                    };
                    if (Verify())
                    {
                        Event recurringEvent = service.Events.Insert(myEvent, "primary").Execute();
                        MessageBox.Show("Appointment Captured!");
                    }
                }

                else
                {
                    MessageBox.Show("There is already an appointment!");
                }

                

            }
        }
        //Load captured clients and display them in a lisbox 
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
            ClientList.Sort((x, y) => x.Surname.CompareTo(y.Surname));
            foreach (Client item in ClientList)
            {
                ClientBox.Items.Add(item.ToString());
            }
        }



        // Catch exceptions when necessary information is left blank
        public bool Verify()
        {
            try
            {
                if (selectDateTime.Text == null)
                {
                    throw new ApplicationException("Choose a date and time");
                }
                if (ClientBox.SelectedItem == null)
                {
                    throw new ApplicationException("Select a client");
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
