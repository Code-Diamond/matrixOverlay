using System;
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

        private static Label droplet = new Label();
        private static Label droplet2 = new Label();
        private static Label droplet3 = new Label();
        private static Label droplet4 = new Label();
        private static Label droplet5 = new Label();
        private static Label droplet6 = new Label();
        private static Label droplet7 = new Label();
        private static Label droplet8 = new Label();
        private static Label droplet9 = new Label();
        private static Label droplet10 = new Label();

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

            this.Controls.Add(droplet);
            this.Controls.Add(droplet2);
            this.Controls.Add(droplet3);
            this.Controls.Add(droplet4);
            this.Controls.Add(droplet5);
            this.Controls.Add(droplet6);
            this.Controls.Add(droplet7);
            this.Controls.Add(droplet8);
            this.Controls.Add(droplet9);
            this.Controls.Add(droplet10);

            width = this.Width;
            height = this.Height;

            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 1;
            myTimer.Start();

        }

        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            moveCreeper();
        }

        private static void moveCreeper()
        {
            Random rand = new Random();
            int random = rand.Next(100);
            droplet.Text = "" + (char)rand.Next(100);
            droplet2.Text = "" + (char)rand.Next(100);
            droplet3.Text = "" + (char)rand.Next(100);
            droplet4.Text = "" + (char)rand.Next(100);
            droplet5.Text = "" + (char)rand.Next(100);
            droplet6.Text = "" + (char)rand.Next(100);
            droplet7.Text = "" + (char)rand.Next(100);
            droplet8.Text = "" + (char)rand.Next(100);
            droplet9.Text = "" + (char)rand.Next(100);
            droplet10.Text = "" + (char)rand.Next(100);
            droplet.Location = new Point(x, y);
            droplet2.Location = new Point(x, y - 50);
            droplet3.Location = new Point(x, y - 100);
            droplet4.Location = new Point(x, y - 150);
            droplet5.Location = new Point(x, y - 200);
            droplet6.Location = new Point(x, y - 250);
            droplet7.Location = new Point(x, y - 300);
            droplet8.Location = new Point(x, y - 350);
            droplet9.Location = new Point(x, y - 400);
            droplet10.Location = new Point(x, y - 450);
            droplet.AutoSize = true;
            droplet2.AutoSize = true;
            droplet3.AutoSize = true;
            droplet4.AutoSize = true;
            droplet5.AutoSize = true;
            droplet6.AutoSize = true;
            droplet7.AutoSize = true;
            droplet8.AutoSize = true;
            droplet9.AutoSize = true;
            droplet10.AutoSize = true;
            int fontSize = rand.Next(0) + 50;
            droplet.Font = new Font("Consolas", fontSize);
            droplet2.Font = new Font("Consolas", fontSize);
            droplet3.Font = new Font("Consolas", fontSize);
            droplet4.Font = new Font("Consolas", fontSize);
            droplet5.Font = new Font("Consolas", fontSize);
            droplet6.Font = new Font("Consolas", fontSize);
            droplet7.Font = new Font("Consolas", fontSize);
            droplet8.Font = new Font("Consolas", fontSize);
            droplet9.Font = new Font("Consolas", fontSize);
            droplet10.Font = new Font("Consolas", fontSize);
            droplet.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet2.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet3.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet4.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet5.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet6.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet7.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet8.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet9.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet10.ForeColor = Color.FromArgb(rand.Next(100), rand.Next(156) + 100, rand.Next(156));
            droplet.Padding = new Padding(0);
            droplet2.Padding = new Padding(0);
            droplet3.Padding = new Padding(0);
            droplet4.Padding = new Padding(0);
            droplet5.Padding = new Padding(0);
            droplet6.Padding = new Padding(0);
            droplet7.Padding = new Padding(0);
            droplet8.Padding = new Padding(0);
            droplet9.Padding = new Padding(0);
            droplet10.Padding = new Padding(0);

            if (y < height)
            {
                y += 50;
            }
            else
            {
                y = 0;
                if (x < width)
                {
                    x += 50;
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
