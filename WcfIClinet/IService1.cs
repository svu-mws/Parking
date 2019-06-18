using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace WcfIClinet
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        double MyInvoic(int CustID, int CarID);


        [OperationContract]
        List<int> GetFreePositionsForShowMap();


        [OperationContract]
        List<int> GetNonFreePositionsForShowMap();


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfIClinet.ContractType".
    [DataContract]

    public class Bill
    {
       public  DateTime entertime;
        public DateTime exittime;
        public TimeSpan ParkingPeriod;
        public Double InvoiceValue;

        public Bill(DateTime exittime, bool VIP, bool RegisterdCar)
        {
            this.exittime = exittime;
            exittime = DateTime.Now;
            InvoiceValue = 0;
            ParkingPeriod = exittime - entertime;
            int days =ParkingPeriod.Days;
            int hours = ParkingPeriod.Hours;
            InvoiceValue += days * 2000 ;
            if (hours>=12)
                InvoiceValue+= hours * 100;
            else
                if (hours >= 6)
                InvoiceValue+= hours * 125;
                else
                    if (hours >= 1)
                       InvoiceValue += hours * 150;
            if (VIP)
            {
                if (RegisterdCar)
                    InvoiceValue = 0;
                else
                    InvoiceValue /= 2;
            }

        }
        public Bill(DateTime entertime, DateTime exittime, bool VIP, bool RegisterdCar)
        {
            InvoiceValue = 0;
            this.entertime = entertime;
            this.exittime = exittime;
            ParkingPeriod = exittime - entertime;
            int days = ParkingPeriod.Days;
            int hours = ParkingPeriod.Hours;
            InvoiceValue += days * 2000;
            if (hours >= 12 && hours <= 24)
                InvoiceValue += hours * 100;
            else
                if (hours >= 6 && hours <= 12)
                    InvoiceValue += hours * 125;
                else
                    if (hours >= 1 && hours <= 6)
                        InvoiceValue += hours * 150;
            if (VIP)
            {
                if (RegisterdCar)
                    InvoiceValue = 0;
                else
                    InvoiceValue /= 2;
            }
             

        }
        public double getInvoice()
        {
            return this.InvoiceValue;
        }
       /*
       
        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }*/
    }
}
