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
    public partial class buying : Form
    {
        int count = 0;
        List<string> gamedetails = new List<string> { };
        string id = "";

        public buying(List<string> row, int ID)
        {
            InitializeComponent();
            gamedetails = row;
            ID++;
            id = ID.ToString();

            dataGridView1.Columns.Add("Column0", "Game");
            dataGridView1.Columns.Add("Column1", "Copys");
            dataGridView1.Columns.Add("Column2", "Preis");
            dataGridView1.Rows.Add(row[0],row[1],row[2]);
            count = int.Parse(row[1]) - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (setting.Default.password == textBox1.Text)
            {
                try
                {

                    OleDbConnection con = new OleDbConnection();


                    string workingDirectory = Environment.CurrentDirectory;
                    string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\Mitarbeiter.mdb";

                    con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;

                    string SqlString = "Update Lagerbestand SET Objekte = @Objekte,Anzahl = @Anzahl, Preis = @Preis WHERE ID = " + id + ";";

                    OleDbCommand cmd = new OleDbCommand(SqlString, con);
                    cmd.Parameters.AddWithValue("@Objekte", gamedetails[0]);
                    cmd.Parameters.AddWithValue("@Anzahl", count);
                    cmd.Parameters.AddWithValue("@Preis", int.Parse(gamedetails[2]));
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    kontoupdate();

                    MessageBox.Show("Thank you for your Purches");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Das passwort war falsch");
            }
        }

        private void kontoupdate()
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();

                string workingDirectory = Environment.CurrentDirectory;
                string dBbez = Directory.GetParent(workingDirectory).Parent.FullName + "\\Mitarbeiter.mdb";

                con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + dBbez;


                cmd.Connection = con;

                cmd.CommandText = "INSERT INTO Kontostand ([Datum],[Geld],[Kunde],[Ware]) VALUES (@Datum,@Geld,@Kunde,@Ware)";
                //add named parameters
                cmd.Parameters.Add("@Datum", OleDbType.DBDate, 40).Value = DateTime.Now;
                cmd.Parameters.Add("@Geld", OleDbType.Currency, 40).Value = Convert.ToInt32(gamedetails[2]);
                cmd.Parameters.Add("@Kunde", OleDbType.VarChar, 40).Value = setting.Default.name;
                cmd.Parameters.Add("@Ware", OleDbType.VarChar, 40).Value = gamedetails[0];
                con.Open();
                cmd.ExecuteNonQuery();


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
