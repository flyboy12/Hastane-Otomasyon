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
    public partial class Doktorlar : Form
    {
        public Doktorlar()
        {
            InitializeComponent();
        }
        AnaIslem islem = new AnaIslem();
        private void Doktorlar_Load(object sender, EventArgs e)
        {
            islem.dataGridView = dataGridView1;  
            islem.Listele("DoktorListele");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;
            button1.Text = comboBox1.Text;        
            islem.ComboBoxIcerikListele("PolListele",comboBox3,"PolAdi");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != null)
            {
                if (comboBox1.SelectedIndex==0)
                {
                    try
                    {
                        MessageBox.Show(comboBox3.Text);
                            string polId = islem.ComboBoxIcerikNoBul("PolNoBul", "Pol", comboBox3.Text, "PolNo");

                        SqlCommand komut = new SqlCommand();
                        komut.Connection = Form1.baglanti;
                        komut.CommandType = CommandType.StoredProcedure;
                        komut.CommandText = "DoktorEkle";

                        komut.Parameters.AddWithValue("DoktorAdiSoyad", textBox3.Text);
                        komut.Parameters.AddWithValue("TcNo", textBox1.Text);
                        komut.Parameters.AddWithValue("UzmanlikAlani", textBox4.Text);
                        komut.Parameters.AddWithValue("Unvan", textBox5.Text);

                        komut.Parameters.AddWithValue("Telefon", textBox6.Text);
                        komut.Parameters.AddWithValue("Adres", textBox7.Text);
                        komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Text);
                        komut.Parameters.AddWithValue("PolNo", polId);
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
                else if (comboBox1.SelectedIndex == 1)
                {
                    try
                    {

                        string polId = islem.ComboBoxIcerikNoBul("PolNoBul", "Pol", comboBox3.Text, "PolNo");
                        SqlCommand komut = new SqlCommand();
                    komut.Connection = Form1.baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "DoktorGuncelleme";
                    komut.Parameters.AddWithValue("DoktorNo", label9.Text);
                    komut.Parameters.AddWithValue("DoktorAdiSoyad", textBox3.Text);
                    komut.Parameters.AddWithValue("TcNo", textBox1.Text);
                    komut.Parameters.AddWithValue("UzmanlikAlani", textBox4.Text);
                    komut.Parameters.AddWithValue("Unvan", textBox5.Text);
                    komut.Parameters.AddWithValue("Telefon", textBox6.Text);
                    komut.Parameters.AddWithValue("Adres", textBox7.Text);
                    komut.Parameters.AddWithValue("DogumTarihi", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("PolNo", polId);
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
                else if (comboBox1.SelectedIndex==2 && label9.Text !=null)
                {
                    try
                    {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = Form1.baglanti;
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "DoktorSil";
                    komut.Parameters.AddWithValue("DoktorNo", label9.Text);
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
                else if (comboBox1.SelectedIndex==3)
                {
                    //TODO ARAMA
                }
              
            }
            //İşlemler
            islem.SiralamaComboBoxIslem(comboBox2,"DoktorListeleAZ","DoktorListeleZA", "DoktorListele");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        groupBox1.Visible = false;
        groupBox2.Visible = false;
           button1.Text= comboBox1.Text;
            if(comboBox1.SelectedIndex==3)
                groupBox1.Visible=true;
            else if(comboBox1.SelectedIndex==2)
                groupBox2.Visible=true;
            else if(comboBox1.SelectedIndex==1)
                groupBox2.Visible = true;
            else if(comboBox1.SelectedIndex==0)
                groupBox2.Visible=!true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            islem.SiralamaComboBoxIslem(comboBox2, "DoktorListeleAZ", "DoktorListeleZA", "DoktorListele");
        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            label9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
           comboBox3.Text= dataGridView1.CurrentRow.Cells[8].Value.ToString();  
        }
          
    }
}
