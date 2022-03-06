using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProje
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public SqlConnection baglanti = new SqlConnection("Server=.;Database=HastaneProje;Integrated Security=true");
 Form1 form = new Form1();
        private void button1_Click(object sender, EventArgs e)
        {   SqlCommand _komut = new SqlCommand();
                _komut.Connection = baglanti;
                _komut.CommandType = CommandType.StoredProcedure;
                _komut.CommandText = "KullaniciAdSorgulama";
                baglanti.Open();
               _komut.Parameters.AddWithValue("Ad", textBox1.Text);
               _komut.ExecuteNonQuery();
                SqlDataReader reader = _komut.ExecuteReader();
                bool isKullaniciAd =    reader.Read();
                baglanti.Close();
      
            if (isKullaniciAd)
            {
             
                MessageBox.Show("Bu kullanıcı adı mevcuttur.Lütfen yeni bir kullanıcı adı giriniz");
                textBox1.Clear();
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "KullaniciEkle";
                    baglanti.Open();
                    komut.Parameters.AddWithValue("KullaniciAdSoyad", textBox1.Text);
                    komut.Parameters.AddWithValue("Sifre", textBox2.Text);
                    komut.Parameters.AddWithValue("Email", textBox3.Text);
                    komut.Parameters.AddWithValue("TelefonNo", textBox4.Text);
                    komut.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    baglanti.Close();
                    this.Hide();
                    form.Show();

                }
                catch
                {
                    MessageBox.Show("Bir şeyler hatalı gitti.Lütfen tekrar deneyiniz");
                    this.Hide();
                    form.Show();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }
    }
}
