using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;

namespace Musicinstr
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += output;
            if (!Login.is_director)
            {
                btAdmin.Visible = false;
            }
        }

        private void updateBasket(string ord_id)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                dgvBasket.Rows.Clear(); dgvBasket.Columns.Clear(); int fields = 0;
                dgvBasket.ColumnCount = fields = 5;
                dgvBasket.Columns[0].HeaderText = "ID товара"; dgvBasket.Columns[0].Width = 50;
                dgvBasket.Columns[1].HeaderText = "Название товара"; dgvBasket.Columns[1].Width = 90;
                dgvBasket.Columns[2].HeaderText = "ID заказа"; dgvBasket.Columns[2].Width = 60;
                dgvBasket.Columns[3].HeaderText = "Количество"; dgvBasket.Columns[3].Width = 60;
                dgvBasket.Columns[4].HeaderText = "Общая цена"; dgvBasket.Columns[4].Width = 90;
                string query = "SELECT instr, name, cheque, qty, Sell.price " +
                " FROM Sell JOIN Musicinstr ON instr = music_instr_id "
                + $" WHERE cheque={ord_id}"; int ind = 0;
                NpgsqlCommand find = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    dgvBasket.RowCount++;
                    for (int i = 0; i < fields; i++)
                        dgvBasket[i, ind].Value = dbDataRecord[i].ToString();
                    ind++;
                }
            }
        }
        private void output(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                lbDelivery.Items.Clear();
                string ord_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                updateBasket(ord_id);
            }
        }

        private void show_my_orders()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = "SELECT cheque_id, cheque_date, total_price FROM cheque  " +
                " WHERE total_price> 0 ";
                if (!Login.is_director)
                {
                    query += $" AND worker_id = {Login.empl_id}";
                }
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear(); int fields = 3;
                dataGridView1.ColumnCount = fields;
                dataGridView1.Columns[0].HeaderText = "ID покупки"; dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].HeaderText = "Дата покупки"; dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].HeaderText = "Стоимость"; dataGridView1.Columns[2].Width = 100;
                NpgsqlCommand find = new NpgsqlCommand(query, con); int ind = 0;
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    dataGridView1.RowCount++;
                    dataGridView1[0, ind].Value = dbDataRecord[0].ToString();
                    dataGridView1[1, ind].Value = dbDataRecord[1].ToString().Split(' ')[0];
                    dataGridView1[2, ind].Value = dbDataRecord[2].ToString();
                    ind++;
                }
            }
        }

        private void ShowOrders_Click(object sender, EventArgs e)
        {
            show_my_orders();
        }

        private void IsDone_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Выберите строку в таблице заказов (таблица слева)!");
                return;
            }
            string ord_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = $"UPDATE Orderr SET status_ord='Выдан' WHERE idorder={ord_id}";
                new NpgsqlCommand(query, con).ExecuteNonQuery();
            }
            show_my_orders();
        }

        private void btAdmin_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
        }

        private void btMakeOrder_Click(object sender, EventArgs e)
        {
            makeOrder makeOrder = new makeOrder();
            makeOrder.Show();
        }
    }
}
