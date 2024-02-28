using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 健身运动应用
{
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void account_Load(object sender, EventArgs e)
        {
            textBox1.Text = acc.Username;
            textBox2.Text = acc.Userid;
            textBox3.Text = "******";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            while (panel1.Controls.Count > 0)
            {
                panel1.Controls.Remove(panel1.Controls[0]);
            }
            pwdchange f = new pwdchange();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }
    }
}
