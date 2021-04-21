using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHeaterApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNavigationPageFlyout : ContentPage
    {
        public bool displayFarenheit = true;
        public ListView ListView;

        public MainNavigationPageFlyout()
        {
            InitializeComponent();
            SetTopBarText();

            BindingContext = new MainNavigationPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        public void SetDisplayFarenHeit(bool isFarenheit)
        {
            displayFarenheit = isFarenheit;
        }

        public void SetTopBarText()
        {
            if (displayFarenheit)
            {
                TopBar.Text = "Displaying temps in Farenheit";
            }
            else
            {
                TopBar.Text = "Displaying temps in Celcius";
            }
        }

        class MainNavigationPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainNavigationPageFlyoutMenuItem> MenuItems { get; set; }

            public MainNavigationPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainNavigationPageFlyoutMenuItem>(new[]
                {
                    new MainNavigationPageFlyoutMenuItem { Id = 0, Title = "Change Temp Display" },
                    new MainNavigationPageFlyoutMenuItem { Id = 1, Title = "System Info" },
                    new MainNavigationPageFlyoutMenuItem { Id = 2, Title = "Sheduled Heating" },
                    new MainNavigationPageFlyoutMenuItem { Id = 3, Title = "Temperature Settings" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}