using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using Microsoft.VisualBasic;
namespace hastakayit
{
    public class kutuphane
    {
        private string baglanti = "Data Source=.;Initial Catalog=hastane;Integrated Security=True";
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public DataTable dt;
        public DataSet ds;

        public void openConnection()
        {
            try
            {
                con = new SqlConnection(this.baglanti);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Hata Oluştu"+Ex.Message);
            }
        }

        public void closeConnection()
        {
            try
            {
                con = new SqlConnection(this.baglanti);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Hata Oluştu" + Ex.Message);
            }
        }
        public DataTable doldur(string cumle)
        {
            this.cmd = new SqlCommand(cumle, this.con);
            this.da = new SqlDataAdapter(this.cmd);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            return this.dt;

        }

        public void crud(string cumle)
        {
            try
            {
                this.cmd = new SqlCommand(cumle, this.con);
                this.cmd.ExecuteNonQuery();
                MessageBox.Show("İşlem Başarılı Şekilde Tamamlandı");
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Hata Oluştu" + Ex.Message);
            }
           
        }


    }
}
