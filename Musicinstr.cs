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
    public partial class Musicinstr : Form
    {
        public Musicinstr()
        {
            InitializeComponent();
            write_categories(cbCategory);
            cbField.Items.Add("Наименование");
            cbField.Items.Add("Цена");
            show();
        }

        private void show()
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                con.Open(); int fields = 0;
                dataGridView1.Rows.Clear(); dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = fields = 7;
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].HeaderText = "Название"; dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].HeaderText = "Цена"; dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].HeaderText = "Количество"; dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].HeaderText = "Категория"; dataGridView1.Columns[4].Width = 110;
                dataGridView1.Columns[5].HeaderText = "Фирма"; dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].HeaderText = "Год"; dataGridView1.Columns[6].Width = 80;
                string query = "SELECT music_instr_id, musicinstr.name, price, count, type.name, firm, year, shop_id " +
                " FROM Musicinstr JOIN Type ON type = type_id";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader reader = cmd.ExecuteReader(); int ind = 0;
                foreach (DbDataRecord dbDataRecord in reader)
                {
                    dataGridView1.RowCount++;
                    for (int i = 0; i < fields; i++)
                    {
                        dataGridView1[i, ind].Value = dbDataRecord[i].ToString();
                    }
                    ind++;
                }
            }
        }

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

        private void Add_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open();
                    string query = " INSERT into Musicinstr(name, price, count, type, firm, year, shop_id) " +
                        $" VALUES ('{tbName.Text}', {tbPrice.Text}, 0, type_id('{cbCategory.Text}'),'{tbFirm.Text}', {tbYear.Text}, this_shop()) ";
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

        private void Delete_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                try
                {
                    con.Open(); string id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                    string query = " Delete from Musicinstr WHERE music_instr_id=" + id;
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    show();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                string qeury = "UPDATE Musicinstr SET ";
                try
                {
                    con.Open(); string id = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                        switch (cbField.Text)
                        {
                            case "Наименование":
                                qeury += $" name='{tbNewValue.Text}' ";
                                break;
                            case "Цена":
                                qeury += $" price={tbNewValue.Text} ";
                                break;
                        }
                        qeury += " WHERE music_instr_id=" + id;
                    NpgsqlCommand cmd = new NpgsqlCommand(qeury, con);
                    cmd.ExecuteNonQuery();
                    show();
                }
                catch (Exception ex) { MessageBox.Show(qeury); }
            }
        }
    }
}
