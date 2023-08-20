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
    public partial class sehirler : Form
    {
        public sehirler()
        {
            InitializeComponent();
        }
        kutuphane veri = new kutuphane();
        private void sehirler_Load(object sender, EventArgs e)
        {
            veri.openConnection();
        }

        private void sehirler_FormClosing(object sender, FormClosingEventArgs e)
        {
            veri.closeConnection();
        }
    }
}
