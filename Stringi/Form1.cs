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
using Stringi.KlasyWlasne;

namespace Stringi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            backgroundWorker1.RunWorkerAsync();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Dlugosc tekstu:" +
                textBox1.Text.Length;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 1)
            {
                return;
            }
            if (textBox1.Text.Length < 1)
            {
                return;
            }




            int nrZnaku = 0;

            nrZnaku = Int32.Parse(textBox2.Text);
            if (nrZnaku < textBox1.Text.Length)
            {
                label3.Text = "Znak na miejscu "        
                    + nrZnaku + " to: '" + textBox1.Text[nrZnaku - 1] + "'";
            }
            else
            {
                MessageBox.Show("Nie ma aż tyle znaków!!!");
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains(textBox3.Text))
            {
                label4.Text = "TAK!";
            }else
            {
                label4.Text = "Nie :(";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";

            //char obecnyZnak = ' ';
            //obecnyZnak = textBox1.Text[0];
            int nrZnaku = 0;
            while (!(textBox1.Text[nrZnaku] == ' '))
            {
                label5.Text 
                    = label5.Text + textBox1.Text[nrZnaku];


                nrZnaku = nrZnaku + 1;
            }
        }

        //Wykonuje się podczas zmiany wartości a
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            policzTrygonometrie();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            policzTrygonometrie();
        }

    
        public void policzTrygonometrie()
        {
            //Tworzenie zmiennych
            double a, b, c;
            //Pobieranie a i b

            if (textBox4.Text.Length > 0)
            {
                a = Double.Parse(textBox4.Text);
            }
            else
            {
                a = 0;
            }

            if (textBox5.Text.Length > 0)
            {
                b = Double.Parse(textBox5.Text);
            }
            else
            {
                b = 0;
            }
    //obliczanie c (z tw. Pitagorasa)
    c = Math.Sqrt(a * a + b * b);

            //Wartość c
            textBox6.Text = c + "";
            //Sinus Alpha
            textBox7.Text = a / c + "";
            //Cosinus Alpha
            textBox8.Text = b / c + "";
            //Tangens Alpha
            textBox9.Text = a / b + "";
            //Cotangens Alpha
            textBox10.Text = b / a + "";
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Wait 100 milliseconds.
                Thread.Sleep(500);
                // Report progress. 
                /*****************************Discuss!****************/
                toolStripProgressBar1.ProgressBar.Invoke(new MethodInvoker(delegate { toolStripProgressBar1.Value++; }));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FunkcjePogodowe.pokazZachodSlonca(label13);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20wind%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22chicago%2C%20il%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
            }

            var tablicajson = JsonConvert.DeserializeObject<dynamic>(json);

            listBox1.Items[0] = 
                tablicajson.query.results.channel.wind.chill;

            listBox1.Items[1] =
                tablicajson.query.results.channel.wind.speed;

            listBox1.Items[2] =
                tablicajson.query.results.channel.wind.direction;
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
