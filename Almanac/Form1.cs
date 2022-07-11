using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Almanac
{
    public partial class Form1 : Form
    {        
        int sX=600, sY=800; public string[] nameMonth; string[] codeToday;
        static int day = 0, dayW = 0, month = 0, year = 0, hour = 0, minute = 0, sec = 0;        

        public Form1(int user_id)
        {
            InitializeComponent();
            //window settings          
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new Size(sX, sY);
            this.StartPosition = FormStartPosition.Manual;
            DoubleBuffered = true;
            //month number to month string
            nameMonth = WriteFile.writeFile("Data//NameMonthEng");
            //date now
            day = DateTime.Now.Day;
            dayW = (int)DateTime.Now.DayOfWeek;
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            //setting label
            label1.Location = new System.Drawing.Point(sX/2-4*23, sY-550);
            label1.Font = new Font("", 23);
            label2.Location = new System.Drawing.Point(10, sY-55);
            label2.Font = new Font("", 6);
            label2.ForeColor = Color.FromArgb(255, 100, 100, 100);
            label2.Text = "v1.1 alpha";
            //setting pictureBox
            pictureBox1.Location = new System.Drawing.Point(sX / 2 - 200 / 2, 30);
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //start thread time  
            Thread AlgTi = new Thread(AlgTime);           
            CreateButDay();
            AlgTi.Start();
        }
        //close form
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        //thread time
        private  void AlgTime()
        {            
            bool TrDrawYearImg = true; string URLImg = "Data//picture//";
            do
            {
                //updata Date and work algorithm
                Algs.AlgsTime();
                day = Algs.date.Day;
                month = Algs.date.Month;
                year = Algs.date.Year;
                hour = Algs.date.Hour;
                minute = Algs.date.Minute;
                sec = Algs.date.Second;
                //setting pictureBox
                if (TrDrawYearImg)
                {
                    if((month==12)|| (month == 1)|| (month == 2))
                    {
                        URLImg += "0.png";
                    }
                    if ((month == 3) || (month == 4) || (month == 5))
                    {
                        URLImg += "1.png";
                    }
                    if ((month == 6) || (month == 7) || (month == 8))
                    {
                        URLImg += "2.png";
                    }
                    if ((month == 9) || (month == 10) || (month == 11))
                    {
                        URLImg += "3.png";
                    }
                    pictureBox1.Invoke((MethodInvoker)(() => pictureBox1.Image = Image.FromFile(URLImg)));
                    TrDrawYearImg = false;
                }
                label1.Invoke((MethodInvoker)(() => label1.Text = hour + " : " + minute + " : " + sec));                
                Thread.Sleep(20);
            } while (true);
        }
        private void CreateButton(string Text, int x, int y, int sizeW, int sizeH, Image imgBut)
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Controls.Add(this.button1);
            this.button1.Location = new System.Drawing.Point(x, y);
            this.button1.Name = Text;
            this.button1.Size = new System.Drawing.Size(sizeW, sizeH);
            this.button1.TabIndex = 0;
            this.button1.Text = Text;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.BackgroundImage = imgBut;
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int DayBut = 0;
            string msg = ((Button)sender).Name;
            DayBut = Convert.ToInt32(msg);
            Form2 form2 = new Form2(DayBut, month, year);
            form2.Show();
        }
        //create button for month
        private void CreateButDay()
        {
            Image imgBut0 = Image.FromFile("Data\\picture\\imgBut.png"), imgBut1 = Image.FromFile("Data\\picture\\imgBut1.png");
            int i = 0, j = 0, k = dayW; int NM = 0;
           if((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12))
           {
                NM = 31;
           }
           if((month == 4) || (month == 6) || (month == 9) || (month == 11))
           {
                NM = 30;
           }
           if (month == 2)
           {
                if (DateTime.IsLeapYear(year))
                {
                    NM = 29;
                }
                else
                {
                    NM = 28;
                }
           }
            while (i < NM)
            {
                if ((i+1) == day)
                {
                    CreateButton(Convert.ToString(i + 1), 20 + (74 * k - 1) + (7 * (k - 1)), 350 + (74 * j) + (7 * (j - 1)), 74, 74, imgBut1);
                }
                else
                {
                    CreateButton(Convert.ToString(i + 1), 20 + (74 * k - 1) + (7 * (k - 1)), 350 + (74 * j) + (7 * (j - 1)), 74, 74, imgBut0);
                }
                i++;
                k++;
                if(k==7)
                {
                    k = 0;
                    j++;
                }
            }
        }
    }
}

//456+74*4+7*4+20
//20+74*7+7*6+20
