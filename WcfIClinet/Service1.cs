using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace WcfIClinet
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        
        public double MyInvoic(int CustID,int CarID)
        {
            ADP_ParkingEntities db = new ADP_ParkingEntities();
            Customer customer = db.Customers.Find(CustID);
            Car car = db.Cars.Find(CarID);
            RegisteredCar registeredCar = db.RegisteredCars.FirstOrDefault(r=> r.CarID == CarID && r.CustomerID == CustID);
            bool isRegistered = false;
            if (registeredCar != null)
                isRegistered = true;
            
            if (customer != null && car != null)
            {

                var invoke = new Bill(car.ArrivalTime.Value, car.LeavingTime.Value, customer.Vip == 1, isRegistered).InvoiceValue;
                return invoke;
                  //  return (new Bill(car.ArrivalTime.Value, car.LeavingTime.Value, customer.Vip ==1, isRegistered).InvoiceValue);


            }
            //return (new Bill(car.ArrivalTime.Value, car.LeavingTime.Value, false, false).InvoiceValue);
            return 0;
        }

      

        public List<int> GetFreePositionsForShowMap()
        {
            List<int> ids = new List<int>(); 
            ADP_ParkingEntities db = new ADP_ParkingEntities();
            var ParksIDsOFCars = db.Cars.Where(c => c.LeavingTime == null).Select(c => c.ParkID);
            var FreePositions = db.Positions.Where(p => !ParksIDsOFCars.Contains(p.ID)).ToList();
            foreach (int i in ParksIDsOFCars)
                ids.Add((int)i);

            return ids;
        }
        public List<int> GetNonFreePositionsForShowMap()
        {
            List<int> ids = new List<int>(); 
            ADP_ParkingEntities db = new ADP_ParkingEntities();
            var ParksIDsOFCars = db.Cars.Where(c => c.LeavingTime == null).Select(c => c.ParkID).ToList();
            var FreePositions = db.Positions.Where(p => ParksIDsOFCars.Contains(p.ID)).ToArray();
            foreach (int i in ParksIDsOFCars)
                ids.Add((int)i);
            return ids;
        }


    }
}
