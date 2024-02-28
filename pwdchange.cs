using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 健身运动应用
{
    public partial class pwdchange : Form
    {
        public pwdchange()
        {
            InitializeComponent();
        }

        private void pwdchange_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("原密码不能为空");
                textBox1.Focus();
                return;
            }
            if (textBox1.Text.Trim() != acc.Userpwd)
            {
                MessageBox.Show("原密码不正确，重新输入");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("新密码不能为空");
                textBox2.Focus();
                return;
            }
            if (textBox2.Text.Trim() == acc.Userpwd)
            {
                MessageBox.Show("密码不能与原密码一致");
                textBox3.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("确认密码不能为空");
                textBox3.Focus();
                return;
            }
            if (textBox3.Text.Trim() != textBox2.Text)
            {
                MessageBox.Show("密码不一致");
                textBox3.Focus();
                return;
            }

            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql = string.Format("update account set 密码 ='{0}' where 用户名='{1}'",
                textBox3.Text.Trim(), acc.Username);
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            int jg = cmd.ExecuteNonQuery();
            if (jg > 0)
            {
                acc.Userpwd = textBox3.Text.Trim();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                DialogResult dr = MessageBox.Show("密码修改成功，请重新登录", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
            sqlconn.Close();
        }
    }
}
