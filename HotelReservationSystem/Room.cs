    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace HotelReservationSystem
    {
        // Oda Sınıfı
        public class Room
        {
            public int RoomNumber { get; set; }
            public string Type { get; set; }
            public decimal Price { get; set; }
            public bool IsOccupied { get; set; }

            public Room(int number, string type, decimal price)
            {
                RoomNumber = number;
                Type = type;
                Price = price;
                IsOccupied = false;
            }

            public override string ToString()
            {
            
                return $"Room {RoomNumber} - {Type} ({Price} $) ";
            }
        }
    }