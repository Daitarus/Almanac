using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Almanac
{
    public partial class Form2 : Form
    {
        int sX = 700, sY = 600;    string URLCodeTasks = "Data//Profile//CodeTasks"; 
        public Form2(int day, int month, int year)
        {
            
            InitializeComponent();
            //window settings   
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new Size(sX, sY);
            this.StartPosition = FormStartPosition.Manual;
            this.Text = day + "." + month + "." + year;
            //textBox setting
            textBox1.Multiline = true;
            textBox1.Width = sX - 40;
            textBox1.Height = sY - 100;
            textBox1.Location = new System.Drawing.Point(10, 10);
            textBox1.ScrollBars = ScrollBars.Horizontal;
            //button setting
            button1.Text = "Save";
            button1.Size = new Size(150, 30);
            button1.Location = new Point(10, sY - 80);
            button2.Text = "Chancel";
            button2.Size = new Size(150, 30);
            button2.Location = new Point(170, sY - 80);
            DoubleBuffered = true;
            //updata URLCodeTasks
            URLCodeTasks += day + "_" + month + "_" + year;
            //write TextBox
            if (File.Exists(URLCodeTasks))
            {
                string[] fileText = WriteFile.writeFile(URLCodeTasks);
                for (int i = 0; i < fileText.Length; i++)
                {
                    textBox1.Text += fileText[i] + "\r\n";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if(s!="")
            {
                StreamWriter f = new StreamWriter(URLCodeTasks, false);
                f.WriteLine(s);
                f.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
