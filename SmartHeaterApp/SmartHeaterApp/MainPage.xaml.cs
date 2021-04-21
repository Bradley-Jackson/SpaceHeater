using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Renci.SshNet;
using System.IO;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;

namespace SmartHeaterApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FlyoutPage flyoutPage = new MainNavigationPage(true);
            Application.Current.MainPage = flyoutPage;
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //if(EntryEmail.Text == "" && EntryPassword.Text == "")
            //{
                try
                {
                //FlyoutPage flyoutPage = new MainNavigationPage();
                //Application.Current.MainPage = flyoutPage;

                //var client = new SshClient("65.189.242.145", 2222, "pi", "raspberry");
                //client.Connect();
                //client.RunCommand("touch /home/pi/Documents/button");
                //client.Disconnect();

                WebRequest request = WebRequest.Create("http://65.189.242.145:8081/getSystemInfo.php");
                // If required by the server, set the credentials.
                //request.Credentials = CredentialCache.DefaultCredentials;

                
                // Get the response.
                WebResponse response = request.GetResponse();

                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                SystemInfo systemInfo = JsonConvert.DeserializeObject<SystemInfo>(responseFromServer);
                
                // Close the response.
                response.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            //}
            //else
            //{
            //    Console.WriteLine("Failed Login, try email: a, password: a");
            //}
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Register");
        }
    }
}
