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
    public partial class Main : Form
    {
        public static System.Windows.Forms.Timer timer6;

        static public int sid = 0;
        static Random r = new Random();
        static public string sumz, sumd, sumt,t1,t2,t3;
        static public int 
        v = r.Next(0, 8),
        u = r.Next(0, 6);
        public Main()
        {
            InitializeComponent();
            home f = new home();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();

            timer6 = new System.Windows.Forms.Timer();
            timer6.Interval = 1000; 
            timer6.Tick += new EventHandler(timer6_Tick); 
        }

        private bool isTimeUp = false;
        public static TimeSpan Span = new TimeSpan(0, 0, 10);
      private void timer6_Tick(object sender, EventArgs e)
      {
          
            Span = Span.Subtract(new TimeSpan(0, 0, 1));
            label6.Text = Span.Hours.ToString() + ":" + Span.Minutes.ToString() + ":" + Span.Seconds.ToString();//时间格式0：0：10
            if (Span.TotalSeconds < 0.0 && !isTimeUp) // 当倒计时结束并且消息框未显示时
            {
                isTimeUp = true; // 将标志设置为 true，表示倒计时已结束
                timer6.Enabled = false; // 停止计时器
                MessageBox.Show("时间到了，该喝水了喂！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Span = new TimeSpan(0, dr.t*15, 00); // 重置倒计时为 10 秒                        
                isTimeUp = false; // 重置标志以便下一次计时结束时显示消息框
                timer6.Enabled = true; // 重新启动计时器
            }
        }


        Point downPoint;
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            Point FrmP = new Point(menu.Left, menu.Top);
            Point ScreenP = this.PointToScreen(FrmP);
            downPoint = new Point(e.X, e.Y);
        }
        // 当鼠标移动是，改变窗体位置
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Location = new Point(Location.X + e.X - downPoint.X, Location.Y + e.Y - downPoint.Y);
        }

        bool expend1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expend1)
            {
                panel2.Height -= 20;

                if (panel2.Height == panel2.MinimumSize.Height)
                {
                    expend1 = false;
                    timer1.Stop();
                }
            }
            else
            {
                panel2.Height += 20;

                if (panel2.Height == panel2.MaximumSize.Height)
                {
                    expend1 = true;
                    timer1.Stop();
                }
            }

        }
        bool expend2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (expend2)
            {
                panel3.Height -= 20;

                if (panel3.Height == panel3.MinimumSize.Height)
                {
                    expend2 = false;
                    timer2.Stop();
                }
            }
            else
            {
                panel3.Height += 20;

                if (panel3.Height == panel3.MaximumSize.Height)
                {
                    expend2 = true;
                    timer2.Stop();
                }
            }
        }
        bool expend3;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (expend3)
            {
                panel4.Height -= 20;

                if (panel4.Height == panel4.MinimumSize.Height)
                {
                    expend3 = false;
                    timer3.Stop();
                }
            }
            else
            {
                panel4.Height += 20;

                if (panel4.Height == panel4.MaximumSize.Height)
                {
                    expend3 = true;
                    timer3.Stop();
                }
            }
        }
        bool expend4;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (expend4)
            {
                panel5.Height -= 20;

                if (panel5.Height == panel5.MinimumSize.Height)
                {
                    expend4 = false;
                    timer4.Stop();
                }
            }
            else
            {
                panel5.Height += 20;

                if (panel5.Height == panel5.MaximumSize.Height)
                {
                    expend4 = true;
                    timer4.Stop();
                }
            }
        }
        bool expend5;
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (expend5)
            {
                flowLayoutPanel1.Width -= 30;

                if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
                {
                    expend5 = false;
                    timer5.Stop();
                }
            }
            else
            {
                flowLayoutPanel1.Width += 30;

                if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                {
                    expend5 = true;
                    timer5.Stop();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            user f = new user();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer1.Start();
            }
           
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
            {
                timer5.Start();
            }
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            if(flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer2.Start();
            }
            
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
            {
                timer5.Start();
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            timer5.Start();
        }
       


        private void button9_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer3.Start();
            }

            if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
            {
                timer5.Start();
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer4.Start();
            }
            
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
            {
                timer5.Start();
            }
        }
     
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();   
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bmibutton_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            bmi f = new bmi();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

        private void home_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            home f = new home();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }

            linkLabel1.Text = acc.Username;

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
            if (url != null)
            {
                this.pictureBox1.Image = Image.FromFile(url);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            user f = new user();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            social f = new social();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            spre f = new spre();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            fitness f = new fitness();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            diet f = new diet();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            daydiet f = new daydiet();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            sleep f = new sleep();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            account f = new account();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
            if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
            {
                timer5.Start();
            }
        }

       private void Main_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = acc.Username;
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
            if (url != null)
            {
                this.pictureBox1.Image = Image.FromFile(url);
            }
          
        }
    }
}
