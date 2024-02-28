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
    public partial class spre : Form
    {
        
        public spre()
        {

            InitializeComponent();
            string[,] u = new string[3, 4] { { "游泳","徒步","潜水","帆船" }, { "跑步","攀岩","定向越野","自行车环路" }, { "室内乒乓", "室内羽毛球", "室内游泳", "室内网球" } };
            string[] v = new string[]{ "哑铃推胸", "哑铃飞鸟", "杠铃卧推", "哑铃划船", "史密斯推胸", "硬拉", "杠铃深蹲", "引体向上", "反向卷腹", "双杠臂屈伸" };

        }
            
        

        private void spre_Load(object sender, EventArgs e)
        {
            cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
            string[] s = new string[23];//声明string数组存放返回结果  
            string city = "上海";//获得文本框录入的查询城市  
            s = w.getWeatherbyCityName(city);
            if (s[8] == "")
            {
                //  MessageBox.Show("输入错误，请重新输入", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"D:\VS实验\健身运动应用\Properties\weather\weather\" + s[8]);
                pictureBox2.Image = Image.FromFile(@"D:\VS实验\健身运动应用\Properties\weather\weather\" + s[9]);
                label1.Text = "~";
                label11.Text = s[1] + "  " + s[5] + "  " + s[6] ;
                label12.Text = s[11];
            }

            string str = s[6];
            string[,] u = new string[2, 8] { { "游泳", "徒步", "潜水", "帆船" ,"跑步", "攀岩", "定向越野", "自行车环路" }, { "室内乒乓", "室内羽毛球", "室内游泳", "室内网球", "室内自行车", "室内瑜伽", "室内跳绳", "室内健身操" } };
            string[] v = new string[] { "哑铃推胸 6组", "哑铃飞鸟 6组", "杠铃卧推 4组", "哑铃划船 4组", "史密斯推胸 4组", "硬拉 12个", "杠铃深蹲 4组", "引体向上 50个", "反向卷腹 6组", "双杠臂屈伸 4组" };
            if (str.Contains("雨")|| str.Contains("雪")||str.Contains("沙")||str.Contains("霾"))
            {
                label6.Text = v[Main.v];
                label7.Text = v[Main.v + 1];
                label8.Text = v[Main.v + 2];
                label9.Text = u[1, Main.u];
                label10.Text = u[1, Main.u + 1];
            }
            else
            {
                label6.Text = v[Main.v];
                label7.Text = v[Main.v + 1];
                label8.Text = v[Main.v + 2];
                label9.Text = u[0, Main.u];
                label10.Text = u[0, Main.u + 1];
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
