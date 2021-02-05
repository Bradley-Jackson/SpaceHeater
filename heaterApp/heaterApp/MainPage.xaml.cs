using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace heaterApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnWifiSubmitButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("submitted wifi creds");
            try
            {
                //await Navigation.PushAsync(new NavigationPage(new SystemInfo()));
                //if successful, notify user and direct to temperature setting page
                //else tell user it was unsuccessful
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
