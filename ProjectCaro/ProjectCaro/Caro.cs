using System;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro : Form
    {
        public Caro()
        {
            InitializeComponent();
            InitClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSignup.Visible = false;
        }
    }
}
