using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyAppForDB
{
    public partial class LoginForm : Form
    {
        DataBase dataBase = new DataBase();
        public LoginForm()
        {
            InitializeComponent();
            this.textBoxPassword.AutoSize = false;
            this.textBoxPassword.Size = new Size(this.textBoxPassword.Size.Width, 39);
        }

        public void buttonEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textBoxLogin.Text;       // login: admin
            var passUser = textBoxPassword.Text;     // password: admin

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count== 1)
            {
                MessageBox.Show("Вы успешно вошли", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OperatingForm operatingForm = new OperatingForm();
                this.Hide();
                operatingForm.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Такого аккаунта не существует", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void textBoxPassword_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
