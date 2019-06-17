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
        
        public Bill MyInvoic(int CustID,int CarID)
        {
            ADP_ParkingEntities db = new ADP_ParkingEntities();
            Customer cust = db.Customers.Find(CustID);
            Car car = db.Cars.Find(CarID);
            
            if (cust!= null)
            {
                if (car.CustomerID == CustID)
                    return (new Bill(car.ArrivalTime.Value, car.LeavingTime.Value, true, true));
                return (new Bill(car.ArrivalTime.Value, car.LeavingTime.Value, true, false));

            }
            return (new Bill(car.ArrivalTime.Value, car.LeavingTime.Value, false, false));
            
        }

        public List<Position> ShowParkMap()
        {
            ADP_ParkingEntities db = new ADP_ParkingEntities();
            //var ParksIDsOFCars = db.Cars.postition;
            //var busyposition = db.Positions.Where(p => ParksIDsOFCars.Contains(p.ID)).ToList();

            //return busyposition;
            List<Position> Busypositions = null;
             List<Car> cars =  db.Cars.ToList();
            
                foreach (Car car in cars)
                {
                    Busypositions.Add(car.Position);

                 }
                return Busypositions;

        }

    }
}
