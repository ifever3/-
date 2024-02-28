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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        private void login_1_Click(object sender, EventArgs e)
        {
            if (userid.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户名不能为空");
                userid.Focus();
                return;
            }
            if (password.Text.Trim().Length == 0)
            {
                MessageBox.Show("密码不能为空");
                password.Focus();
                return;
            }
            SqlConnection sqlconn = null;
            try
            {
                sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                sqlconn.Open();
                string sql = string.Format("select 用户名 from 健身运动.dbo.account where 账号='{0}'and 密码='{1}'",
                    userid.Text.Trim(), password.Text.Trim());
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                { 
                    acc.Username=sdr[0].ToString();
                    acc.Userid = userid.Text.Trim();
                    acc.Userpwd = password.Text.Trim();
                    Main f = new Main();
                    f.Show();
                    this.Hide();
                    cmd.Dispose();
                    
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    password.Focus();
                    
                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
            sqlconn.Close();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            translation = true;
            timer1.Start();
        }
        bool translation;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (translation)
            {
                pictureBox8.Left -= 30;

                if (pictureBox8.Left < 0)
                {
                    translation = false;
                    timer1.Stop();
                }
            }
            else
            {
                pictureBox8.Left += 30;

                if (pictureBox8.Left > 250)
                {
                    translation = true;
                    timer1.Stop();
                }
            }
        }
        public int sid = 0;
        private bool ischeck()
        {
            if (usernameadd.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户昵称不能为空");
                usernameadd.Focus();
                return false;
            }
            if (useridadd.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户账号不能为空");
                useridadd.Focus();
                return false;
            }
            if (pswadd.Text.Trim().Length == 0)
            {
                MessageBox.Show("密码不能为空");
                pswadd.Focus();
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ischeck())
            {
                if (sid == 0)
                {
                    SqlConnection sqlconn = null;
                    try
                    {
                        sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                        sqlconn.Open();
                        
                        string query = "SELECT COUNT(*) FROM account WHERE 账号 = @input";
                        SqlCommand command = new SqlCommand(query, sqlconn);
                        command.Parameters.AddWithValue("@input", useridadd.Text.Trim());
                        int count = (int)command.ExecuteScalar(); // 执行查询并返回结果集中的第一行的第一列

                        string query1 = "SELECT COUNT(*) FROM account WHERE 用户名 = @input";
                        SqlCommand command1 = new SqlCommand(query1, sqlconn);
                        command1.Parameters.AddWithValue("@input", usernameadd.Text.Trim());
                        int count1 = (int)command1.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("id已存在");
                        }
                        if(count1 > 0)
                        {
                            MessageBox.Show("用户名已存在");
                        }
                        else
                        {
                            string sql = string.Format("insert into account values ('{0}','{1}','{2}');",
                            usernameadd.Text.Trim(), useridadd.Text.Trim(), pswadd.Text.Trim());
                            SqlCommand cmd = new SqlCommand(sql, sqlconn);
                            string sql1 = string.Format("insert into [user] values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}');",
                                usernameadd.Text.Trim(), null, null, null, null, @"D:\VS实验\健身运动应用\Properties\icon图库\ums-admin.png",200,200,200,200);
                            SqlCommand cmd1 = new SqlCommand(sql1, sqlconn);
                            int jg = cmd.ExecuteNonQuery();
                            int jg1 = cmd1.ExecuteNonQuery();
                            if (jg > 0 && jg1 > 0)
                            {
                                MessageBox.Show("注册成功");
                            }
                            else
                            {
                                MessageBox.Show("注册失败");
                            }

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
                
            }


        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            translation = false;
            timer1.Start();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
