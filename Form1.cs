using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class Form1 : Form
    {
        public DataBase db;
        public Form1()
        {
            InitializeComponent();
            db = new DataBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection())
            {
                var rows = db.GetTables().DefaultView;
                comboBox1.DisplayMember = "TABLE_NAME";
                comboBox1.DataSource = rows;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selItem = comboBox1.SelectedItem as DataRowView;
            var tableName = $"{selItem["TABLE_SCHEMA"]}.{selItem["TABLE_NAME"]}";
            var table = db.GetAllItems(tableName);
            dataGridView1.DataSource = table;
        }
    }
}
