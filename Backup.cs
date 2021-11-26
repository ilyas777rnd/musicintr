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
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
            rbOrder.Checked = false;
            rbOrdList.Checked = false;
            show();
        }

        void update_cost(int ord_id, int price, string direction) //Обновляет стоимость заказа при изменении корзины
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                try
                {
                    string query = "UPDATE Cheque SET " +
                    $" total_price = total_price {direction} {price} " +
                    $" WHERE cheque_id = {ord_id}";
                    new NpgsqlCommand(query, con).ExecuteNonQuery();
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        void show()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query1 = "Select * from ChequeH ORDER BY time_edit DESC ";
                string query2 = "Select * from SellH ORDER BY time_edit DESC ";
                int fields;
                //1-я таблица - Заказ
                dataGridView1.Rows.Clear(); dataGridView2.Rows.Clear();
                dataGridView1.Columns.Clear(); dataGridView2.Columns.Clear();
                dataGridView1.ColumnCount = fields = 6; int ind = 0;
                dataGridView1.Columns[0].HeaderText = "ID заказа"; dataGridView1.Columns[0].Width = 90;
                dataGridView1.Columns[1].HeaderText = "Дата заказа"; dataGridView1.Columns[1].Width = 90;
                dataGridView1.Columns[2].HeaderText = "ID сотрудника"; dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].HeaderText = "Полная цена"; dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[4].HeaderText = "Действие"; dataGridView1.Columns[4].Width = 90;
                dataGridView1.Columns[5].HeaderText = "Время"; dataGridView1.Columns[5].Width = 150;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                NpgsqlDataReader reader1 = cmd1.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader1)
                {
                    dataGridView1.RowCount++;
                    for (int col = 0; col < fields; col++)
                    {
                        dataGridView1[col, ind].Value = dbDataRecord[col].ToString();
                    }
                    ind++;
                }
                con.Close(); con.Open();
                //2-я таблица - Состав заказа
                dataGridView2.ColumnCount = fields = 6;
                dataGridView2.Columns[0].HeaderText = "ID товара"; dataGridView2.Columns[0].Width = 60;
                dataGridView2.Columns[1].HeaderText = "ID заказа"; dataGridView2.Columns[1].Width = 60;
                dataGridView2.Columns[2].HeaderText = "Количество"; dataGridView2.Columns[2].Width = 60;
                dataGridView2.Columns[3].HeaderText = "Цена"; dataGridView2.Columns[3].Width = 60;
                dataGridView2.Columns[4].HeaderText = "Действие"; dataGridView2.Columns[4].Width = 90;
                dataGridView2.Columns[5].HeaderText = "Время"; dataGridView2.Columns[5].Width = 90;
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con); ind = 0;
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader2)
                {
                    dataGridView2.RowCount++;
                    for (int col = 0; col < fields; col++)
                    {
                        dataGridView2[col, ind].Value = dbDataRecord[col].ToString();
                    }
                    ind++;
                }
            }
        }

        void backup(int row_ind)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string queryH = "", main_query = "";
                try
                {
                    if (rbOrder.Checked)
                    {
                        if (dataGridView1[4, row_ind].Value.ToString().Equals("INSERT"))
                        {
                            main_query = $"Delete from Cheque WHERE cheque_id={dataGridView1[2, row_ind].Value.ToString()}";
                            Console.WriteLine(main_query);
                            new NpgsqlCommand(main_query, con).ExecuteNonQuery();
                        }
                        else if (dataGridView1[4, row_ind].Value.ToString().Equals("UPDATE"))
                        {
                            string upd_query = "UPDATE Cheque SET " +
                            $" total_price=" + (dataGridView1[3, row_ind].Value.ToString().Equals("") ? "NULL" : dataGridView1[3, row_ind].Value.ToString()) + " " +
                            $" WHERE cheque_id={dataGridView1[0, row_ind].Value.ToString()}";
                            Console.WriteLine(upd_query);
                            new NpgsqlCommand(upd_query, con).ExecuteNonQuery();
                        }
                        else if (dataGridView1[4, row_ind].Value.ToString().Equals("DELETE"))
                        {
                            string query_add = "INSERT INTO Cheque (cheque_id, cheque_date, worker_id, total_price) " +
                            $" VALUES({dataGridView1[0, row_ind].Value.ToString()} " +
                            $", " + (dataGridView1[1, row_ind].Value.ToString().Equals("") ? "NULL" : dataGridView1[1, row_ind].Value.ToString()) + " " +
                            $", " + (dataGridView1[2, row_ind].Value.ToString().Equals("") ? "NULL" : dataGridView1[2, row_ind].Value.ToString()) + " " +
                            $", " + (dataGridView1[3, row_ind].Value.ToString().Equals("") ? "NULL" : dataGridView1[3, row_ind].Value.ToString()) + " )";
                            Console.WriteLine(query_add);
                            new NpgsqlCommand(query_add, con).ExecuteNonQuery();
                        }
                    }
                    else if (rbOrdList.Checked)
                    {
                        if (dataGridView2[4, row_ind].Value.ToString().Equals("INSERT"))
                        {
                            main_query = $"Delete from Sell WHERE instr={dataGridView2[0, row_ind].Value.ToString()} AND cheque={dataGridView2[1, row_ind].Value.ToString()}";
                            new NpgsqlCommand(main_query, con).ExecuteNonQuery();
                            update_cost(int.Parse(dataGridView2[1, row_ind].Value.ToString()), int.Parse(dataGridView2[3, row_ind].Value.ToString()), "-");
                        }
                        else if (dataGridView2[4, row_ind].Value.ToString().Equals("DELETE"))
                        {
                            string ins_query = "INSERT INTO Sell (instr, cheque, qty, price) VALUES (" +
                                $" {dataGridView2[0, row_ind].Value.ToString()} " +
                                $" ,{dataGridView2[1, row_ind].Value.ToString()} " +
                                $" ,{dataGridView2[2, row_ind].Value.ToString()} " +
                                $" ,{dataGridView2[3, row_ind].Value.ToString()} )";
                            //new NpgsqlCommand(queryH, con).ExecuteNonQuery();
                            Console.WriteLine(ins_query);
                            new NpgsqlCommand(ins_query, con).ExecuteNonQuery();
                            update_cost(int.Parse(dataGridView2[1, row_ind].Value.ToString()), int.Parse(dataGridView2[3, row_ind].Value.ToString()), "+");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Таблица не выбрана");
                        return;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void rbOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrdList.Checked == true)
                rbOrdList.Checked = false;   
        }

        private void rbOrdList_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrder.Checked == true)
                rbOrder.Checked = false;
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            try
            {
                int row_index = 0;
                if (rbOrder.Checked == true) row_index = dataGridView1.CurrentCell.RowIndex;
                else if (rbOrdList.Checked == true) row_index = dataGridView2.CurrentCell.RowIndex;
                else throw new Exception("Выберите таблицу!");
                backup(row_index);
                show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
