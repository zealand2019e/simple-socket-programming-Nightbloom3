using System;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server testserver = new Server();
            testserver.Start();
        }
    }
}
