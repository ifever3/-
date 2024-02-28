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
    public partial class fitnessadd : Form
    {
        public fitnessadd()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
     
        }
        private bool ischeck()
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("运动名称不能为空");
                textBox1.Focus();
                return false;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("数据不能为空");
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
                        string sql = string.Format("insert into fitness values ('{0}','{1}','{2}','{3}','{4}');", acc.Username,
                            dateTimePicker1.Value.ToString("yyyy-MM-dd"), textBox1.Text.Trim()
                            , textBox2.Text.Trim(), comboBox1.Text.Trim());
                        SqlCommand cmd = new SqlCommand(sql, sqlconn);
                        int jg = cmd.ExecuteNonQuery();
                        if (jg > 0)
                        {
                            MessageBox.Show("记录成功");
                            while (panel1.Controls.Count > 0)
                            {
                                panel1.Controls.Remove(panel1.Controls[0]);
                            }
                            fitness f = new fitness();
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
                        string sql = string.Format("update  fitness set 用户名='{0}',日期='{1}',健身运动名称='{2}',健身运动数据='{3}',健身运动状态='{4}'where num='{5}';", acc.Username,
                            dateTimePicker1.Value.ToString("yyyy-MM-dd"), textBox1.Text.Trim()
                            , textBox2.Text.Trim(), comboBox1.Text.Trim(),Main.sid);
                        SqlCommand cmd = new SqlCommand(sql, sqlconn);
                        int jg = cmd.ExecuteNonQuery();
                        if (jg > 0)
                        {
                            MessageBox.Show("记录成功");
                            while (panel1.Controls.Count > 0)
                            {
                                panel1.Controls.Remove(panel1.Controls[0]);
                            }
                            fitness f = new fitness();
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

        private void setid()
        {
            SqlConnection sqlconn = null;
            try
            {
                sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                sqlconn.Open();
                string sql = string.Format("select * from fitness where num={0}", Main.sid);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    textBox1.Text = sdr[3].ToString();
                    textBox2.Text = sdr[4].ToString();
                    comboBox1.Text = sdr[5].ToString();
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
        private void fitnessadd_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "良好";
            comboBox1.Items.Add("良好");
            comboBox1.Items.Add("一般");
            comboBox1.Items.Add("稍差");
            comboBox1.Items.Add("差");
            if(Main.sid!=0)
            {
                setid();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
