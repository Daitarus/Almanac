﻿using System;
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

        public int User_id { get { return user_id; } }

        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database user_db = new Database(@"Server=DESKTOP-T0L4M6U\SQLEXPRESS;Database=Almanac_user;Trusted_Connection=True;");
            //authorization
            user_db.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
