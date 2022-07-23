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
    public partial class Authorization : Form
    {
        private int user_id = 0;
        private string connectionString = null;

        public int User_id { get { return user_id; } }

        public Authorization(string _connectionString)
        {
            connectionString = _connectionString;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool flag = true;
            User user = new User();
            Database user_db = null;

            label3.Text = "";

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
            }
            else
            {
                label3.Text = "Заполните все данные!";
            }
            //conction DB
            if (flag)
            {
                user_db = new Database(connectionString);
                flag = user_db.FlagConection;
                if (!flag)
                {
                    label3.Text = "Ошибка соединения !!!";
                }
            }
            //check all login
            if (flag)
            {
                User ch_user = user_db.GetUserByLogin(user.login);
                if ((user.login != ch_user.login) || (user.password != ch_user.password))
                {
                    label3.Text = "Логин или пароль введены не верно !!!";
                    flag = false;
                }
            }
            //connect to user profile
            if (flag)
            {
                Form1 form1 = new Form1(user.id);
                form1.Show();
                user_db.Close();
                //this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration(connectionString);
            registration.Show();
        }
    }
}
