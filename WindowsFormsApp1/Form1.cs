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

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        static string serverIp = "10.211.55.2";
        //static string serverIp = "35.3.37.18";
        static int port = 56754;
        TcpClient client = new TcpClient(serverIp, port);

        Dictionary<string, int> sensorData = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
            sensorData.Add("heart_rate", 0);
            sensorData.Add("systolic", 0);
            sensorData.Add("diastolic", 0);
            sensorData.Add("sp_o2", 0);
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
            heartrateLabel.Text = string.Format("{0}", sensorData["heart_rate"]);
            spo2ProgressBar.Value = sensorData["sp_o2"];
            spo2Label.Text = string.Format("{0}%", sensorData["sp_o2"]);
            chart1.Series["Systolic"].Points.AddY(sensorData["systolic"]);
            chart1.Series["Diastolic"].Points.AddY(sensorData["diastolic"]);

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
