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
    public partial class Form1 : Form
    {
        private static TabLogin tabLog = new TabLogin();
        public Form1()
        {
            InitializeComponent();
        }
        
        //Form LOgin
        private void btnLogin_Click(object sender, EventArgs e)
        {
            tabLog.btnLogin_Click();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Add(Home);     // add tab as last tab in tabcontrol;
            tabControl1.TabPages.Insert(0, tabPage1);  // or insert it at a specific index

            tabControl1.SelectTab(tabPage1);
        }

        private void processbartime_Tick(object sender, EventArgs e)
        {

        }

    }
}
