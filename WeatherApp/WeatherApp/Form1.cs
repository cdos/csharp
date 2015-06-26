using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Web;
//using System.Speech.Recognition;
//using System.Speech.Recognition;



namespace WeatherApp
{
    public partial class Form1 : Form
    {
        int timerTic = 1;
        DateTime now = DateTime.Now;
        string Temperature;
        string Condition;
        string Humidity;
        string WindSpeed;
        string Town;
        string TFCond;
        string TFHigh;
        string TFLow;
        string[] oeid = new string[] { "2442047", "2407517", "2382067","1020985"};
                
        public Form1()
        {
            InitializeComponent();

            //populates the combobox with oeid array
            oeidcmbox.DataSource = oeid;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Getweather()
        {
            //Finds the index of the array.
            int selecoeid = oeidcmbox.SelectedIndex;
            
            //reads the link and turn it a string call query.
            string query = String.Format("http://weather.yahooapis.com/forecastrss?w="+oeid[selecoeid]);

            //Instantiate xmldocument and call it wdata.
            XmlDocument wData = new XmlDocument();

            //feeds string into XmlDocument.
            wData.Load(query);

            //Instantiate xmlnamespacemanager and call it manager.  puts the xml into name table.
            XmlNamespaceManager manager = new XmlNamespaceManager(wData.NameTable);

            //adds a value to nametable.
            manager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            //steps through the xml from rss to channel.
            XmlNode channel = wData.SelectSingleNode("rss").SelectSingleNode("channel");
            
            //Makes a list of yweather:forecast
            XmlNodeList nodes = wData.SelectNodes("/rss/channel/item/yweather:forecast", manager);
            
            //Assigning xml values to variable
            Temperature = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["temp"].Value;
            Condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["text"].Value;
            Humidity = channel.SelectSingleNode("yweather:atmosphere", manager).Attributes["humidity"].Value;
            WindSpeed = channel.SelectSingleNode("yweather:wind", manager).Attributes["speed"].Value;
            Town = channel.SelectSingleNode("yweather:location", manager).Attributes["city"].Value;
            TFCond = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["text"].Value;
            TFHigh = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["high"].Value;
            TFLow = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["low"].Value;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerTic = timerTic - 1;
            if (timerTic == 0)
            {
                lstWeather.Items.Clear();
                Getweather();
                lstWeather.Items.Add("Town               : " + Town);
                lstWeather.Items.Add("Condition          : " + Condition);
                lstWeather.Items.Add("Temperature        : " + Temperature);
                lstWeather.Items.Add("Humidity           : " + Humidity);
                lstWeather.Items.Add("Wind Speed         : " + WindSpeed);
                lstWeather.Items.Add("Tomorrows Condition: " + TFCond);
                lstWeather.Items.Add("Tomorrows High     : " + TFHigh);
                lstWeather.Items.Add("Tomorrows Low      : " + TFLow);
                timerTic = 5;
                lblUpdateTime.Text = now.GetDateTimeFormats('t')[0];
            }
        }

        private void getweatherbutton_Click(object sender, EventArgs e)
        {
            Getweather();
            towntxtbox.Text = Town;
            conditiontxtbox.Text = Condition;
            temperaturetxtbox.Text = Temperature;
            humiditytxtbox.Text = Humidity;
            windspeedtxtbox.Text = WindSpeed;
            tomorrowcondtxtbox.Text = TFCond;
            tomorrowhightxtbox.Text = TFHigh;
            tomorrowlowtxtbox.Text = TFLow;
        }

        
    }
}
