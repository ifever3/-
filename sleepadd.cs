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
    public partial class sleepadd : Form
    {
        public sleepadd()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void setid()
        {
            SqlConnection sqlconn = null;
            try
            {
                sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                sqlconn.Open();
                string sql = string.Format("select * from sleep where num={0}", Main.sid);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    comboBox2.Text = sdr[5].ToString();
                    textBox2.Text = sdr[4].ToString();
                    comboBox1.Text = sdr[3].ToString();
                    dateTimePicker1.Text = sdr[2].ToString();
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
        private void sleepadd_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "午睡";
            comboBox1.Items.Add("午睡");
            comboBox1.Items.Add("正寝");
            
            comboBox2.Text = "良好";
            comboBox2.Items.Add("良好");
            comboBox2.Items.Add("一般");
            comboBox2.Items.Add("稍差");
            comboBox2.Items.Add("差");

            setid();
        }

        private bool ischeck()
        {
            
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("时长不能为空");
                textBox2.Focus();
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ischeck())
            {
                if (Main.sid == 0)
                {
                    SqlConnection sqlconn = null;
                    try
                    {
                        sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                        sqlconn.Open();
                        string sql = string.Format("insert into sleep values ('{0}','{1}','{2}','{3}','{4}');", acc.Username,
                            dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox1.Text.Trim()
                            , textBox2.Text.Trim(), comboBox2.Text.Trim());
                        SqlCommand cmd = new SqlCommand(sql, sqlconn);
                        int jg = cmd.ExecuteNonQuery();
                        if (jg > 0)
                        {
                            MessageBox.Show("记录成功");
                            while (panel1.Controls.Count > 0)
                            {
                                panel1.Controls.Remove(panel1.Controls[0]);
                            }
                            sleep f = new sleep();
                            f.Dock = DockStyle.Fill;
                            f.TopLevel = false;
                            panel1.Controls.Add(f);
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("记录失败");
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
                else
                {
                    SqlConnection sqlconn = null;
                    try
                    {
                        sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                        sqlconn.Open();
                        string sql = string.Format("update  sleep set 用户名='{0}',日期='{1}',类型='{2}',[睡眠时长(h)]='{3}',睡眠质量='{4}'where num='{5}';", acc.Username,
                            dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox1.Text.Trim()
                            , textBox2.Text.Trim(), comboBox2.Text.Trim(),Main.sid);
                        SqlCommand cmd = new SqlCommand(sql, sqlconn);
                        int jg = cmd.ExecuteNonQuery();
                        if (jg > 0)
                        {
                            MessageBox.Show("记录成功");
                            while (panel1.Controls.Count > 0)
                            {
                                panel1.Controls.Remove(panel1.Controls[0]);
                            }
                            sleep f = new sleep();
                            f.Dock = DockStyle.Fill;
                            f.TopLevel = false;
                            panel1.Controls.Add(f);
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("记录失败");
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
    }
}
