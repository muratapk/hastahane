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
using Microsoft.VisualBasic;

namespace hastakayit
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            db.openConnection();
            doldur();
            groupBox1.Visible = false;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.closeConnection();
        }

        private void doldur()
        {
            string cumle = "Select * from admin";
            db.cmd.CommandText = cumle;
            db.da = new SqlDataAdapter(db.cmd);
            db.ds = new DataSet();
            db.da.Fill(db.ds);
            dataGridView1.DataSource = db.ds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.cmd.Parameters.Clear();
            db.cmd.CommandText = "insert into admin (kul,sifre) values (@kul,@sifre)";
            db.cmd.Parameters.AddWithValue("@kul", textBox1.Text);
            db.cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
            db.cmd.ExecuteNonQuery();
            doldur();
            MessageBox.Show("Kaydınız Eklenmiştir");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.cmd.Parameters.Clear();
            db.cmd.CommandText = "update admin set kul=@kul,sifre=@sifre where Id=@Id";
            db.cmd.Parameters.AddWithValue("@kul", textBox1.Text);
            db.cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
            db.cmd.Parameters.AddWithValue("@Id", textBox3.Text);
            db.cmd.ExecuteNonQuery();
            doldur();
            MessageBox.Show("Kaydınız Eklenmiştir");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.cmd.Parameters.Clear();
            db.cmd.CommandText = "Delete from admin where Id=@Id";
            
            db.cmd.Parameters.AddWithValue("@Id", textBox3.Text);
            db.cmd.ExecuteNonQuery();
            doldur();
            MessageBox.Show("Kaydınız Silinmiştir");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // string ad = Interaction.InputBox("Aranan Kişinin Adı:");
            groupBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                db.cmd.Parameters.Clear();
                string cumle = "Select * from admin where kul like @kul";
                db.cmd.CommandText = cumle;
                db.cmd.Parameters.AddWithValue("@kul", '%'+textBox4.Text+'%');
                db.da = new SqlDataAdapter(db.cmd);
                db.ds = new DataSet();
                db.da.Fill(db.ds);
                dataGridView1.DataSource = db.ds.Tables[0];
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt Bulunamadı");
            }

            
        }
    }
}
