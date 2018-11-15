using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectCaro
{
    static class Program
    {
        public static Pen pen;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            pen = new Pen(Color.White);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
