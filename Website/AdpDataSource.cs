using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Web;
using Model;
using ADP_Project_Final;

namespace Website
{
    public class AdpDataSource
    {
        private static ClientActivatedObject remotingClientActivatedObject;
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

        public Car AddCar(string city, string company, string color, string arrivalTime, string leavingTime, int ParkID)
        {
            return remotingClientActivatedObject.AddCar(city,company,color,DateTime.Parse(arrivalTime),DateTime.Parse(leavingTime), ParkID);
            //return new Car()
            //    {City = "test", Color = "red", Company = "tete", ArrivalTime = DateTime.MinValue, ID = GetHashCode()};
        }

        public bool RemoveCar(int id)
        {
            return remotingClientActivatedObject.RemoveCar(id);
            
        }

        public List<Car> GetAllCars()
        {
            return remotingClientActivatedObject.GetAllCars();
            
        }

        public Position GetCarPosition(int id)
        {
            return remotingClientActivatedObject.RetrievePositionOfCar(id);
            
        }

        public Position GetNearestPosition()
        {
           return remotingClientActivatedObject.RetrieveNearstPosition();
        }

        public List<Position> GetFreePositions()
        {
            return remotingClientActivatedObject.RetrieveFreePostions();
        }

        //- Add/remove/retrieve/modify VIP
        //- Add/remove/retrieve registered car   
    }
}