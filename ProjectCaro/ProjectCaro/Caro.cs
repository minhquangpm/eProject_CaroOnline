using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCaro
{
    partial class Caro : Form
    {
        public Caro()
        {
            InitializeComponent();
            InitClient();

            HideTab();

            FullWindow();

            //đổi pass thành *
            txt_Log2.PasswordChar = '*';
            txtPassword.PasswordChar = '*';
            password2.PasswordChar = '*';

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlBorderSignup.Visible = false;
            pnlBorderLogin.Visible = true;
            processBar1.Visible = false;
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
        

        public async void LoadData()
        {
            await Task.Run(() =>
            {
                CaroAPI.FriendList().GetAwaiter().GetResult();
            });
            dataGridView1.DataSource = CaroAPI.getFriendList.data;
        }
        
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
