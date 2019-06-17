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
        private static ServiceReference1.Service1Client wcfServiceClient;
        private static bool _isInitialized = false;

        public AdpDataSource()
        {

            wcfServiceClient = new ServiceReference1.Service1Client();

            System.Diagnostics.Debug.WriteLine("!!!!   " + wcfServiceClient.GetNonFreePositionsForShowMap().Length);

            object[] url = { new UrlAttribute("tcp://localhost:9000/CAO") };
            remotingClientActivatedObject = (ClientActivatedObject)Activator.CreateInstance(
              typeof(ClientActivatedObject), null, url);
            if (_isInitialized == false)
            {
                remotingClientActivatedObject = new ClientActivatedObject();
                //serviceClient = new BidsServiceClient();

                _isInitialized = true;
            }

            RemotingConfiguration.RegisterActivatedClientType(typeof(ClientActivatedObject), "tcp://localhost:9000/CAO");
            remotingClientActivatedObject = new ClientActivatedObject();
        }
        internal bool login(string username, string password)
        {
            // Check if username is customer or not
            return false;
        }

        public Car AddCar(string city, string company, string color, string arrivalTime, string leavingTime, int ParkID, string customerName, bool isRegistered)
        {
            //Done
            Car newCar = remotingClientActivatedObject.AddCar(city, company, color, Convert.ToDateTime(arrivalTime), DateTime.Now, ParkID, customerName, isRegistered);
            return newCar;
            //    return new Car()
            //      {City = "test", Color = "red", Company = "tete", ArrivalTime = DateTime.MinValue, ID = GetHashCode()};
        }

        public bool RemoveCar(int id)
        {
            //Done
            return remotingClientActivatedObject.RemoveCar(id);
        }

        public bool checkoutCar(int id)
        {
            //Done
            return true;
//            return remotingClientActivatedObject.RemoveCar(id);
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

        public bool AddCustomer(string customerName, bool isVIP)
        {
            //Done
            return remotingClientActivatedObject.AddCustomer(customerName, isVIP);
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
            return remotingClientActivatedObject.RetrieveVIP(VIPID);

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
        public List<Customer> GetAllCustomers()
        {
//            todo get All customers 
//            return  remotingClientActivatedObject.GetAllCars();
            return new List<Customer>()
            {
                new Customer() {Name = "Zaher", Vip = 1},
                new Customer() {Name = "Zaher1", Vip = 1},
                new Customer() {Name = "Zaher2", Vip = 1},
                new Customer() {Name = "Zaher3", Vip = 1},
                new Customer() {Name = "Zaher4", Vip = 1},
            };
        }
    }
}