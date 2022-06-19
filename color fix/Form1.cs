using System;
using System.Windows.Forms;
using AutoItX3Lib;
using System.Runtime.InteropServices;
using System.Threading;

namespace color_fix
{
    public partial class Form1 : Form
    {
        AutoItX3 au3 = new AutoItX3();

        [DllImport("user32.dll")]

        static extern short GetAsyncKeyState(Keys vKey);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread AB = new Thread(AIMBOT) { IsBackground = true };
            AB.Start();

        }
        void AIMBOT()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.XButton2) < 0)
                {
                    try
                    {
                        object pix = au3.PixelSearch(660, 369, 1258, 787, 0xFFDBC3);
                        if (pix.ToString() != "1")
                        {
                            object[] pixCoord = (object[])pix;
                            au3.MouseClick("LEFT", (int)pixCoord[0], (int)pixCoord[1], 1, 1);
                        }
                    }

                    catch { }

                }
                Thread.Sleep(1);
            }
        }
    }
}
