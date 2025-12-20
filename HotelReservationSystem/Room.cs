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
        public decimal PricePerNight { get; set; }
        public bool IsOccupied { get; set; }

        public Room(int number, string type, decimal price)
        {
            RoomNumber = number;
            Type = type;
            PricePerNight = price;
            IsOccupied = false;
        }

        public override string ToString()
        {
            string status = IsOccupied ? "[DOLU]" : "[BOŞ]";
            return $"Oda {RoomNumber} - {Type} ({PricePerNight} TL) - {status}";
        }
    }
}