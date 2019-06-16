using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP_Project_Final
{
   public class ClientActivatedObject : MarshalByRefObject
    {
        public static ADP_ParkingEntities context;

        public ClientActivatedObject()
        {
            context = new ADP_ParkingEntities();
            context.Configuration.ProxyCreationEnabled = false;
        }


        public Car AddCar(string city, string company, string color, DateTime arrivalTime, DateTime LeavingTime ,int parkID , string customerName)
        {
            var addedCar = new Car();
            
            var customer = context.Customers
                .FirstOrDefault(c => c.Name == customerName);
            
            var newCar = new Car()
            {
                City = city,
                Company = company,
                Color = color,
                ArrivalTime = arrivalTime,
                ParkID = parkID,
                CustomerID = customer.ID
            };
            context.Cars.Add(newCar);
            context.SaveChanges();

            var CarID = newCar.ID;

            //Is VIP Customer
            if (customer.Vip == 1)
            {
            context.RegisteredCars.Add(new RegisteredCar()
            {
               CarID = CarID,
              CustomerID = customer.ID
            });
            context.SaveChanges();
            }

               
            addedCar= context.Cars.Find(CarID);
            return addedCar;
        }

        
        public bool RemoveCar(int carID)
        {
            var car = context.Cars.Find(carID);
            context.Cars.Remove(car);
            context.SaveChanges();
            return true;
        }

        
        public List<Car> GetAllCars()
        {
            var cars = context.Cars.ToList();
            return cars;
        }

        
        public List<Position> RetrieveFreePositions()
        {
            var ParksIDsOFCars = context.Cars.Where(c=> c.LeavingTime == null).Select(c => c.ParkID);
            var FreePositions = context.Positions.Where(p => !ParksIDsOFCars.Contains(p.ID)).ToList();
            
            return FreePositions;
        }


        public Position RetrievePositionOfCar(int carID)
        {
            var PositionCarNumber = context.Cars.Find(carID).ParkID;
            Position PositionOfCar = context.Positions.Find(PositionCarNumber);
            return PositionOfCar;
        }

        
        public Position RetrieveNearestPosition()
        {
            List<Position> sortedPositions = new List<Position>();
            var ParksIDsOFCars = context.Cars.Where(c=> c.LeavingTime == null).Select(c => c.ParkID);
            var FreePositions = context.Positions.Where(p => !ParksIDsOFCars.Contains(p.ID)).ToList();
            sortedPositions = FreePositions.OrderBy(p => Math.Abs((int) p.Floor)).ToList();
            return  sortedPositions[0];
        }




        public bool AddCustomer(string customerName , bool IsVIP)
        {
         if (IsVIP){
            context.Customers.Add(new Customer()
            {
                Name = customerName,
                Vip = 1

            });
         }else
         
             context.Customers.Add(new Customer()
             {
                 Name = customerName,

             });
            context.SaveChanges();
            return true;
        }

        public bool ModifyVIP(int VIPID,string VIPName)
        {
            var VIP = context.Customers.Find(VIPID);
            if (VIP != null){
                VIP.Name = VIPName;
                context.SaveChanges();
            }

            return true;
        }

        public bool RemoveCustomer(int customerID)
        {
            var customer= context.Customers.Find(customerID);
            context.Customers.Remove(customer);
            context.SaveChanges();
            return  true;
        }

        public Customer RetrieveVIP(int VIPID)
        {
            return  context.Customers.Find(VIPID);
            
        }
        
        public bool SetCustomerAsVIP(int customerID)
        {
            var VIP = context.Customers.Find(customerID);
            if (VIP != null){
                VIP.Vip = 1;
                context.SaveChanges();
            }

            return true;
        }
        
        public bool RemoveRegisteredCar(int carID, int VIPID)
        {
            var registeredCar = context.RegisteredCars.FirstOrDefault( r => r.CustomerID == VIPID &&  r.CarID == carID);
            if (registeredCar != null) {
            context.RegisteredCars.Remove(registeredCar);
            context.SaveChanges();
            }
            return true;

        }

    }
}
