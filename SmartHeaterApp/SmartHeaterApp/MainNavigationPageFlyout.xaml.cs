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
        public ListView ListView;

        public MainNavigationPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainNavigationPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainNavigationPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainNavigationPageFlyoutMenuItem> MenuItems { get; set; }

            public MainNavigationPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainNavigationPageFlyoutMenuItem>(new[]
                {
                    new MainNavigationPageFlyoutMenuItem { Id = 0, Title = "System Info" },
                    new MainNavigationPageFlyoutMenuItem { Id = 1, Title = "Sheduled Heating" },
                    new MainNavigationPageFlyoutMenuItem { Id = 2, Title = "Temperature Settings" },
                    new MainNavigationPageFlyoutMenuItem { Id = 3, Title = "Logout" },
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