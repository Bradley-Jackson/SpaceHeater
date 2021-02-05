using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace heaterApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScheduledHeating : ContentPage
	{
		public ScheduledHeating ()
		{
			InitializeComponent ();
		}

        private void setScheduledHeat(object sender, EventArgs e)
        {

        }
    }
}