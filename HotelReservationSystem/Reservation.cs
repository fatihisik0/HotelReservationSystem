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
        // Senin değişken isimlerini aynen korudum (Form1'de hata vermesin diye)
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


        // Bu metot, nesnenin kendi verilerini kullanarak fiyatı hesaplar.
        public decimal CalculateTotalPrice()
        {
            
            //kalınan süre "4 gün 23 saat" bile olsa sistem bunu tam "5 gün" olarak hesaplayacak.
            TimeSpan duration = CheckOutDate.Date - CheckInDate.Date;

            // Gün sayısını tam sayıya çevir
            int days = (int)duration.TotalDays;

            // Eğer kullanıcı aynı gün girip çıkacaksa veya 0 gün seçerse en az 1 gün ücreti alalım
            if (days < 1) days = 1;

            // Gün Sayısı * Odanın Fiyatı 
            return days * HotelRoom.Price;
        }

        public override string ToString()
        {
            //  listenin sonunda hesaplanan total tutar görünür
            return $"{HotelGuest.CustomerName} -> Room {HotelRoom.RoomNumber} ({CheckInDate.ToShortDateString()} - {CheckOutDate.ToShortDateString()}) | Total: {CalculateTotalPrice()} $";
        }
    }
}