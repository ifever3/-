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
    public partial class dr : Form
    {
       
        public dr()
        {
            InitializeComponent();    
            
        }
        public static int t;
        Main mainform = Application.OpenForms.OfType<Main>().FirstOrDefault();
        private void button1_Click(object sender, EventArgs e)
        {
            
            int a=0;
            RadioButton[] r = { radioButton1, radioButton2, radioButton3, radioButton4 };
            for (int i = 1; i < 5; i++)
            {
                if (r[i-1].Checked)
                {
                    Main.Span = new TimeSpan(0, 15*i, 0);
                    t = i;
                    Main.timer6.Interval =1000;
                    Main.timer6.Start();
                    a=1;
                    MessageBox.Show("设置成功");
                    mainform.label6.Visible = true;
                    mainform.label1.Visible = true;
                }
            }
            if(a == 0)
            {
                MessageBox.Show("还未选择时间");
                return;
            } 
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已取消设置");
            Main.timer6.Stop();
            mainform.label6.Visible = false;
            mainform.label1.Visible = false;
        }
    }
}
