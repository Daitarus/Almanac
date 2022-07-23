using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almanac
{
    public partial class Registration : Form
    {
        private string connectionString = null;
        public Registration(string _connectionString)
        {
            connectionString = _connectionString;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            User user = new User();
            Database user_db = null;

            label4.Text = "";

            //check textbox
            if (textBox1.Text == "")
            {
                flag = false;
            }
            if (textBox2.Text == "")
            {
                flag = false;
            }
            //create user info
            if (flag)
            {
                user.login = textBox1.Text;
                user.password = textBox2.Text;
                user.bithday = dateTimePicker1.Value;
            }
            else
            {
                label4.Text = "Заполните все данные!";
            }
            //conction DB
            if(flag)
            {
                user_db = new Database(connectionString);
                flag = user_db.FlagConection;
                if(!flag)
                {
                    label4.Text = "Ошибка соединения !!!";
                }
            }
            //check all login
            if (flag)
            {
                User ch_user = user_db.GetUserByLogin(user.login);
                if(user.login==ch_user.login)
                {
                    flag = false;
                }
                if(!flag)
                {
                    label4.Text = "Пользователь с таким логином уже существует !!!";
                }
            }
            //insert user into DB and close DB
            if(flag)
            {
                flag = user_db.InsertUser(user);
                user_db.Close();
                if(flag)
                {
                    MessageBox.Show("Вы успешно зарегистрированы!");
                    this.Close();
                }
                else
                {
                    label4.Text = "Ошибка регистрации !!!";
                }
            }
        }
    }
}
