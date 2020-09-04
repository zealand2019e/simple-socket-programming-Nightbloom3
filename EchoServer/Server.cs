using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace EchoServer
{
    public class Server
    {
        public void Start()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 7777;
                IPAddress localAddress = IPAddress.Parse("192.168.24.166");

                server = new TcpListener(localAddress, port);

                server.Start();

                Byte[] bytes = new byte[256];
                string data = null;

                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected");

                    data = null;

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Recived: {0}", data);

                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        stream.Write(msg, 0, msg.Length);

                        Console.WriteLine("Sent: {0}", data);
                    }

                    client.Close();
                }

            }


            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();

        }
    }
}
