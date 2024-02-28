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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
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
        }

        private void feedbackbutton_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            feedback f = new feedback();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
        }

        private void waterremainbutton_Click(object sender, EventArgs e)
        {
            while (panel7.Controls.Count > 0)
            {
                panel7.Controls.Remove(panel7.Controls[0]);
            }
            dr f = new dr();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel7.Controls.Add(f);
            f.Show();
        }

        private void recommendbutton_Click(object sender, EventArgs e)
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
        }
    }
}
