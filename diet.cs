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
    public partial class diet : Form
    {
        public diet()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void diet_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql = string.Format("select * from diet where 用户名='{0}'", acc.Username);//构造一个SQL语句字符串   
            SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
            DataSet ds = new DataSet();//用SqlDataAdapter来获得数据库中的数据，填充至DataSet中
            sda.Fill(ds);//填充表
            dataGridView1.DataSource = ds.Tables[0];//填充到系统的视图中
            sqlconn.Close();//数据库关

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();

            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.FlatStyle = FlatStyle.Popup;  // 设置按钮的外观样式为Flat   
            editButtonColumn.DefaultCellStyle.BackColor = Color.Cornsilk;  // 设置按钮的背景颜色
            editButtonColumn.DefaultCellStyle.ForeColor = Color.DarkBlue;  // 设置按钮的前景颜色
            editButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);  // 设置按钮的字体样式

            dataGridView1.Columns.Add(editButtonColumn);

            // 添加删除按钮列

            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.FlatStyle = FlatStyle.Popup;  // 设置按钮的外观样式为Flat   
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.Cornsilk;  // 设置按钮的背景颜色
            deleteButtonColumn.DefaultCellStyle.ForeColor = Color.DarkBlue;  // 设置按钮的前景颜色
            deleteButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);  // 设置按钮的字体样式
            dataGridView1.Columns.Add(deleteButtonColumn);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string sql = string.Format("select * from diet where 用户名='{0}'and 日期='{1}'", acc.Username, dateTimePicker1.Value.ToString("yyyy-MM-dd"));//构造一个SQL语句字符串   
            SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
            DataSet ds = new DataSet();//用SqlDataAdapter来获得数据库中的数据，填充至DataSet中
            sda.Fill(ds);//填充表

            dataGridView1.DataSource = ds.Tables[0];//填充到系统的视图中
            sqlconn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex < dataGridView1.Columns.Count)
            {
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex < dataGridView1.Rows.Count)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Edit")
                    {
                        int rowIndex = e.RowIndex;
                        Main.sid = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["num"].Value);
                        while (panel1.Controls.Count > 0)
                        {
                            panel1.Controls.Remove(panel1.Controls[0]);
                        }
                        dietadd f = new dietadd();
                        f.Dock = DockStyle.Fill;
                        f.TopLevel = false;
                        panel1.Controls.Add(f);
                        f.Show();
                        // 执行其他操作
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
                    {
                        // 处理删除按钮点击的逻辑
                        int selectedRowIndex = e.RowIndex;
                        Main.sid = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["num"].Value);
                        DialogResult dr = MessageBox.Show("确定要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {


                            SqlConnection sqlconn = null;
                            try
                            {
                                sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                                sqlconn.Open();
                                string sql = string.Format("delete from diet where num={0}", Main.sid);

                                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                                int jg = cmd.ExecuteNonQuery();
                                if (jg > 0)
                                {
                                    MessageBox.Show("删除成功");

                                }
                                else
                                {
                                    MessageBox.Show("删除失败");
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
                        dataGridView1.Rows.RemoveAt(selectedRowIndex);
                    }
                }
            }
        }
    }
}
