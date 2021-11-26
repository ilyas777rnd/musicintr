using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;

namespace Musicinstr
{
    public partial class Login : Form
    {
        public static string empl_id { get; private set; }
        public static bool is_director { get; private set; }
        private static string connectionString =
        "Server=localhost;Port=7777;User ID=postgres;Password=0000;Database=MusicIntr2;";
        public Login()
        {
            InitializeComponent();
            passw.UseSystemPasswordChar = true;
        }

        public static NpgsqlConnection getConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        private void enter_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = Login.getConnection())
            {
                empl_id = "";
                con.Open(); 
                string password = "", position="";
                if ((log.Text.Equals("Admin") || log.Text.Equals("admin")) && passw.Text.Equals("7777"))
                {
                    AdminForm admin = new AdminForm();
                    admin.Show();
                    return;
                }
                else
                {
                    empl_id = log.Text;
                    string query = "Select password, position from Worker WHERE worker_id=" + empl_id;
                    NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, con);
                    NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        password = Cod.DecodeString(dbDataRecord[0].ToString());
                        position = dbDataRecord[1].ToString();
                    }
                    if (password.Equals(passw.Text))
                    {
                        if (position.Equals("Директор"))
                        {
                            is_director = true;
                        }
                        else
                        {
                            is_director = false;
                        }
                        ManagerForm manager = new ManagerForm();
                        manager.Show();
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                passw.UseSystemPasswordChar = false;
            else passw.UseSystemPasswordChar = true;
        }
    }
}
