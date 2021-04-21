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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemperatureSettings : ContentPage
    {
        Label temperatureScaleLabel = new Label();
        public TemperatureSettings(bool isFarenheit)
        {
            InitializeComponent();
        }

        void SetTemperature(object sender, EventArgs e)
        {
            Console.WriteLine("set Temperature");
            try
            {
                WebRequest request = WebRequest.Create("http://65.189.242.145:8081/fff.php");

                request.Method = "POST";
                string postData = "test str";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();

                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();

                //WebRequest request = WebRequest.Create("http://65.189.242.145:8081/getSystemInfo.php");
                //WebResponse response = request.GetResponse();

                //Stream dataStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(dataStream);
                //string responseFromServer = reader.ReadToEnd();

                //sysObject = JsonConvert.DeserializeObject<SystemInfoObject>(responseFromServer);

                //response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}