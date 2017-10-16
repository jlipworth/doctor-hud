using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net;
using System.Net.Sockets;
using LiveCharts;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        //static string serverIp = "10.211.55.2";
        static string serverIp = "localhost";
        static int port = 56754;
        static int count = 0;
        TcpClient client = new TcpClient(serverIp, port);
        Dictionary<string, int> sensorData = new Dictionary<string, int>();
        

        public Form1()
        {
            InitializeComponent();
            sensorData.Add("heart_rate", 0);
            sensorData.Add("systolic", 0);
            sensorData.Add("diastolic", 0);
            sensorData.Add("sp_o2", 0);
            sensorData.Add("respiration_rate", 0);            sensorData.Add("etCO2", 0);

            //UI construction
            etCO2Panel.Value = 0;
            etCO2Panel.FromValue = 0;
            etCO2Panel.ToValue = 40;
            etCO2Panel.TickStep = 3;
            etCO2Panel.Wedge = 180;
            etCO2Panel.Sections.Add(new AngularSection
            {
                FromValue = 25,
                ToValue = 35,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            respirationPanel.Value = 0;
            respirationPanel.FromValue = 0;
            respirationPanel.ToValue = 25;
            respirationPanel.TickStep = 3;
            respirationPanel.Wedge = 180;
            respirationPanel.Sections.Add(new AngularSection
            {
                FromValue = 10,
                ToValue = 20,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            heartRate.Value = 0;
            heartRate.FromValue = 0;
            heartRate.ToValue = 150;
            heartRate.TickStep = 3;
            heartRate.Sections.Add(new AngularSection
            {
                FromValue = 50,
                ToValue = 100,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            heartRate.Sections.Add(new AngularSection
            {
                FromValue = 100,
                ToValue = 150,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Title = "Systolic",
                    Values = new ChartValues<double> { 0 }
                },
                new LineSeries
                {
                    Title = "Diastolic",
                    Values = new ChartValues<double> { 0 }
                }
            };
            cartesianChart1.LegendLocation = LegendLocation.Right;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            NetworkStream stream = client.GetStream();
            // Get response from server
            StringBuilder msg = new StringBuilder();
            byte[] receivedData = new byte[1024];
            stream.Read(receivedData, 0, receivedData.Length);

            string metric = "heart_rate";
            foreach (byte b in receivedData)
            {
                //Console.WriteLine(b);
                // I'm not using null character here because I hope we have a special character that splits the fields
                // Just like what we did in 482 project 4
                if (b.Equals(59))
                {
                    int value = Convert.ToInt32(msg.ToString());
                    Console.WriteLine(value);
                    sensorData[metric] = value;
                    msg.Clear();
                }
                else if (b.Equals(58))
                {
                    metric = msg.ToString();
                    msg.Clear();
                }
                else
                {
                    msg.Append(Convert.ToChar(b).ToString());
                }
            }

            // Update the value on UI
            count++;
            heartrateLabel.Text = string.Format("{0}", sensorData["heart_rate"]);
            heartRate.Value = (int)sensorData["heart_rate"];
            spo2ProgressBar.Value = sensorData["sp_o2"];
            spo2Label.Text = string.Format("{0}%", sensorData["sp_o2"]);
            respirationValue.Text = string.Format("{0}", sensorData["respiration_rate"]);
            respirationPanel.Value = (int)sensorData["respiration_rate"];
            etCO2Value.Text = string.Format("{0}", sensorData["etCO2"]);
            etCO2Panel.Value = (int)sensorData["etCO2"];
            cartesianChart1.Series[0].Values.Add((Double) sensorData["systolic"]);
            cartesianChart1.Series[1].Values.Add((Double) sensorData["diastolic"]);
            if (count > 10)
            {
                cartesianChart1.Series[0].Values.RemoveAt(0);
                cartesianChart1.Series[1].Values.RemoveAt(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressBar2_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            
        }

        private void hartRate_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void etCO2Value_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        //// Click this activeX VLC
        //private void metroButton1_Click(object sender, EventArgs e)
        //{
        //    axVLCPlugin21.playlist.add("https://youtu.be/MAYMFwjoWy8");
        //    //  http cannot be used for live stream. Use RTSP RSP instead.
        //    //axVLCPlugin21.playlist.add("https://youtu.be/dovudiWfzMU");
        //    Console.WriteLine("****************************************");
        //    axVLCPlugin21.playlist.play();
        //}

        //private void axVLCPlugin21_Enter(object sender, EventArgs e)
        //{

        //}
    }
}
