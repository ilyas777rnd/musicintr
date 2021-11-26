using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.Common;

namespace Musicinstr
{
    public partial class tableType : Form
    {
        public tableType()
        {
            InitializeComponent();
        }

        private void show()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].HeaderText = "Название"; dataGridView1.Columns[1].Width = 80;
                string query = "SELECT * FROM Type";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = cmd.ExecuteReader(); int ind = 0;
                foreach (DbDataRecord dbDataRecord in reader)
                {
                    dataGridView1.RowCount++;
                    dataGridView1[0, ind].Value = dbDataRecord[0].ToString();
                    dataGridView1[1, ind].Value = dbDataRecord[1].ToString();
                    ind++;
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open();
                    string query = $"INSERT INTO Type(name) VALUES('{tbName.Text}'); ";
                    Console.WriteLine(query);
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open(); string id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    string query = " Delete from Type WHERE type_id=" + id;
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    show();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open(); string query1 = $"UPDATE Type SET name = {tbName.Text}";
                    query1 += " WHERE type_id=" + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    NpgsqlCommand cmd = new NpgsqlCommand(query1, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                show();
            }
        }
    }
}
