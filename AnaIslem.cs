using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProje
{
    internal class AnaIslem
    {
        DataGridView _dataGridView;
        public DataGridView dataGridView { get{ return _dataGridView; } set { _dataGridView = value;  } }
      public  void Listele(string commandText)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = Form1.baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = commandText;
            Form1.baglanti.Open();
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();

            goruntule.Fill(dt);
            Form1.baglanti.Close();
            _dataGridView.DataSource = dt;
        }
        public bool ComboBoxIcerikVarMi(string commandText)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Form1.baglanti;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = commandText;
            SqlDataReader reader;
            Form1.baglanti.Open();
            reader = command.ExecuteReader();
             bool isData= reader.Read();
            Form1.baglanti.Close();
            return isData;
        }
        public void ComboBoxIcerikListele(string commandText,ComboBox comboBox, string columnName)
        {  SqlCommand command = new SqlCommand();
            command.Connection = Form1.baglanti;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = commandText;
            SqlDataReader reader;
            Form1.baglanti.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox.Items.Add(reader[columnName]);
            }
            Form1.baglanti.Close();
        }
        public void SiralamaComboBoxIslem(ComboBox comboBox, string commandIndex0, string commandIndex1 , string commandIndex2)
        {
          
                if (comboBox.SelectedIndex == 0)
                {
                    Listele(commandIndex0);
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    Listele(commandIndex1);
                }
                else if (comboBox.SelectedIndex == 2)
                {
                   Listele(commandIndex2);
                }
                else
                {
                   Listele(commandIndex0);
                }
            
        }
        public string ComboBoxIcerikNoBul(string commandText,string parametre,string value,string getColumnName)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Form1.baglanti;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = commandText;
            command.Parameters.AddWithValue(parametre, value);
            SqlDataReader reader;
            Form1.baglanti.Open();
            reader = command.ExecuteReader();
            string id ="";
            if (reader.Read())
            {
              id = reader[getColumnName].ToString(); 
            }
          
            Form1.baglanti.Close();
            return id;
          
                    //        SqlCommand command = new SqlCommand();
                    //command.Connection = Form1.baglanti;
                    //command.CommandType = CommandType.StoredProcedure;
                    //command.CommandText = "PolNoBul";
                    //command.Parameters.AddWithValue("Pol", comboBox3.Text);
                    //SqlDataReader reader;
                    //Form1.baglanti.Open();
                    //reader = command.ExecuteReader();
                    //string polId = "";
                    //if (reader.Read())
                    //{
                    //    polId = reader["PolNo"].ToString();
                    //    MessageBox.Show(polId);
                    //}

                    //Form1.baglanti.Close();

        }
        public void TersGittiMesaji()
        {
            MessageBox.Show("Bir şeyler ters gitti");
            Form1.baglanti.Close();

        }
    }
}