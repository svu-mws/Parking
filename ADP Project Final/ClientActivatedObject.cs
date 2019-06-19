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


        public Car AddCar(string city, string company, string color, DateTime arrivalTime, DateTime LeavingTime,
            int parkID, string customerName, bool isGrgisterdCar)
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
            if (customer.Vip == 1 && isGrgisterdCar)
            {
                context.RegisteredCars.Add(new RegisteredCar()
                {
                    CarID = CarID,
                    CustomerID = customer.ID
                });
                context.SaveChanges();
            }


            addedCar = context.Cars.Find(CarID);
            return addedCar;
        }


        public bool RemoveCar(int carID)
        {
            try
            {
                var car = context.Cars.Find(carID);
                if (car != null)
                {
                    context.Cars.Remove(car);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public List<Car> GetAllCars()
        {
            var cars = context.Cars.ToList();
            return cars;
        }


        public List<Position> RetrieveFreePositions()
        {
            List<Position> freePositions = new List<Position>();
            var ParksIDsOFCars = context.Cars.Where(c => c.LeavingTime == null);
            if (ParksIDsOFCars != null)
            {
                var Ids = ParksIDsOFCars.Select(c => c.ParkID);
                freePositions = context.Positions.Where(p => !Ids.Contains(p.ID)).ToList();
            }

            return freePositions;
        }


        public Position RetrievePositionOfCar(int carID)
        {
            try
            {
                var position = context.Cars.Find(carID);
                if (position != null)
                {
                    var PositionCarNumber = position.ParkID;
                    Position PositionOfCar = context.Positions.Find(PositionCarNumber);
                    return PositionOfCar;
                }
                else
                    return new Position() {ID = -1};
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public List<Car> GetCarsOfCustomer(int customerID)
        {
            List<Car> cars = new List<Car>();
            var carsCont = context.Cars.Where(c => c.CustomerID == customerID && c.LeavingTime == null);

            if (carsCont != null)
                cars = carsCont.ToList();
            return cars;
        }


        public bool MakePositionCarEmpty(int positionID)
        {
            try
            {
                var car = context.Cars.FirstOrDefault(c => c.ParkID == positionID);
                if (car != null)
                {
                    car.LeavingTime = DateTime.Now;
                    car.ParkID = null;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Position RetrieveNearestPosition()
        {
            List<Position> sortedPositions = new List<Position>();
            var ParksIDsOFCars = context.Cars.Where(c => c.LeavingTime == null);
            if (ParksIDsOFCars != null)
            {
                var ids = ParksIDsOFCars.Select(c => c.ParkID);
                var FreePositions = context.Positions.Where(p => !ids.Contains(p.ID)).ToList();
                sortedPositions = FreePositions.OrderBy(p => Math.Abs((int) p.Floor)).ToList();
                return sortedPositions[0];
            }

            return new Position() {ID = -1};
        }


        public bool AddCustomer(string customerName, string password, bool IsVIP)
        {
            if (IsVIP)
            {
                context.Customers.Add(new Customer()
                {
                    Name = customerName,
                    Vip = 1,
                    Password = password
                });
            }
            else

                context.Customers.Add(new Customer()
                {
                    Name = customerName,
                    Password = password,
                });

            context.SaveChanges();
            return true;
        }

        public bool ModifyVIP(int VIPID, string VIPName)
        {
            try
            {
                var VIP = context.Customers.Find(VIPID);
                if (VIP != null)
                {
                    VIP.Name = VIPName;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool RemoveCustomer(int customerID)
        {
            try
            {
                var customer = context.Customers.Find(customerID);
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                    if (customer.Vip == 1)
                    {
                        var registered = context.RegisteredCars.Where(r => r.CustomerID == customerID).ToList();
                        context.RegisteredCars.RemoveRange(registered);
                        context.SaveChanges();
                    }

                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Customer RetrieveVIP(int VIPID)
        {
            try
            {
                return context.Customers.Find(VIPID);
            }
            catch (Exception e)
            {
                return new Customer() {ID = -1};
                Console.WriteLine(e);
                throw;
            }
        }

        public bool SetCustomerAsVIP(int customerID)
        {
            try
            {
                var VIP = context.Customers.Find(customerID);
                if (VIP != null)
                {
                    VIP.Vip = 1;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool RemoveRegisteredCar(int carID, int VIPID)
        {
            try
            {
                var registeredCar =
                    context.RegisteredCars.FirstOrDefault(r => r.CustomerID == VIPID && r.CarID == carID);
                if (registeredCar != null)
                {
                    context.RegisteredCars.Remove(registeredCar);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = context.Customers.ToList();
            return customers;
        }
        public List<Position> GetAllPositions()
        {
            var positions = context.Positions.ToList();
            return positions;
        }
        string RemoveExtraSpaces(string str)
        {
            str = str.Trim();
            StringBuilder sb = new StringBuilder();
            bool space = false;
            foreach (char c in str)
            {
                if (char.IsWhiteSpace(c) || c == (char)9) { space = true; }
                else { if (space) { sb.Append(' '); }; sb.Append(c); space = false; };
            }
            return sb.ToString();
        }

        public Customer Login(string userName, string password)
        {
            try
            {
                var customer = context.Customers.FirstOrDefault(c => c.Name == userName);

                
                if (customer != null && RemoveExtraSpaces(customer.Password).Equals( password))
                {
                    return customer;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new Customer() {ID = -1};
        }
    }
}