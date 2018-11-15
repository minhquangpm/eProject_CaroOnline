using System;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Media;
using System.Text.RegularExpressions;

namespace ProjectCaro
{
    partial class Form1
    {
        private void btnTao_Click(object sender, EventArgs e)
        {
            Client.host_id = Client.user_id;
            Client.CreateRoom(Client.user_id);
            Thread.Sleep(200);
            if (Client.checkCreateRoom)
            {
                //mở map
                LoadMap();
                tabControl.SelectTab(Map);
            }
        }


        private void btnVao_Click(object sender, EventArgs e)
        {
            Client.join_id = Client.user_id;
            Client.room_no = txtSophong.Text;
            Client.JoinRoom(Client.user_id, Client.room_no);
            Thread.Sleep(1000);

            if (Client.checkJoinRoom)
            {
                //mở map
                tabControl.SelectTab(Map);
            }

        }

        //private void InitializeComponent()
        //{
        //    this.tabControl.SuspendLayout();
        //    this.Login.SuspendLayout();
        //    this.panelLogin.SuspendLayout();
        //    this.Home.SuspendLayout();
        //    this.panel3.SuspendLayout();
        //    this.panel2.SuspendLayout();
        //    this.panel1.SuspendLayout();
        //    this.panel4.SuspendLayout();
        //    ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        //    this.SuspendLayout();
        //    // 
        //    // TabHome
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.ClientSize = new System.Drawing.Size(1154, 741);
        //    this.Name = "TabHome";
        //    this.tabControl.ResumeLayout(false);
        //    this.Login.ResumeLayout(false);
        //    this.panelLogin.ResumeLayout(false);
        //    this.panelLogin.PerformLayout();
        //    this.Home.ResumeLayout(false);
        //    this.Home.PerformLayout();
        //    this.panel3.ResumeLayout(false);
        //    this.panel3.PerformLayout();
        //    this.panel2.ResumeLayout(false);
        //    this.panel2.PerformLayout();
        //    this.panel1.ResumeLayout(false);
        //    this.panel1.PerformLayout();
        //    this.panel4.ResumeLayout(false);
        //    this.panel4.PerformLayout();
        //    ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        //    this.ResumeLayout(false);

        //}
    }
}
