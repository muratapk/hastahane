using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastakayit
{
    public partial class HastaTablosu : Form
    {
        public HastaTablosu()
        {
            InitializeComponent();
        }
        kutuphane veri = new kutuphane();
        private void HastaTablosu_FormClosing(object sender, FormClosingEventArgs e)
        {
            veri.closeConnection();
        }

        private void HastaTablosu_Load(object sender, EventArgs e)
        {
            veri.openConnection();
            ziyaret_doldur();
        }

        private void ziyaret_doldur()
        {
            string cumle = "Select * from ziyaret_tablosu";
            comboBox1.DataSource = veri.doldur(cumle);
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "ziyaretDurum";

        }
    }
}
