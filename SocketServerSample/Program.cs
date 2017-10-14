using System;  
using System.Net;  
using System.Net.Sockets;  
using System.Text;

public class SynchronousSocketListener
{

    // Incoming data from the client.  
    public static string data = null;

    public static void StartListening()
    {
        Random randObj = new Random();
        // Start the server
        IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
        TcpListener server = new TcpListener(ip, 8080);
        TcpClient client = default(TcpClient);
        try
        {
            server.Start();
            Console.WriteLine("Server started...");
        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.Read();
        }

        client = server.AcceptTcpClient();
        Console.WriteLine("Connection established!");

        while (true)
        {
            //client = server.AcceptTcpClient();

            byte[] receivedBuffer = new byte[100];
            client.GetStream().Read(receivedBuffer, 0, receivedBuffer.Length);

            //string msg = Encoding.ASCII.GetString(receivedBuffer, 0, receivedBuffer.Length);
            StringBuilder msg = new StringBuilder();

            foreach (byte b in receivedBuffer)
            {
                // I'm not using null character here because I hope we have a special character that splits the fields
                // Just like what we did in 482 project 4
                if (b.Equals(59))
                {
                    break;
                }
                else
                {
                    msg.Append(Convert.ToChar(b).ToString());
                }
            }
            Console.WriteLine(msg.ToString() + msg.Length);

            string randStr1 = (randObj.Next() % 100).ToString();
            string randStr2 = (randObj.Next() % 100).ToString();
            byte[] sendData = new byte[Encoding.ASCII.GetByteCount(randStr1) + Encoding.ASCII.GetByteCount(randStr2) + 2];
            sendData = Encoding.ASCII.GetBytes(randStr1 + ";" + randStr2 + ";");
            client.GetStream().Write(sendData, 0, sendData.Length);
            Console.WriteLine(randStr1 + ";" + randStr2 + ";");
        }


    }

    public static int Main(String[] args)
    {
        StartListening();
        return 0;
    }
}