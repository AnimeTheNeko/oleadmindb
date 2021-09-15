using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace oleadmindb
{
    public partial class Interface : Form
    {
        List<string> passwords = new List<string> { };
        bool mitclick = false;
        public Interface(bool rechte, string username, string password,string ID)
        {
            InitializeComponent();
            mitclick = false;
            panel1.Visible = false;


            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column0", "Game");
            dataGridView1.Columns.Add("Column1", "Copys");
            dataGridView1.Columns.Add("Column2", "Preis");

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\Mitarbeiter.mdb";

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



            inserttext(rechte, username, password, ID);
        }


        private void inserttext(bool rechte, string username, string password, string ID)
        {
            
            if (rechte == false)
            {
                checkBox1.Visible = false;
                checkBox1.Checked = rechte;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                checkBox1.Visible = true;
                checkBox1.Checked = rechte;
            }
            textBox3.Text = ID;
            textBox1.Text += username;
            textBox2.Text += password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            passwords.Clear();
            mitclick = true;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column0", "Username");
            dataGridView1.Columns.Add("Column1", "Passwort");
            DataGridViewCheckBoxColumn Column2 = new DataGridViewCheckBoxColumn();
            Column2.HeaderText = "Rechte";
            dataGridView1.Columns.Add(Column2);

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\Mitarbeiter.mdb";

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
            panel1.Visible = false;
            mitclick = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column0", "Game");
            dataGridView1.Columns.Add("Column1", "Copys");
            dataGridView1.Columns.Add("Column2","Preis");

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\Mitarbeiter.mdb";

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
            panel1.Visible = false;
            mitclick = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column0", "Person");
            dataGridView1.Columns.Add("Column1", "Product");
            dataGridView1.Columns.Add("Column2", "Preis");
            dataGridView1.Columns.Add("Column2", "Date");

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            string workingDirectory = Environment.CurrentDirectory;
            string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\Mitarbeiter.mdb";

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
            
            try
            {
                OleDbConnection con = new OleDbConnection();
                

                string workingDirectory = Environment.CurrentDirectory;
                string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\Mitarbeiter.mdb";

                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;

                string SqlString = "Update Angestellte Set Username = @Username, passwort = @passwort, admin = @admin WHERE ID = "+textBox3.Text+";";

                OleDbCommand cmd = new OleDbCommand(SqlString, con);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@passwort", textBox2.Text);
                cmd.Parameters.AddWithValue("@admin", checkBox1.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Restart to update");
                panel1.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mitclick == true)
            {
                int index = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString(); 
                textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                checkBox1.Checked = bool.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
                index++;
                textBox3.Text = index.ToString();
            }
            else
            {

            }
        }

        private void Interface_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
