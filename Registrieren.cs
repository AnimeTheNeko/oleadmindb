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
    public partial class Registrieren : Form
    {
        public Registrieren()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setting.Default.name = textBox1.Text;
            setting.Default.password = textBox2.Text;
            setting.Default.rememberme = true;
            setting.Default.Save();



            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();

                string dBbez = @"C:\\Users\\gaimn\\source\\repos\\AnimeTheNeko\\oleadmindb\\Mitarbeiter.mdb";

                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;


                cmd.Connection = con;

                cmd.CommandText = "INSERT INTO Angestellte ([Username],[passwort]) VALUES (@username,@Password)";
                //add named parameters
                cmd.Parameters.Add("@Username", OleDbType.VarChar, 40).Value = textBox1.Text;
                cmd.Parameters.Add("@passwort", OleDbType.VarChar, 40).Value = textBox2.Text;
                con.Open();
                cmd.ExecuteNonQuery();


                con.Close();

                MessageBox.Show("done!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
