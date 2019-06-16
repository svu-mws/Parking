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
        private static ClientActivatedObject remotingClientActivatedObject ;
        //private static WCFServices.BidsServiceClient serviceClient;
        private static bool _isInitialized = false;

        public AdpDataSource()
        {
             object[] url = {new UrlAttribute("tcp://localhost:9000/CAO")};
             remotingClientActivatedObject = (ClientActivatedObject) Activator.CreateInstance(
               typeof (ClientActivatedObject), null, url);
            if (_isInitialized == false)
            {
                     remotingClientActivatedObject = new ClientActivatedObject();
                    //serviceClient = new BidsServiceClient();

                _isInitialized = true;
            }

            RemotingConfiguration.RegisterActivatedClientType(typeof(ClientActivatedObject),"tcp://localhost:9000/CAO");
            remotingClientActivatedObject=new ClientActivatedObject();     
        }

        public Car AddCar(string city, string company, string color, string arrivalTime, string leavingTime, int ParkID,string customerName)
        {
            //Done
            Car newCar =  remotingClientActivatedObject.AddCar(city,company,color,Convert.ToDateTime(arrivalTime),DateTime.Now, ParkID,customerName);
            return newCar;
            //    return new Car()
            //      {City = "test", Color = "red", Company = "tete", ArrivalTime = DateTime.MinValue, ID = GetHashCode()};
        }

        public bool RemoveCar(int id)
        {
            //Done
            return remotingClientActivatedObject.RemoveCar(id);

        }

        public List<Car> GetAllCars()
        {
            //Done
            return remotingClientActivatedObject.GetAllCars();
            
        }

        public Position GetCarPosition(int id)
        {
           //Done
           return remotingClientActivatedObject.RetrievePositionOfCar(id);
            
        }

        public Position GetNearestPosition()
        {
           // Done
           return remotingClientActivatedObject.RetrieveNearestPosition();
        }

        public List<Position> GetFreePositions()
        {
           // Done
           return remotingClientActivatedObject.RetrieveFreePositions();
        }

        public bool AddCustomer(string  customerName,bool isVIP)
        {
            //Done
            return remotingClientActivatedObject.AddCustomer(customerName,isVIP);
        }

        public bool ModifyVIP(int VIPID, string VIPName)
        {
            //Done
            return remotingClientActivatedObject.ModifyVIP(VIPID, VIPName);
        }

        public bool RemoveCustomer(int customerID)
        {
            //TODO: solve problem when remove  VIP who have 
           return remotingClientActivatedObject.RemoveCustomer(customerID);
        }
        public Customer RetrieveVIP(int VIPID)
        {
            //Done
            return  remotingClientActivatedObject.RetrieveVIP(VIPID);
            
        }

        public bool SetCustomerAsVIP(int customerID)
        {
            //Done
            return remotingClientActivatedObject.SetCustomerAsVIP(customerID);
        }

        public bool RemoveRegisteredCar(int carID, int VIPID)
        {
            //Done
            return remotingClientActivatedObject.RemoveRegisteredCar(carID, VIPID);
        }

        //- Add/remove/retrieve registered car   
    }
}