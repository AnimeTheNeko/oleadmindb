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
        public buying(List<string> row)
        {
            InitializeComponent();

            dataGridView1.Columns.Add("Column0", "Game");
            dataGridView1.Columns.Add("Column1", "Copys");
            dataGridView1.Columns.Add("Column2", "Preis");

            dataGridView1.Rows.Add(row[0],row[1],row[2]);
        }
    }
}
