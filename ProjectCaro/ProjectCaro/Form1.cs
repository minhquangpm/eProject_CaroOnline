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
        public Form1()
        {
            InitializeComponent();
            Client.InitClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSignup.Visible = false;
        }
        
        

        //FORM MAP
        private void pnlChess_MouseClick(object sender, MouseEventArgs e)
        {
            //tabMap.Danhco();
        }
        
    }
}
