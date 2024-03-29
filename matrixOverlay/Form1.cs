﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace matrixOverlay
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;


        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public static Label[] droplet = new Label[10];
        public static Label[] droplet2 = new Label[10];
        public static Label[] droplet3 = new Label[10];
        public static Label[] droplet4 = new Label[10];
        public static Label[] droplet5 = new Label[10];
        public static Label[] droplet6 = new Label[10];
        public static Label[] droplet7 = new Label[10];
        public static Label[] droplet8 = new Label[10];
        public static Label[][] droplets = new Label[][] { droplet, droplet2, droplet3, droplet4, droplet5, droplet6, droplet7, droplet8 };


        private static int width, height;

        private static int x = 0, y = 0;
        public Form1()
        {
            InitializeComponent();

            SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)(GetWindowLong(this.Handle, GWL_EXSTYLE) ^ WS_EX_LAYERED ^ WS_EX_TRANSPARENT));
            //SetLayeredWindowAttributes(this.Handle, 0, 0, LWA_ALPHA); // set transparency to 50% (128)
            this.TopMost = true; // put it on top

            Bounds = Screen.PrimaryScreen.Bounds;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;


            for(int i = 0; i < droplets.Length; i++)
            {
                for(int j = 0; j < droplets[i].Length; j++)
                {
                    droplets[i][j] = new Label();
                    this.Controls.Add(droplets[i][j]);
                }
            }


            width = this.Width;
            height = this.Height;

            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 1;
            myTimer.Start();

        }

        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            moveDroplet();
        }



        private static void moveDroplet()
        {
            Random rand = new Random();


            for (int i = 0; i < droplets.Length; i++)
            {
                for (int j = 0; j < droplets[i].Length; j++)
                {
                    droplets[i][j].Text = "" + (char)(rand.Next(999));
                    droplets[i][j].Location = new Point(x + (j*200), y - (200 * i));
                    droplets[i][j].AutoSize = true;
                    int fontSize = rand.Next(100) + 50;
                    droplets[i][j].Font = new Font("Consolas", fontSize);
                    droplets[i][j].ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
                    droplets[i][j].Padding = new Padding(0);
                }
            }



            if (y < height)
            {
                y += 50;
            }
            else
            {
                //y = 0;
                if (x < width)
                {
                    //x += 50;
                }
                else
                {
                    x = 0;
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
