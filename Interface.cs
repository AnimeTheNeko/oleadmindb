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
    public partial class Interface : Form
    {
        List<string> passwords = new List<string> { };
        public Interface(bool rechte, string username, string password)
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Column0","Username");
            dataGridView1.Columns.Add("Column1", "Passwort");
            DataGridViewCheckBoxColumn Column2 = new DataGridViewCheckBoxColumn();
            Column2.HeaderText = "Rechte";
            dataGridView1.Columns.Add(Column2);

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
                passwords.Add(reader.GetString(1));
                string i="";
                foreach (char item in reader.GetString(1))
                {
                    i += "*";
                }
                dataGridView1.Rows.Add(reader.GetString(0),i,(bool)reader.GetBoolean(2));
            }
            reader.Close();
            con.Close();






            label1.Text += " "+username;
            label2.Text += " " +password;
            checkBox1.Checked = rechte;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            passwords.Clear();


            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column0", "Username");
            dataGridView1.Columns.Add("Column1", "Passwort");
            DataGridViewCheckBoxColumn Column2 = new DataGridViewCheckBoxColumn();
            Column2.HeaderText = "Rechte";
            dataGridView1.Columns.Add(Column2);

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
                passwords.Add(reader.GetString(1));
                string i = "";
                foreach (char item in reader.GetString(1))
                {
                    i += "*";
                }
                dataGridView1.Rows.Add(reader.GetString(0), i, (bool)reader.GetBoolean(2));
            }
            reader.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column0", "Game");
            dataGridView1.Columns.Add("Column1", "Copys");
            dataGridView1.Columns.Add("Column2","Preis");

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string dBbez = @"C:\\Users\\gaimn\\source\\repos\\AnimeTheNeko\\oleadmindb\\Mitarbeiter.mdb";

            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;

            cmd.Connection = con;
            cmd.CommandText = "Select * from Lagerbestand;";

            con.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2));
            }
            reader.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column0", "Person");
            dataGridView1.Columns.Add("Column1", "Product");
            dataGridView1.Columns.Add("Column2", "Preis");
            dataGridView1.Columns.Add("Column2", "Date");

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string dBbez = @"C:\\Users\\gaimn\\source\\repos\\AnimeTheNeko\\oleadmindb\\Mitarbeiter.mdb";

            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;

            cmd.Connection = con;
            cmd.CommandText = "Select * from Kontostand;";

            con.Open();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(3), reader.GetString(4), reader.GetInt32(2),reader.GetDateTime(1).ToString());
            }
            reader.Close();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
