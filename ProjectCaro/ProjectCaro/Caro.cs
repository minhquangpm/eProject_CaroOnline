using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro : ShadowedForm
    {
        public Caro()
        {
            InitializeComponent();

            //InitClient();

            HideTab();

            FullWindow();

            LoginLoad();
}

        private void Caro_FormClosing(object sender, FormClosingEventArgs e)
        {
            //workerWaitForPlayer.CancelAsync();
        }

        private void HideTab()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }


        private void FullWindow()
        {
            FormBorderStyle = FormBorderStyle.None;
            tabControl.Dock = DockStyle.Fill;
        }


    }
}
