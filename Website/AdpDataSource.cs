using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Web;
using Model;

namespace Website
{
    public class AdpDataSource
    {
        //private static ClientActivatedObject remotingClientActivatedObject;
        //private static WCFServices.BidsServiceClient serviceClient;
        private static bool _isInitialized = false;

        public AdpDataSource()
        {
            // object[] url = {new UrlAttribute("tcp://localhost:7000/CAO")};
            // remotingClientActivatedObject = (ClientActivatedObject) Activator.CreateInstance(
            //   typeof (ClientActivatedObject), null, url);
            if (_isInitialized == false)
            {
                //    remotingClientActivatedObject = new ClientActivatedObject();
                //    serviceClient = new BidsServiceClient();

                _isInitialized = true;
            }

            //RemotingConfiguration.RegisterActivatedClientType(typeof(ClientActivatedObject),"tcp://localhost:7000/CAO");
            //remotingClientActivatedObject=new ClientActivatedObject();     
        }

        public Car AddCar(string city, string company, string color, string arrivalTime, string leavingTime)
        {
            //return serviceClient.AddCar(params);
            return new Car()
                {City = "test", Color = "red", Company = "tete", ArrivalTime = DateTime.MinValue, ID = GetHashCode()};
        }

        public bool RemoveCar(int id)
        {
            //return serviceClient.removeCar(params);
            return true;
        }

        public List<Car> GetAllCars()
        {
            //return serviceClient.removeCar(params);
            return new List<Car>();
        }

        public Position GetCarPosition(int id)
        {
            //return serviceClient.getCarPosition(id);
            return new Position();
        }

        public Position GetNearestPosition()
        {
            //return serviceClient.getNearestPosition();
            return new Position();
        }

        public List<Position> GetFreePositions()
        {
            return new List<Position>();
        }

        //- Add/remove/retrieve/modify VIP
        //- Add/remove/retrieve registered car   
    }
}