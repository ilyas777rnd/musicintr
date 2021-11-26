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
    public partial class tableShop : Form
    {
        public tableShop()
        {
            InitializeComponent();
            show();
        }

        private void show()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].HeaderText = "Адрес"; dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].HeaderText = "Телефон"; dataGridView1.Columns[2].Width = 80;
                string query = "SELECT * FROM Shop";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = cmd.ExecuteReader(); int ind = 0;
                if (!reader.HasRows)
                {
                    dataGridView1[0, ind].Value = "Нет данных";
                    return;
                }
                foreach (DbDataRecord dbDataRecord in reader)
                {
                    dataGridView1.RowCount++;
                    dataGridView1[0, ind].Value = dbDataRecord[0].ToString();
                    dataGridView1[1, ind].Value = dbDataRecord[1].ToString();
                    dataGridView1[2, ind].Value = dbDataRecord[2].ToString();
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
                    string query = "SELECT * FROM Shop";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader(); int ind = 0;
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Магазин добавлен, вы можете изменить данные о нем.");
                        return;
                    }
                    con.Close(); con.Open();
                    query = $"INSERT INTO Shop(address, phone) VALUES('{tbAddress.Text}', '{tbPhone.Text}'); ";
                    new NpgsqlCommand(query, con).ExecuteNonQuery();
                    show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open(); string query1 = $"UPDATE Shop SET address = '{tbAddress.Text}', phone= '{tbPhone.Text}' ";
                    query1 += " WHERE shop_id=" + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    NpgsqlCommand cmd = new NpgsqlCommand(query1, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                show();
            }
        }
    }
}
