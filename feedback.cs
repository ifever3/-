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
    public partial class feedback : Form
    {
        public feedback()
        {
            InitializeComponent();
        }

        private void feedback_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                SqlConnection sqlconn = null;

                sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                sqlconn.Open();
                string sql = string.Format("insert into feedback values ('{0}','{1}');", acc.Username, textBox1.Text.Trim());

                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                int jg = cmd.ExecuteNonQuery();
                if (jg > 0)
                {
                    MessageBox.Show("提交成功");
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("提交失败");
                }
            }
            else
            {
                MessageBox.Show("反馈不能为空！！！");
            }
           
        }
    }
}
