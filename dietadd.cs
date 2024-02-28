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

    public partial class dietadd : Form
    {
        public dietadd()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void setid()
        {
            SqlConnection sqlconn = null;
            try
            {
                sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                sqlconn.Open();
                string sql = string.Format("select * from diet where num={0}", Main.sid);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    dateTimePicker1.Text=sdr[2].ToString();
                    comboBox1.Text=sdr[3].ToString();
                    textBox1.Text = sdr[4].ToString();
                    textBox_t.Text = sdr[5].ToString();
                    textBox_d.Text = sdr[6].ToString();
                    textBox_z.Text = sdr[7].ToString();
                   
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


        private void dietadd_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "早餐";
            comboBox1.Items.Add ("早餐");
            comboBox1.Items.Add ("中餐");
            comboBox1.Items.Add ("晚餐");
            comboBox1.Items.Add ("宵夜");
            comboBox1.Items.Add ("其他");

            setid();
        }

        private bool ischeck()
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("饮食名称不能为空");
                textBox1.Focus();
                return false;
            }
            if (textBox_t.Text.Trim().Length == 0)
            {
                MessageBox.Show("碳水不能为空");
                textBox_t.Focus();
                return false;
            }
            if (textBox_d.Text.Trim().Length == 0)
            {
                MessageBox.Show("蛋白质不能为空");
                textBox_d.Focus();
                return false;
            }
            if (textBox_z.Text.Trim().Length == 0)
            {
                MessageBox.Show("脂肪不能为空");
                textBox_z.Focus();
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
                        string sql = string.Format("insert into diet values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');",acc.Username,
                            dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox1.Text.Trim(), textBox1.Text.Trim()
                            , textBox_t.Text.Trim(), textBox_d.Text.Trim(), textBox_z.Text.Trim());
                        SqlCommand cmd = new SqlCommand(sql, sqlconn);
                        int jg = cmd.ExecuteNonQuery();
                        if (jg > 0)
                        {
                            MessageBox.Show("记录成功");
                            while (panel1.Controls.Count > 0)
                            {
                                panel1.Controls.Remove(panel1.Controls[0]);
                            }
                            diet f = new diet();
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
                        string sql = string.Format("update  diet set 用户名='{0}',日期='{1}',饮食类型='{2}',饮食名称='{3}',[碳水/g]='{4}',[蛋白质/g]='{5}',[脂肪/g]='{6}'where num='{7}'",
                            acc.Username,dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox1.Text.Trim(), textBox1.Text.Trim()
                            , textBox_t.Text.Trim(), textBox_d.Text.Trim(), textBox_z.Text.Trim(),Main.sid);
                        SqlCommand cmd = new SqlCommand(sql, sqlconn);
                        int jg = cmd.ExecuteNonQuery();
                        if (jg > 0)
                        {
                            MessageBox.Show("记录成功");
                            while (panel1.Controls.Count > 0)
                            {
                                panel1.Controls.Remove(panel1.Controls[0]);
                            }
                            diet f = new diet();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
