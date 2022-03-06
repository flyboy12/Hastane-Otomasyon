using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProje
{
    public partial class Dashboard : Form
    {
      public  Form activeForm;
        public Dashboard()
        {
            InitializeComponent();
            button5.Visible = false;

        }   
        AnaIslem islem = new AnaIslem();  
        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;   
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;  
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
            button5.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e) //Rapor Buton
        {
            Raporlama raporlama = new Raporlama();
            OpenChildForm(raporlama);
           
        }

        private void button3_Click(object sender, EventArgs e) //Hastalar Butonu
        {
            bool isData = islem.ComboBoxIcerikVarMi("DoktorListele");
            if (isData)
            { 
            Hastalar hastalar = new Hastalar();
            OpenChildForm(hastalar);
            }
            else
            {
                MessageBox.Show("Doktor tablosunda veri bulunmamaktadır.Lütfen Doktorlara Veri Ekleyiniz");
            }
           
        }
    
        private void button2_Click(object sender, EventArgs e) //Doktorlar Butonu   
        {
            bool isData = islem.ComboBoxIcerikVarMi("PolListele");
            if (isData)
            {
             Doktorlar doktorlar = new Doktorlar();
            OpenChildForm(doktorlar);
            }
            else
            {
                MessageBox.Show("Polikinikler tablosunda veri bulunmamaktadır.Lütfen Polikiliniklere Veri Ekleyiniz");
            }
           
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
               activeForm.Close();
            }
            label1.Text = "ANA SAYFA";
            button5.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)//Polikilinikler
        {

            Polikilinikler polikilinikler = new Polikilinikler();
            OpenChildForm(polikilinikler);
        }
    }
}
