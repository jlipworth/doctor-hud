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
        static string serverIp = "localhost";
        static int port = 8080;
        TcpClient client = new TcpClient(serverIp, port);

        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //float fcpu = pCPU.NextValue();
            //float fram = pRAM.NextValue();
            //metroProgressBarCPU.Value = (int)fcpu;
            //metroProgressBarRAM.Value = (int)fram;
            ////Console.WriteLine(fcpu + "," + fram);
            //labelCPU.Text = string.Format("{0:0.00}%", fcpu);
            //labelRAM.Text = string.Format("{0:0.00}%", fram);
            //chart1.Series["CPU"].Points.AddY(fcpu);
            //chart1.Series["RAM"].Points.AddY(fram);

            // Send request to server
            int byteCount = Encoding.ASCII.GetByteCount("ping") + 1;
            byte[] sendData = new byte[byteCount];
            // Append a ';' as the delimiter
            sendData = Encoding.ASCII.GetBytes("ping;");
            NetworkStream stream = client.GetStream();
            stream.Write(sendData, 0, sendData.Length);

            // Get response from server
            StringBuilder msg = new StringBuilder();
            byte[] receivedData = new byte[100];
            stream.Read(receivedData, 0, receivedData.Length);
            List<int> intList = new List<int>();
            foreach (byte b in receivedData)
            {
                //Console.WriteLine(b);
                // I'm not using null character here because I hope we have a special character that splits the fields
                // Just like what we did in 482 project 4
                if (b.Equals(59))
                {
                    intList.Add(Convert.ToInt32(msg.ToString()));
                    Console.WriteLine(msg.ToString());
                    msg.Clear();
                }
                else
                {
                    msg.Append(Convert.ToChar(b).ToString());
                }
            }

            // Update the value on UI
            int cpu = intList[0];
            int ram = intList[1];
            metroProgressBarCPU.Value = cpu;
            metroProgressBarRAM.Value = ram;
            labelCPU.Text = string.Format("{0}%", cpu);
            labelRAM.Text = string.Format("{0}%", ram);
            chart1.Series["CPU"].Points.AddY(cpu);
            chart1.Series["RAM"].Points.AddY(ram);

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

        // Click this activeX VLC
        private void metroButton1_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.add("https://youtu.be/MAYMFwjoWy8");
            //  http cannot be used for live stream. Use RTSP RSP instead.
            //axVLCPlugin21.playlist.add("https://youtu.be/dovudiWfzMU");
            Console.WriteLine("****************************************");
            axVLCPlugin21.playlist.play();
        }

        // Don't use this vlc.Dotnet button
        private void vlcControl1_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia("https://youtu.be/MAYMFwjoWy8");
            vlcControl1.Play();
        }
    }
}
