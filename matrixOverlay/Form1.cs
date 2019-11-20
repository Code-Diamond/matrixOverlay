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

        private static Label label = new Label();
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

            this.Controls.Add(label);

            width = this.Width;
            height = this.Height;

            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 1;
            myTimer.Start();

        }

        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            moveLabel();
        }

        private static void moveLabel()
        {
            Random rand = new Random();
            int random = rand.Next(99);
            label.Text = ""+(char)random;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            label.Font = new Font("Consolas", 90);
            label.ForeColor = Color.DarkRed;
            label.Padding = new Padding(0);
            if (y < height)
            {
                y += 100;
            }
            else
            {
                y = 0;
                x += 100;
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
