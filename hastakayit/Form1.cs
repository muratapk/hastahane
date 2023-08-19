using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace hastakayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=hastane;Integrated Security=True");
            string cumle = "Select * from admin where kul=@kul and sifre=@sifre";
            con.Open();
            SqlCommand cmd = new SqlCommand(cumle,con);
            cmd.Parameters.AddWithValue("@kul", textBox1.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                anasayfa yeni = new anasayfa();
                yeni.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
            con.Close();
        }
    }
}
