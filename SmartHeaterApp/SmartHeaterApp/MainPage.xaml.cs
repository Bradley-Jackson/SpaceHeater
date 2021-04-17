using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHeaterApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            if(EntryEmail.Text == "a" && EntryPassword.Text == "a")
            {
                try
                {
                    FlyoutPage flyoutPage = new MainNavigationPage();
                    Application.Current.MainPage = flyoutPage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Failed Login, try email: a, password: a");
                WebRequest request = WebRequest.Create(
              "http://65.189.242.145:8081/index.html");
                // If required by the server, set the credentials.
                //request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Console.WriteLine(responseFromServer);
                }

                // Close the response.
                response.Close();

            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Register");
        }
    }
}
