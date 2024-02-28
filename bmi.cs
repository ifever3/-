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
    public partial class bmi : Form
    {
        public bmi()
        {
            InitializeComponent();
        }

        private void bmi_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_kg.Text.Trim().Length == 0)
            {
                MessageBox.Show("体重不能为空");
                textBox_kg.Focus();
                return;
            }
            if (textBox_h.Text.Trim().Length == 0)
            {
                MessageBox.Show("身高不能为空");
                textBox_h.Focus();
                return;
            }
            
            double kg = Convert.ToDouble(textBox_kg.Text.Trim());
            double h = Convert.ToDouble(textBox_h.Text.Trim());
            double cu = kg / (2 * h);
            num.Text =Convert.ToString(cu);

            if(cu<18.5)
            {
                res.Text = "营养不良";
            }
            if(cu>24)
            {
                res.Text = "超重";
            }
            if (cu > 28)
            {
                res.Text = "肥胖";
            }
            if (cu > 18.5&&cu<23)
            {
                res.Text = "正常";
            }
        }

        private void num_Click(object sender, EventArgs e)
        {

        }
    }
}
