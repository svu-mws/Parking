using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace ADP_Project_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            ADP_ParkingEntities x = new ADP_ParkingEntities();
            ClientActivatedObject clientActivatedObject = new ClientActivatedObject();
            var u = clientActivatedObject.RetrieveVIP(300);
            ChannelServices.RegisterChannel(new TcpChannel(9000), false);
            RemotingConfiguration.ApplicationName = "CAO";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(ClientActivatedObject));

            Console.WriteLine("Port 9000 has been started.");
            Console.WriteLine("Server is configured now.");
            Console.WriteLine("You can press any key to exit...");
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}