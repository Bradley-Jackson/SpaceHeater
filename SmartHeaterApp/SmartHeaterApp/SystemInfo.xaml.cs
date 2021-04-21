using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;


namespace SmartHeaterApp
{
    public class SystemInfoObject
    {
        public string surfaceTemp { get; set; }
        public string roomTemp { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SystemInfo : ContentPage
    {
        public bool displayFarenheit;

        public SystemInfoObject sysObject;
        public SystemInfo(bool inFarenheit)
        {
            displayFarenheit = inFarenheit;
            try
            {
                InitializeComponent();
                RefreshSystemInfo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RefreshSystemInfo(object sender = null, EventArgs e = null)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://65.189.242.145:8081/getSystemInfo.php");
                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                sysObject = JsonConvert.DeserializeObject<SystemInfoObject>(responseFromServer);

                response.Close();

                ChangeLabels();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ChangeLabels()
        {
            if(displayFarenheit)
            {
                RoomDisplayLabel.Text = sysObject.roomTemp + " ° F";
                SurfaceDisplayLabel.Text = sysObject.surfaceTemp + " ° F";
            }
            else
            {
                RoomDisplayLabel.Text = Math.Round(((Convert.ToDouble(sysObject.roomTemp) - 32.0) * (5.0 / 9.0)), 2).ToString() + " ° C";
                SurfaceDisplayLabel.Text = Math.Round(((Convert.ToDouble(sysObject.surfaceTemp) - 32.0) * (5.0 / 9.0)), 2).ToString() + " ° C";
            }
        }
    }
}