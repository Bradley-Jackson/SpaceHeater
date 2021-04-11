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
    public partial class TemperatureSettings : ContentPage
    {
        Label temperatureScaleLabel = new Label();
        public TemperatureSettings()
        {
            InitializeComponent();

            temperatureScaleLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: TemperatureScalePicker));
        }
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                temperatureScaleLabel.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }

        void SetTemperature(object sender, EventArgs e)
        {
            Console.WriteLine("submitted wifi creds");
            try
            {
                //await Navigation.PushAsync(new NavigationPage(new SystemInfo()));
                //if successful, notify user and direct to temperature setting page
                //else tell user it was unsuccessful
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}