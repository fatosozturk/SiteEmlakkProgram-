using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SiteEmlakkProgramı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-LHJAL90R;Initial Catalog=siteler;Integrated Security=True");
        private void verilerigöster() 
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From sitebilgi", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Kiraz Sitesi")
            {
                BtnKıraz.BackColor = Color.Yellow;
                BtnPapatya.BackColor = Color.Plum;
                BtnGuvercın.BackColor = Color.Plum;
                BtnBezelye.BackColor = Color.Plum;
            }
            if (comboBox1.Text == "Papatya Sitesi")
            {
                BtnKıraz.BackColor = Color.Plum;
                BtnPapatya.BackColor = Color.Yellow;
                BtnGuvercın.BackColor = Color.Plum;
                BtnBezelye.BackColor = Color.Plum;
            }
            if (comboBox1.Text == "Güvercin Sitesi")
            {
                BtnKıraz.BackColor = Color.Plum;
                BtnPapatya.BackColor = Color.Plum;
                BtnGuvercın.BackColor = Color.Yellow;
                BtnBezelye.BackColor = Color.Plum;
            }
            if (comboBox1.Text == "Bezelye Sitesi")
            {
                BtnKıraz.BackColor = Color.Plum;
                BtnPapatya.BackColor = Color.Plum;
                BtnGuvercın.BackColor = Color.Plum;
                BtnBezelye.BackColor = Color.Yellow;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void BtnKydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into sitebilgi (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira) values('" + textBox7.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }
    }
}
