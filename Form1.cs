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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   static   public  SqlConnection baglanti = new SqlConnection("Server=.;Database=HastaneProje;Integrated Security=true");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "KullaniciGiris";
            baglanti.Open();
            komut.Parameters.AddWithValue("Ad", textBox1.Text);
            komut.Parameters.AddWithValue("Sifre", textBox2.Text);
            komut.ExecuteNonQuery();
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Giriş Başarılı");
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();

            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
        
            baglanti.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit();
            this.Hide();
            kayit.Show();
        }
    }
}
