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
    public partial class makeOrder : Form
    {
        private string ord_id;
        private bool is_done;

        private void write_categories(ComboBox cb)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); cb.Items.Clear();
                string query = "Select distinct on (name) name from Type ORDER BY (name)";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    cb.Items.Add(dbDataRecord[0].ToString());
            }
        }

        private void update_Catalog()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = "SELECT music_instr_id, Musicinstr.name, price, count, Type.name, firm, year, shop_id " +
                " FROM Musicinstr JOIN Type ON type = type_id WHERE count> 0 "; int fields = 0; int ind = 0;
                if (!tbName.Text.Equals(""))
                    query += $" AND Musicinstr.name LIKE '%{tbName.Text}%'  ";
                if (!cbCategory.Text.Equals(""))
                    query += $" AND Type.name = '{cbCategory.Text}'  ";
                if (!priceOT.Text.Equals(""))
                    query += $" AND price>={priceOT.Text} ";
                if (!priceDO.Text.Equals(""))
                    query += $" AND price<={priceDO.Text} ";
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = fields = 7;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].HeaderText = "Название"; dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].HeaderText = "Цена"; dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Количество"; dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].HeaderText = "Категория"; dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].HeaderText = "Фирма"; dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].HeaderText = "Год"; dataGridView1.Columns[6].Width = 150;

                NpgsqlCommand find = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    dataGridView1.RowCount++;
                    for (int i = 0; i < fields; i++)
                        dataGridView1[i, ind].Value = dbDataRecord[i].ToString();
                    ind++;
                }
            }
        }

        private void finally_order(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                if (is_done)
                {
                    con.Open(); //Поставить сумму и статус заказа
                    string query = $"Select SUM(price) from Sell WHERE cheque={ord_id}"; int summ=0;
                    NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                    NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        summ = Convert.ToInt32(dbDataRecord[0].ToString());
                    }
                    con.Close(); con.Open();                             
                    query = $"UPDATE Cheque SET total_price={summ} WHERE cheque_id={ord_id}";
                    NpgsqlCommand cmd2 = new NpgsqlCommand(query, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show($"Номер вашего заказа: {ord_id}, сумма: {summ} руб.");
                    return;
                }
                else if (!is_done)
                {
                    cancel();
                }
            }
        }
        private string createOrdNumber()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query = $"INSERT INTO Cheque(cheque_date, worker_id) VALUES (now(), {Login.empl_id});";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteNonQuery(); string ORD = "";
                con.Close(); con.Open();//Теперь находим номер заказа
                query = "Select MAX(cheque_id) from Cheque";
                NpgsqlCommand find = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = find.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    ORD = dbDataRecord[0].ToString();
                }
                if (ORD.Equals("")) throw new Exception();
                return ORD;
            }
        }
        private void cancel()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                MessageBox.Show($"Продажа {ord_id} отклонена.");
                string query = $"Delete from Cheque WHERE cheque_id={ord_id}";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public makeOrder()
        {
            InitializeComponent();
            write_categories(cbCategory);
            update_Catalog();
            this.FormClosed += finally_order;
            is_done = false;
            ord_id = createOrdNumber();
        }

        private void finish_ord_Click(object sender, EventArgs e)
        {
            is_done = true;
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {            
            update_Catalog();
        }

        private void updateBasket()
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

        private void addInBasket_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open();
                    if (dataGridView1.CurrentCell == null) return;
                    if (dataGridView1.CurrentCell.Value == null || dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString().Equals("")) return;
                    string product_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    int price = int.Parse(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                    //if (product_id.Equals("")) return; 
                    int amounce;
                    if (!int.TryParse(cbAmounce.Text, out amounce) || amounce < 1)
                        throw new Exception("Введите количество!");
                    if (Convert.ToInt32(cbAmounce.Text) > Convert.ToInt32(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString()))
                    {
                        throw new Exception("Такого количества товара на складе нет!");
                    }

                    string query = $"INSERT INTO Sell(instr, cheque, qty, price) " +
	                $" VALUES({product_id}, {ord_id}, {amounce}, {amounce*price}); ";
                    //MessageBox.Show(query);
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    updateBasket();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Ошибка! Выберите строку в таблице техники!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //cbAmounce.Items.Clear();
            //int amounce = Convert.ToInt32(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            //for (int i = 1; i <= amounce; i++)
            //{
            //    cbAmounce.Items.Add(i);
            //}
        }

        private void deleteFromBasket_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string product_id = dgvBasket[0, dgvBasket.CurrentCell.RowIndex].Value.ToString();
                string query = $"Delete from Sell WHERE instr={product_id}  AND cheque={ord_id} ";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.ExecuteNonQuery();
                updateBasket();
            }
        }
    }
}
