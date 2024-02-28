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
    public partial class daydiet : Form
    {
        public daydiet()
        {
            InitializeComponent();
        }
        //string sumt, sumz, sumd;
        private void button1_Click(object sender, EventArgs e)
        {
          
            if (textBox_t.Text.Trim().Length == 0)
            {
                MessageBox.Show("碳水不能为空");
                textBox_t.Focus();
                return;
            }
            if (textBox_d.Text.Trim().Length == 0)
            {
                MessageBox.Show("蛋白质不能为空");
                textBox_d.Focus();
                return;
            }
            if (textBox_z.Text.Trim().Length == 0)
            {
                MessageBox.Show("脂肪不能为空");
                textBox_z.Focus();
                return;
            }
            Main.t1=textBox_t.Text;
            Main.t2=textBox_d.Text;
            Main.t3=textBox_z.Text;  
            MessageBox.Show("设置成功！！！");
            labeldisplay();
        }
        private void labeldisplay()
        {
            int i = 0, j = 0, k = 0;
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql1 = string.Format("SELECT SUM([碳水/g]) FROM diet where 用户名='{0}'and 日期='{1}'", acc.Username, DateTime.Now.ToString("yyyy-MM-dd"));
            string sql2 = string.Format("SELECT SUM([蛋白质/g]) FROM diet where 用户名='{0}'and 日期='{1}'", acc.Username, DateTime.Now.ToString("yyyy-MM-dd"));
            string sql3 = string.Format("SELECT SUM([脂肪/g]) FROM diet where 用户名='{0}'and 日期='{1}'", acc.Username, DateTime.Now.ToString("yyyy-MM-dd"));
            SqlCommand cmd1 = new SqlCommand(sql1, sqlconn);
            SqlCommand cmd2 = new SqlCommand(sql2, sqlconn);
            SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            if (sdr1.Read())
            {
                if (sdr1[0] is DBNull)
                {
                    i = 0;
                }
                else
                {
                    i = Convert.ToInt32(sdr1[0].ToString());
                }
                sdr1.Close();
            }
            SqlDataReader sdr2 = cmd2.ExecuteReader();

            if (sdr2.Read())
            {
                if (sdr2[0] is DBNull)
                {
                    j = 0;
                }
                else
                {
                    j = Convert.ToInt32(sdr2[0].ToString());
                }
                sdr2.Close();
            }
            SqlDataReader sdr3 = cmd3.ExecuteReader();
            if (sdr3.Read())
            {
                if (sdr3[0] is DBNull)
                {
                    k = 0;
                }
                else
                {
                    k = Convert.ToInt32(sdr3[0].ToString());
                }
                sdr3.Close();

            }
            int a = Convert.ToInt32(textBox_t.Text);
            int b = Convert.ToInt32(textBox_d.Text.Trim());
            int c = Convert.ToInt32(textBox_z.Text.Trim());

            Main.sumt = Convert.ToString(a - i);
            Main.sumd = Convert.ToString(b - j);
            Main.sumz = Convert.ToString(c - k);

            label7.Text = "碳水 " + Main.sumt + "g";
            label8.Text = "蛋白质 " + Main.sumd + "g";
            label9.Text = "脂肪 " + Main.sumz + "g";
        }
        private void daydiet_Load(object sender, EventArgs e)
        {
            textBox_t.Text = Main.t1;
            textBox_d.Text = Main.t2;
            textBox_z.Text = Main.t3;
            if(textBox_d.Text.Trim().Length==0)
            {
                label7.Text = "碳水 " + 0 + "g";
                label8.Text = "蛋白质 " + 0 + "g";
                label9.Text = "脂肪 " + 0 + "g";
            }
            else
            {
                labeldisplay();
            }
           // label7.Text = "碳水 " + Main.sumt + "g";
          //  label8.Text = "蛋白质 " + Main.sumd + "g";
           // label9.Text = "脂肪 " + Main.sumz + "g";
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql = string.Format("select * from diet where 用户名='{0}'and 日期='{1}'", acc.Username, DateTime.Now.ToString("yyyy-MM-dd"));//构造一个SQL语句字符串   
            SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
            DataSet ds = new DataSet();//用SqlDataAdapter来获得数据库中的数据，填充至DataSet中
            sda.Fill(ds);//填充表
            dataGridView1.DataSource = ds.Tables[0];//填充到系统的视图中
            sqlconn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main.sid = 0;
            while (panel1.Controls.Count > 0)
            {
                panel1.Controls.Remove(panel1.Controls[0]);
            }
            dietadd f = new dietadd();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
