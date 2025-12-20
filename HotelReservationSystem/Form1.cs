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

                // 2. Yeni bir ODA nesnesi (Room Object) oluşturalım
                // (Tip olarak şimdilik 'Standard' dedik, ilerde seçmeli yaparız)
                Room newRoom = new Room(number, "Standard", price);

                // 3. Bu odayı sağdaki ListBox'a ekleyelim
                lstRooms.Items.Add(newRoom);

                // 4. Kutuları temizleyelim ki yeni giriş yapılabilsin
                txtRoomNumber.Clear();
                txtPrice.Clear();

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
            // 1. İsim ve Telefon boş mu diye basit bir kontrol yapalım
            if (txtCustomerName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kodun geri kalanını çalıştırma, dur.
            }

            try
            {
                // 2. Rastgele bir Müşteri ID'si üretelim (Örn: 100 ile 999 arası)
                int randomId = new Random().Next(100, 999);

                // 3. Yeni Müşteri nesnesini oluşturalım
                Customer newGuest = new Customer(randomId, txtCustomerName.Text, txtPhone.Text);

                // 4. Müşteriyi aşağıdaki listeye ekleyelim
                lstCustomers.Items.Add(newGuest);

                // 5. Kutuları temizleyelim
                txtCustomerName.Clear();
                txtPhone.Clear();

                // Bilgi verelim
                MessageBox.Show("Customer added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("An error occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
