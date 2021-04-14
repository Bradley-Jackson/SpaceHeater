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
    public partial class SystemInfo : ContentPage
    {
        public SystemInfo()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RefreshSystemInfo(object sender, EventArgs e)
        {
            //get info from embedded controller
            //display to page
        }
    }
}