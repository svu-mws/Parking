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
        //public static ParkingManagerDatabaseEntities context;

        //public ClientActivatedObject()
        //{
        //    context = new ParkingManagerDatabaseEntities();
        //}


        //public Car AddCar(string City, string Company, string Color, DateTime ArrivalTime, DateTime LeavingTime ,int ParkID , string Registered =null )
        //{
        //    int CarID = context.Cars.ToList().Count + 1;
        //    context.Cars.Add(new Car()
        //    {
        //        ID =  CarID,
        //        City = City,
        //        Company = Company,
        //        Color = Color,
        //        ArrivalTime = ArrivalTime,
        //        ParkID = ParkID,
        //       // Registered = Registered


        //    });

        //    //TODO:Add to registered cars
        //    return context.Cars.Find(CarID);
        //}

        //public bool RemoveCar(int CarID)
        //{
        //    var car = context.Cars.Find(CarID);
        //    context.Cars.Remove(car);
        //    return true;
        //}

        //public List<Car> GetAllCars()
        //{
        //    return context.Cars.ToList();
        //}

        //public List<Position> RetrieveFreePostions()
        //{
        //    var ParksIDsOFCars = context.Cars.Select(c => c.ParkID);
        //    var FreePositions = context.Positions.Where(p => !ParksIDsOFCars.Contains(p.ID)).ToList();
            
        //    return FreePositions;
        //}


        //public Position RetrievePositionOfCar(int CarID)
        //{
        //    var PositionCarNumber = context.Cars.Find(CarID).ParkID;
        //    Position PositionOfCar = context.Positions.Find(PositionCarNumber);
        //    return PositionOfCar;
        //}

        //public Position RetrieveNearstPosition()
        //{
        //    var ParksIDsOFCars = context.Cars.Select(c => c.ParkID);
        //    var FreePositionsIN_0Floor = GetFreePositionsIn_0Floor(ParksIDsOFCars);
        //    if (FreePositionsIN_0Floor.Count > 0)
        //        return FreePositionsIN_0Floor[0];
        //    else
        //    {
        //        var PositiveFreePositions = GetFreePositionsInPositiveFloors(ParksIDsOFCars);
        //        var NegativeFreePositions = GetFreePositionsInNegativeFloors(ParksIDsOFCars);
        //        if (PositiveFreePositions.Count > 0 && NegativeFreePositions.Count == 0)
        //            return PositiveFreePositions[0];
        //        else
        //        {
        //            if (NegativeFreePositions.Count > 0 && PositiveFreePositions.Count == 0)
        //                return NegativeFreePositions[0];
        //            else
        //            {
        //                if (PositiveFreePositions.Count > 0 && NegativeFreePositions.Count > 0)
        //                {
        //                    var PositivePosition = PositiveFreePositions[0];
        //                    var NegativePosition = NegativeFreePositions[0];

        //                    // to do: complete this case
        //                }
        //            }

        //        }
        //    }


        //        return new Position();
        //}


        ////public void AddVIP(string CustomerName, int CarID = -1)
        ////{
        ////    String RegisteredCarIDs = "";
        ////    if (CarID != -1)
        ////        RegisteredCarIDs = Convert.ToString(CarID);

        ////    context.Customers.Add(new Customer()
        ////    {
        ////        Name = CustomerName,

        ////    });
        ////}

        //public void ModifyVIP(int VIPID)
        //{

        //}

        //public void RemoveVIP(int VIPID)
        //{
        //    var VIP = context.Customers.Find(VIPID);
        //    context.Customers.Remove(VIP);
        //}

        //public Customer RetrieveVIP(int VIPID)
        //{
        //    return  context.Customers.Find(VIPID);
            
        //}


        //public List<Position> GetFreePositionsIn_0Floor(IQueryable<int?> ParksIDsOFCars)
        //{
        //    List<Position> SortedFreePositionsInFloor = new List<Position>();
        //    var FreePositionsInFloor = context.Positions.Where(p => !ParksIDsOFCars.Contains(p.ID) && p.Floor == 0 ).ToList();
        //    SortedFreePositionsInFloor = FreePositionsInFloor.OrderBy(p => p.Floor).ThenBy(p => p.Department).ThenBy(p => p.Place).ToList();
        //    return SortedFreePositionsInFloor;
        //}

        //public List<Position> GetFreePositionsInPositiveFloors( IQueryable<int?> ParksIDsOFCars)
        //{
        //    List<Position> SortedFreePositionsInFloor = new List<Position>();

        //    var FreePositionsInFloor = context.Positions.Where(p => !ParksIDsOFCars.Contains(p.ID) && (p.Floor == 1 || p.Floor == 2 || p.Floor == 3 || p.Floor == 4 || p.Floor == 5)).ToList();
        //    SortedFreePositionsInFloor = FreePositionsInFloor.OrderBy(p => p.Floor).ThenBy(p => p.Department).ThenBy(p => p.Place).ToList();
        //    return SortedFreePositionsInFloor;

        //}
        //public List<Position> GetFreePositionsInNegativeFloors(IQueryable<int?> ParksIDsOFCars)
        //{
        //    List<Position> SortedFreePositionsInFloor = new List<Position>();
        //    var FreePositionsInFloor = context.Positions.Where(p => !ParksIDsOFCars.Contains(p.ID) && (p.Floor == -1 || p.Floor == -2 )).ToList();
        //    SortedFreePositionsInFloor = FreePositionsInFloor.OrderBy(p => p.Floor).ThenBy(p => p.Department).ThenBy(p => p.Place).ToList();
        //    return SortedFreePositionsInFloor;
        //}
    }
}
