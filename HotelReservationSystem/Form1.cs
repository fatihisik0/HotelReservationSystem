using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            // 1. Kutulardan verileri alalım (Hata olursa program çökmesin diye try-catch kullanıyoruz)
            try
            {
                int number = int.Parse(txtRoomNumber.Text);       // Oda numarasını sayıya çevir
                decimal price = decimal.Parse(txtPrice.Text);     // Fiyatı paraya çevir
                                                                  // KONTROL: Oda tipi seçilmiş mi?
                if (cmbRoomType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a room type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Seçilen tipi al (Standard, Deluxe vs.)
                string selectedType = cmbRoomType.SelectedItem.ToString();

                // ODA KONTROLÜ
                foreach (Room existingRoom in lstRooms.Items)
                {
                    if (existingRoom.RoomNumber == number)
                    {
                        MessageBox.Show("Room " + number + " already exists!", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Fonksiyonu durdur, ekleme yapma.
                    }
                }
              

                // 2. selectedType değişkeni
                Room newRoom = new Room(number, selectedType, price);

                // 3. Bu odayı sağdaki ListBox'a ekleyelim
                lstRooms.Items.Add(newRoom);

                // 4. Kutuları temizleyelim 
                txtRoomNumber.Clear();
                txtPrice.Clear();
                cmbRoomType.SelectedIndex = -1;

                // Kullanıcıya bilgi verelim
                MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                // Eğer sayı yerine harf girerse hata mesajı verelim
                MessageBox.Show("Please enter valid numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
   
            // 1. Kutular boş mu? (ID kutusu dahil)
            if (txtCustomerName.Text == "" || txtPhone.Text == "" || txtCustomerId.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Verileri al
                string name = txtCustomerName.Text;
                string phone = txtPhone.Text;
                string id = txtCustomerId.Text; // ID'yi kutudan alıyoruz

                // 3. AYNI ID KONTROLÜ
                foreach (Customer existingGuest in lstCustomers.Items)
                {
                    if (existingGuest.CustomerId == id)
                    {
                        MessageBox.Show("This ID is already registered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 4. Yeni Müşteriyi oluştur 
                Customer newGuest = new Customer(name, id, phone);

                // 5. Listeye ekle
                lstCustomers.Items.Add(newGuest);

                // 6. Temizlik
                txtCustomerName.Clear();
                txtPhone.Clear();
                txtCustomerId.Clear();

                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            // 1. Önce listeden bir ODA ve bir MÜŞTERİ seçilmiş mi diye bakalım
            if (lstRooms.SelectedItem == null || lstCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a Room and a Customer first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Seçilen nesneleri alalım
                Room selectedRoom = (Room)lstRooms.SelectedItem;
                Customer selectedCustomer = (Customer)lstCustomers.SelectedItem;

                // 3. Tarihleri alalım
                DateTime checkIn = dtpCheckIn.Value;
                DateTime checkOut = dtpCheckOut.Value;

                // --- TARİH ÇAKIŞMA KONTROLÜ ---

                // Mantık Hatası Kontrolü (Tarihler ters olamaz)
                if (checkOut.Date <= checkIn.Date)
                {
                    MessageBox.Show("Check-out date must be after Check-in date!", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // LİSTEDEKİ ESKİ REZERVASYONLARI TARIYORUZ
                foreach (Reservation res in lstReservations.Items)
                {
                    // 1. Aynı oda mı?
                    if (res.HotelRoom == selectedRoom)
                    {
                        // 2. Tarihler çakışıyor mu?
                        if (checkIn < res.CheckOutDate && checkOut > res.CheckInDate)
                        {
                            MessageBox.Show("This room is booked for these dates!\n("
                                + res.CheckInDate.ToShortDateString() + " - " + res.CheckOutDate.ToShortDateString() + ")",
                                "Conflict Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Çakışma var, işlemi iptal et
                        }
                    }
                }

                // 4. REZERVASYON Nesnesini oluşturuyoruz
                Reservation newReservation = new Reservation(selectedRoom, selectedCustomer, checkIn, checkOut);

                // 5. Rezervasyonu en alttaki listeye ekleyelim
                lstReservations.Items.Add(newReservation);

                MessageBox.Show("Reservation created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            // 1. Oda seçili mi?
            if (lstRooms.SelectedItem == null)
            {
                MessageBox.Show("Please select a room first!", "Warning");
                return;
            }

            Room selectedRoom = (Room)lstRooms.SelectedItem;
            DateTime checkIn = dtpCheckIn.Value;
            DateTime checkOut = dtpCheckOut.Value;

            bool isAvailable = true;
            string occupiedBy = "";

            // 2. Taramayı Başlat
            foreach (Reservation res in lstReservations.Items)
            {
                if (res.HotelRoom == selectedRoom)
                {
                    // Tarih çakışması var mı?
                    if (checkIn < res.CheckOutDate && checkOut > res.CheckInDate)
                    {
                        isAvailable = false;
                        occupiedBy = res.HotelGuest.CustomerName; // Kimin kaldığını öğreniyoruz
                        break;
                    }
                }
            }

            // 3. Sonucu Söyle
            if (isAvailable)
            {
                MessageBox.Show($"Room {selectedRoom.RoomNumber} is AVAILABLE for these dates!", "Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Room {selectedRoom.RoomNumber} is OCCUPIED by {occupiedBy}!", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
