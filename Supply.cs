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
    public partial class Supply : Form
    {
        private Control[] supplier_elems;
        private Control[] supply_elems;
        private Control[] airbill_elems;
        private void updateTables()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open();
                string query1 = "Select * from Provider";
                string query2 = "Select shipment_id, shipment_date, address, phone " +
                " from Shipment JOIN Provider ON provider = provider_id " +
                " ORDER BY shipment_date DESC";
                string query3 = "Select shipment, instr, name, qty, Bill.price " +
                " from Bill JOIN Musicinstr ON instr = music_instr_id "+
                " ORDER BY shipment DESC";
                int fields;
                //1-я таблица - Поставщики
                dataGridView1.Rows.Clear(); dataGridView2.Rows.Clear(); dataGridView3.Rows.Clear();
                dataGridView1.Columns.Clear(); dataGridView2.Columns.Clear(); dataGridView3.Columns.Clear();
                dataGridView1.ColumnCount = fields = 3;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].HeaderText = "Адрес"; dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Телефон"; dataGridView1.Columns[2].Width = 120;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int ind = 0;
                NpgsqlDataReader reader1 = cmd1.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader1)
                {
                    dataGridView1.RowCount++;
                    for (int i = 0; i < fields; i++)
                        dataGridView1[i, ind].Value = dbDataRecord[i].ToString();
                    ind++;
                }
                con.Close(); con.Open();
                //2-я таблица - Поставки
                dataGridView2.ColumnCount = fields = 4;
                dataGridView2.Columns[0].HeaderText = "ID"; dataGridView2.Columns[0].Width = 30;
                dataGridView2.Columns[1].HeaderText = "Дата"; dataGridView2.Columns[1].Width = 70;
                dataGridView2.Columns[2].HeaderText = "Адрес поставщика"; dataGridView2.Columns[2].Width = 80;
                dataGridView2.Columns[3].HeaderText = "Телефон поставщика"; dataGridView2.Columns[3].Width = 70;
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con);
                ind = 0;
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader2)
                {
                    dataGridView2.RowCount++;
                    for (int i = 0; i < fields; i++)
                    {
                        if (i != 1)
                            dataGridView2[i, ind].Value = dbDataRecord[i].ToString();
                        else
                            dataGridView2[1, ind].Value = dbDataRecord[1].ToString().Split(' ')[0];
                    }
                    ind++;
                }
                con.Close(); con.Open();
                //3-я таблица - Накладная
                dataGridView3.ColumnCount = fields = 5;
                dataGridView3.Columns[0].HeaderText = "ID поставки"; dataGridView3.Columns[0].Width = 60;
                dataGridView3.Columns[1].HeaderText = "ID товара"; dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].HeaderText = "Название товара"; dataGridView3.Columns[2].Width = 120;
                dataGridView3.Columns[3].HeaderText = "Количество"; dataGridView3.Columns[3].Width = 70;
                dataGridView3.Columns[4].HeaderText = "Цена у поставщика"; dataGridView3.Columns[4].Width = 100;
                NpgsqlCommand cmd3 = new NpgsqlCommand(query3, con);
                ind = 0;
                NpgsqlDataReader reader3 = cmd3.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in reader3)
                {
                    dataGridView3.RowCount++;
                    for (int i = 0; i < fields; i++)
                    {
                        Console.WriteLine(dbDataRecord[i].ToString());
                        dataGridView3[i, ind].Value = dbDataRecord[i].ToString();
                    }
                    ind++;
                }
            }
        }

        private string getDate()
        {
            string[] date = Calendar.SelectionStart.ToString().Split(' ')[0].Split('.');
            return $"{date[0]}-{date[1]}-{date[2]}";
        }

        private void write_tech(ComboBox cb)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); cb.Items.Clear();
                string query = "Select music_instr_id, name from Musicinstr ORDER BY music_instr_id";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    cb.Items.Add($"{dbDataRecord[0].ToString()} {dbDataRecord[1].ToString()}");
            }
        }
        public Supply()
        {
            InitializeComponent();
            updateTables();
            cbTable.Items.Add("Поставщик");
            cbTable.Items.Add("Поставка");
            cbTable.Items.Add("Накладная");
            write_tech(cbTech);
            supplier_elems = new Control[] { tbAddress, label5, tbPhone, label12 };
            supply_elems = new Control[] { Calendar, label8 };
            airbill_elems = new Control[] { tbAmounce, cbTech, label9, label10, label11, tbPrice };
            foreach (Control item in supplier_elems.Union(supply_elems).Union(airbill_elems))
            {
                item.Visible = false;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "";
                try
                {
                    if (cbTable.Text.Equals("Поставщик"))
                    {
                        query = $" INSERT INTO Provider(address, phone) VALUES ('{tbAddress.Text}','{tbPhone.Text}') ";
                    }
                    else if (cbTable.Text.Equals("Поставка"))
                    {
                        string supplier_id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                        query = $" INSERT into Shipment(shipment_date, provider) VALUES ('{getDate()}', {supplier_id}) ";
                    }
                    else if (cbTable.Text.Equals("Накладная"))
                    {
                        string shipment_id = dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString();
                        string intr_id = cbTech.Text.Split(' ')[0];
                        query = $"insert into Bill (shipment, instr, qty, price) VALUES ({shipment_id},{intr_id},{tbAmounce.Text}, {tbPrice.Text}) ";
                    }
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    updateTables();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbField.Items.Clear();
            foreach (Control item in supplier_elems.Union(supply_elems).Union(airbill_elems))
            {
                item.Visible = false;
            }
            if (cbTable.Text.Equals("Поставщик"))
            {
                foreach (Control item in supplier_elems) item.Visible = true;
                cbField.Items.Add("Адрес");
                cbField.Items.Add("Телефон");
            }
            else if (cbTable.Text.Equals("Поставка"))
            {
                foreach (Control item in supply_elems) item.Visible = true;
                //cbField.Items.Add("Поставщик");
                cbField.Items.Add("Дата");
            }
            else if (cbTable.Text.Equals("Накладная"))
            {
                foreach (Control item in airbill_elems) item.Visible = true;
                //cbField.Items.Add("Количество");
                //cbField.Items.Add("ID поставки");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "";
                try
                {
                    if (cbTable.Text.Equals("Поставщик"))
                    {
                        query = $"Delete from Provider WHERE provider_id={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Поставка"))
                    {
                        query = $"Delete from Shipment WHERE shipment_id={dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Накладная"))
                    {
                        query = $"Delete from Bill WHERE shipment={dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString()} AND instr={dataGridView3[1, dataGridView3.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    updateTables();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void cbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbNewValue.Items.Clear();
        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); string query = "UPDATE ";
                try
                {
                    switch (cbField.Text)
                    {
                        case "Адрес":
                            query += $" Provider SET  address ='{cbNewValue.Text}' ";
                            break;
                        case "Телефон":
                            query += $" Provider SET phone ='{cbNewValue.Text}' ";
                            break;
                        case "Дата":
                            query += $" Shipment SET shipment_date ='{getDate()}'";
                            break;
                        //case "Количество":
                        //    query += $" Airbill SET amounce_airbill = {cbNewValue.Text}";
                        //    break;
                        //case "ID поставки":
                        //    query += $" Airbill SET supply_airbill = {cbNewValue.Text}";
                        //    break;
                    }
                    if (cbTable.Text.Equals("Поставщик"))
                    {
                        query += $" WHERE provider_id={dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Поставка"))
                    {
                        query += $" WHERE shipment_id={dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    else if (cbTable.Text.Equals("Накладная"))
                    {
                        //query += $" WHERE IDairbill={dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString()}";
                    }
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    Console.WriteLine(query);
                    cmd.ExecuteNonQuery();
                    updateTables();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
