using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace oleadmindb
{
    public partial class Auswahl : Form
    {
        string IDe, usernamee, pasworde;
        bool rechtee;
        public Auswahl(bool rechte, string username, string password, string ID)
        {
            IDe = ID;
            usernamee = username;
            pasworde = password;
            rechtee = rechte;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Interface from = new Interface(rechtee, usernamee, pasworde, IDe);
            from.Show();
            Form1 from1 = new Form1();
            from1.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bankinterface bank = new bankinterface();
            bank.Show();
            this.Close();
        }
    }
}
