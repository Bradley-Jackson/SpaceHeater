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
        public bool displayFarenheit = true;

        public int currentPage = 1;
        public MainNavigationPage(bool isFarenheit)
        {
            InitializeComponent();
            displayFarenheit = isFarenheit;
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainNavigationPageFlyoutMenuItem;

            if (item == null)
            {
                return;
            }

            DetailSwitch(item.Id);

            if(item.Id != 0)
            {
                IsPresented = false;
            }

            FlyoutPage.ListView.SelectedItem = null;
        }

        private void DetailSwitch(int itemID)
        {
            switch (itemID)
            {
                case 0:
                    displayFarenheit = !displayFarenheit;
                    FlyoutPage.SetDisplayFarenHeit(displayFarenheit);
                    FlyoutPage.SetTopBarText();
                    DetailSwitch(currentPage);
                    break;
                case 1:
                    Detail = new NavigationPage(new SystemInfo(displayFarenheit));
                    currentPage = 1;
                    break;
                case 2:
                    Detail = new NavigationPage(new ScheduledHeating(displayFarenheit));
                    currentPage = 2;
                    break;
                case 3:
                    Detail = new NavigationPage(new TemperatureSettings(displayFarenheit));
                    currentPage = 3;
                    break;
                default:
                    Console.WriteLine("Unexpected Flyout Page Submission");
                    break;
            }
        }
    }
}