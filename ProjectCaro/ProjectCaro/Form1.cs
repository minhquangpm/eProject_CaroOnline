using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Form1 : Form
    {
        //private static TabLogin tabLog = new TabLogin();
        //private static TabHome tabHome = new TabHome();
        //private static TabMap tabMap = new TabMap();
        //private static TabLogin tabLog = new TabLogin();

        public static Banco bc;
        public static Graphics grs;

        public Form1()
        {
            InitializeComponent();

            bc = new Banco(soDong, soCot);
            grs = pnlChess.CreateGraphics();

            Client.InitClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSignup.Visible = false;

            
        }
        
        

        private void txtSignin_Click(object sender, EventArgs e)
        {

        }

        


        //FORM MAP
        private void pnlChess_MouseClick(object sender, MouseEventArgs e)
        {
            //tabMap.Danhco();
        }

        

    }
}
