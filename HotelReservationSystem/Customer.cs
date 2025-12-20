using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    // Müşteri Sınıfı
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string PhoneNumber { get; set; }

        public Customer( string customerName, string id, string phoneNumber)
        {
            CustomerName = customerName;
            CustomerId = id;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{CustomerName} (ID: {CustomerId}) - Tel: {PhoneNumber}";
        }
    }
}