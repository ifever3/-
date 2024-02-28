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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void setid()
        {
            SqlConnection sqlconn = null;
            try
            {
                sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                sqlconn.Open();
                string sql = string.Format("select * from [user] where 用户名='{0}'", acc.Username);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    textBox1.Text = sdr["用户名"].ToString();
                    textBox2.Text = sdr["性别"].ToString();
                    textBox3.Text = sdr["年龄"].ToString();
                    textBox4.Text = sdr["电话"].ToString();
                    textBox5.Text = sdr["地区"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlconn.Close();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sqlconn = null;
            sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql1 = string.Format("update [user] set 用户名='{0}',性别='{1}',年龄='{2}',电话='{3}',地区='{4}' where 用户名='{5}'",
                textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), acc.Username);
            SqlCommand cmd1 = new SqlCommand(sql1, sqlconn);
            int jg1 = cmd1.ExecuteNonQuery();

            string sql2 = string.Format("update diet set 用户名='{0}' where 用户名='{1}'",
                           textBox1.Text.Trim(), acc.Username );
            SqlCommand cmd2 = new SqlCommand(sql2, sqlconn);
            int jg2 = cmd2.ExecuteNonQuery();

            string sql3 = string.Format("update fitness set 用户名='{0}' where 用户名='{1}'",
                            textBox1.Text.Trim(), acc.Username);
            SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
            int jg3 = cmd3.ExecuteNonQuery();

            string sql4 = string.Format("update account set 用户名='{0}' where 用户名='{1}'",
                           textBox1.Text.Trim(), acc.Username);
            SqlCommand cmd4 = new SqlCommand(sql4, sqlconn);
            int jg4 = cmd4.ExecuteNonQuery();

            string sql5= string.Format("update sleep set 用户名='{0}' where 用户名='{1}'",
                            textBox1.Text.Trim(), acc.Username);
            SqlCommand cmd5 = new SqlCommand(sql5, sqlconn);
            int jg5 = cmd5.ExecuteNonQuery();

            if (jg1 > 0)
            {
                acc.Username = textBox1.Text.Trim();
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
            sqlconn.Close();
        }

        private void user_Load(object sender, EventArgs e)
        {
            setid();
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql = string.Format("select 头像 from [user] where 用户名='{0}'", acc.Username);
            string url = null;
            SqlCommand cmd6 = new SqlCommand(sql, sqlconn);
            SqlDataReader sdr6 = cmd6.ExecuteReader();
            if (sdr6.Read())
            {
                url = Convert.ToString(sdr6[0].ToString());
                sdr6.Close();
            }

            if(url != null)
            {
                this.pictureBox1.Image = Image.FromFile(url);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //实例化文件夹 并打开它
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            //将选中的图片路径 保存成string类型            
            string url = file.FileName;
            //判断路径是否为空
            
            if (url != null)
            {//借助Image.FromFile(string)转化为图片显示到picturebox控件内                
                this.pictureBox1.Image = Image.FromFile(url);
            }

            SqlConnection sqlconn = null;
            sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql = string.Format("update [user] set 头像='{0}'where 用户名='{1}'",url,acc.Username);
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            int jg = cmd.ExecuteNonQuery();
            if (jg > 0)
            {
                MessageBox.Show("更改成功");
            }
            else
            {
                MessageBox.Show("更改失败");
            }
            sqlconn.Close();
        }
    }
}

    

