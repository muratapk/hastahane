using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace hastakayit
{
    public class db
    {
        private static string baglanti = "";
        public static SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=hastane;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand("", con);
        public static DataSet ds;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static string sql;

        public static void openConnection()
        {
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }
        
        }

        public static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }
        }

    }
}
