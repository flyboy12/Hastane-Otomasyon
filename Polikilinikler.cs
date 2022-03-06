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
    public partial class Polikilinikler : Form
    {
        public Polikilinikler()
        {
            InitializeComponent();

        }
        AnaIslem islem = new AnaIslem();    
     
        private void Polikilinikler_Load(object sender, EventArgs e)
        {
            islem.dataGridView = dataGridView1;
            groupBox1.Visible = false;
            label1.Visible = false;
            islem.Listele("PolListele");
            comboBox2.SelectedIndex = 2;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if(comboBox1.SelectedIndex == 3)
            {
                groupBox1.Visible=true;
                groupBox2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                groupBox2.Visible=true;

            }
             else if (comboBox1.SelectedIndex == 1)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;

                groupBox1.Visible=false;
            }
            button1.Text = comboBox1.Text;
        }
  void ComboBoxListele() =>  islem.SiralamaComboBoxIslem(comboBox2, "PolListeleAZ", "PolListeleZA", "PolListele");
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxListele();
        }
        void BoxTemizle()
        {
            textBox1.Clear();
            textBox2.Clear();   
            textBox3.Clear();   
            textBox4.Clear();
            label9.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           if(comboBox1.SelectedIndex == 0)
            {
                try
                {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = Form1.baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PolEkle";
                    Form1.baglanti.Open();
                    komut.Parameters.AddWithValue("PolAdi", textBox1.Text);
                    komut.Parameters.AddWithValue("PolUzmanSayisi", numericUpDown1.Value);
                    komut.Parameters.AddWithValue("PolBaskan", textBox3.Text);
                    komut.Parameters.AddWithValue("PolBasHekim", textBox4.Text);
                    komut.Parameters.AddWithValue("YatakSayisi", numericUpDown2.Value);
                    komut.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    Form1.baglanti.Close();
                

                }
                catch
                {
                    MessageBox.Show("Bir şeyler hatalı gitti.Lütfen tekrar deneyiniz");
                   
                }
            }
           else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = Form1.baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PolGuncelleme";
                    Form1.baglanti.Open();
                    komut.Parameters.AddWithValue("PolNo",label9.Text);
                    komut.Parameters.AddWithValue("PolAdi", textBox1.Text);
                    komut.Parameters.AddWithValue("PolUzmanSayisi", numericUpDown1.Value);
                    komut.Parameters.AddWithValue("PolBaskan", textBox3.Text);
                    komut.Parameters.AddWithValue("PolBasHekim", textBox4.Text);
                    komut.Parameters.AddWithValue("YatakSayisi", numericUpDown2.Value);
                    komut.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    Form1.baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Bir şeyler hatalı gitti.Lütfen tekrar deneyiniz");

                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = Form1.baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "PolSilme";
                    Form1.baglanti.Open();
                    komut.Parameters.AddWithValue("PolNo", label9.Text);
                    komut.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    Form1.baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Bir şeyler hatalı gitti.Lütfen tekrar deneyiniz");

                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                try
                { 
                        //TODO ARAMA İŞLEMİ GELECEK
                }
                catch
                {
                    MessageBox.Show("Bir şeyler hatalı gitti.Lütfen tekrar deneyiniz");

                }
            }
            islem.Listele("PolListele");
            BoxTemizle();   
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            label9.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown1.Value= Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value);
            textBox3.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            numericUpDown2.Value= Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value);
        }
    }
}
