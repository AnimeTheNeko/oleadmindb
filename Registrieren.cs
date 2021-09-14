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



            //try
            //{
            //    OleDbConnection con = new OleDbConnection();
            //    OleDbCommand cmd = new OleDbCommand();

            //    string dBbez = "Mitarbeiter.mdb";

            //    con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;

            //    cmd.Connection = con;
            //    cmd.CommandText = "Select * from Angestellte;";


            //    con.Open();
            //    int i = 0;
            //    OleDbDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        i = reader.GetInt32(0);
            //    }
            //    reader.Close();
            //    cmd = new OleDbCommand("INSERT INTO Customers (ID, Username,passwort,admin) VALUES (?, ?, ?, ?)", con);

            //    cmd.Parameters.Add("ID", OleDbType.Integer, i++, "ID");
            //    cmd.Parameters.Add("Username", OleDbType.VarChar, 40, "Username");


            //    OleDbDataAdapter adapter = new OleDbDataAdapter();
            //    MessageBox.Show("You have been added");
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }
    }
}
