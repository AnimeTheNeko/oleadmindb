using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace oleadmindb
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            if (setting.Default.rememberme == true)
            {
                textBox1.Text = setting.Default.name;
                textBox2.Text = setting.Default.password;
                checkBox1.Checked = true;
            }
            else if (setting.Default.rememberme == false)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            savesetting();


            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string dBbez = @"C:\\Users\\gaimn\\source\\repos\\AnimeTheNeko\\oleadmindb\\Mitarbeiter.mdb";

            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;

            cmd.Connection = con;
            cmd.CommandText = "Select Username,passwort,admin from Angestellte;";

            con.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBox1.Text == reader.GetString(0).ToString())
                {
                    if (textBox2.Text == reader.GetString(1).ToString())
                    {
                        bool rechte = (bool)reader["admin"];
                        this.Hide();
                        Interface form = new Interface(rechte,reader.GetString(0),reader.GetString(1));
                        form.Show();
                        break;
                    }
                }

            }
            reader.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registrieren reg = new Registrieren();
            reg.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            savesetting();
        }

        private void savesetting()
        {
            setting.Default.name = textBox1.Text;
            setting.Default.password = textBox2.Text;
            setting.Default.rememberme = checkBox1.Checked;
            setting.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            savesetting();
        }
    }
}
