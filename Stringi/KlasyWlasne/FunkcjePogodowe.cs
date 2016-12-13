using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using Newtonsoft.Json;

namespace Stringi.KlasyWlasne
{
    class FunkcjePogodowe
    {

        public static void pokazZachodSlonca(Label label13)
        {
            string json = "";
            


            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20astronomy.sunset%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22maui%2C%20hi%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
            }

            var tablicajson = JsonConvert.DeserializeObject<dynamic>(json);


            var godzina = tablicajson.query.results.channel.astronomy.sunset;

            label13.Text = godzina;


            
        }


    }
}
