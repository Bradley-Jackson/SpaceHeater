using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Register");
        }
    }
}
