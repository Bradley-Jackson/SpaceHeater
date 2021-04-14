using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHeaterApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNavigationPage : FlyoutPage
    {
        public MainNavigationPage()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainNavigationPageFlyoutMenuItem;
            if (item == null)
                return;

            switch(item.Id)
            {
                case 0:                             
                    Detail = new NavigationPage(new SystemInfo());
                    break;
                case 1:
                    Detail = new NavigationPage(new ScheduledHeating());
                    break;
                case 2:
                    Detail = new NavigationPage(new TemperatureSettings());
                    break;
                case 3:             //Logout
                    Detail = new MainPage();
                    break;
                default:
                    Console.WriteLine("Unexpected Flyout Page Submission");
                    break;
            }
            IsPresented = false;
            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}