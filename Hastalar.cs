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
    public partial class Hastalar : Form
    {
        public Hastalar()
        {
            InitializeComponent();
        }
        AnaIslem islem = new AnaIslem(); 
        private void Hastalar_Load(object sender, EventArgs e)
        {
            islem.dataGridView = dataGridView1;
            dateTimePicker2.MinDate = DateTime.Now;
            dateTimePicker2.MaxDate =  DateTime.Now.AddDays(7);
            comboBox4.SelectedIndex = 0;
            comboBox1.SelectedIndex = 2;
            button1.Text = comboBox4.Text;
            islem.ComboBoxIcerikListele("DoktorListele", comboBox3, "DoktorAdSoyad");
            islem.SiralamaComboBoxIslem(comboBox1, "HastaListeleAZ", "HastaListeleZA", "HastaListele");

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Text=comboBox4.Text;    
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            if (comboBox4.SelectedIndex == 3)
                groupBox1.Visible = true;
            else if (comboBox4.SelectedIndex == 2)
                groupBox2.Visible = true;
            else if (comboBox4.SelectedIndex == 1)
                groupBox2.Visible = true;
            else if (comboBox4.SelectedIndex == 0)
                groupBox2.Visible = !true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            islem.SiralamaComboBoxIslem(comboBox1, "HastaListeleAZ", "HastaListeleZA", "HastaListele");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //İşlem
            if (comboBox4.SelectedIndex ==0 && comboBox3.Text != null)
            {
                //ekleme işlemi
                try
                {

               
                    string doktorId = islem.ComboBoxIcerikNoBul("DoktorNoBul", "DoktorAdSoyad", comboBox3.Text, "DoktorNo");
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = Form1.baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "HastaEkle";
                    komut.Parameters.AddWithValue("HastaAdSoyad", textBox3.Text);
                    komut.Parameters.AddWithValue("TcNo", textBox1.Text);
                    komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("Boy", textBox6.Text);
                    komut.Parameters.AddWithValue("Yas", textBox7.Text);
                    komut.Parameters.AddWithValue("Recete", textBox4.Text);
                    komut.Parameters.AddWithValue("RaporDurumu", textBox8.Text );
                    komut.Parameters.AddWithValue("RandevuTarihi", dateTimePicker2.Text);
                    komut.Parameters.AddWithValue("DoktorNo", doktorId);
                    Form1.baglanti.Open();
                    komut.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    Form1.baglanti.Close();
                }
                catch
                {
                    islem.TersGittiMesaji();
                }
            }
            else if (comboBox4.SelectedIndex == 1 && comboBox3.Text != null)
            {
                string doktorId =islem.ComboBoxIcerikNoBul("DoktorNoBul", "DoktorAdSoyad", comboBox3.Text,"DoktorNo");
                SqlCommand komut = new SqlCommand();
                komut.Connection = Form1.baglanti;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "HastaGuncelleme";
                komut.Parameters.AddWithValue("HastaNo", label9.Text);
                komut.Parameters.AddWithValue("HastaAdSoyad", textBox3.Text);
                komut.Parameters.AddWithValue("TcNo", textBox1.Text);
                komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("Boy", textBox6.Text);
                komut.Parameters.AddWithValue("Yas", textBox7.Text);
                komut.Parameters.AddWithValue("Recete", textBox4.Text);
                komut.Parameters.AddWithValue("RaporDurumu", textBox8.Text);
                komut.Parameters.AddWithValue("RandevuTarihi", dateTimePicker2.Text);
                komut.Parameters.AddWithValue("DoktorNo", doktorId);
                Form1.baglanti.Open();
                komut.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                Form1.baglanti.Close();

            }
            else if (comboBox4.SelectedIndex == 2 && comboBox3.Text != null) {
                try
                {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = Form1.baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "HastaSilme";
                    komut.Parameters.AddWithValue("HastaNo", label9.Text);
                    Form1.baglanti.Open();
                    komut.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    Form1.baglanti.Close();
                }
                catch
                {
                    islem.TersGittiMesaji();
                }

            }
            islem.SiralamaComboBoxIslem(comboBox1, "HastaListeleAZ", "HastaListeleZA", "HastaListele");

        }
  
  
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox2.Visible = true;
            label9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker2.MinDate = Convert.ToDateTime( dataGridView1.CurrentRow.Cells[8].Value);
            comboBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

 
    }
}
