using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    // Rezervasyon Sınıfı: Müşteri ile Oda arasındaki ilişkiyi kurar.
    public class Reservation
    {
        public Room HotelRoom { get; set; }      // Hangi oda?
        public Customer HotelGuest { get; set; } // Hangi müşteri?
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Reservation(Room room, Customer guest, DateTime entry, DateTime exit)
        {
            HotelRoom = room;
            HotelGuest = guest;
            CheckInDate = entry;
            CheckOutDate = exit;
        }

        public override string ToString()
        {
            return $"{HotelGuest.FullName} -> Room {HotelRoom.RoomNumber} ({CheckInDate.ToShortDateString()} - {CheckOutDate.ToShortDateString()})";
        }
    }
}