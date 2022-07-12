﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almanac
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Authorization authorization = new Authorization();
            Application.Run(authorization);
            if (authorization.User_id != 0)
            {
                Application.Run(new Form1(authorization.User_id));
            }
        }
    }
}
