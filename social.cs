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
using System.Threading;
namespace 健身运动应用
{
    public partial class social : Form
    {
        
        public social()
        {
            InitializeComponent();
        }
        string purl;
        private void social_Load(object sender, EventArgs e)
        {
            socialupdate();
        }

        int[] fnum = new int[5];
        int[] gsum = new int[5];
        int[] bsum = new int[5];
        int x=0;
        string[] sp = new string[5];
        string[] fi = new string[5];
        string[] di = new string[5];
        string[] co = new string[5];

        int[] value=new int[4];
        private void goodupdate(int i)
        {
            int like = 0;
            int ulike = 0;
            Label[] good = new Label[5] { good1, good2, good3, good4, good5 };
            good[i].Text = Convert.ToString(gsum[i]);
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string query1 = string.Format("SELECT  * FROM [like] where 用户名='{0}'and 动态num='{1}'", acc.Username, fnum[i]);
            SqlCommand command1 = new SqlCommand(query1, sqlconn);
            using (SqlDataReader sdr1 = command1.ExecuteReader())

                if (sdr1.Read())
                {
                    like = Convert.ToInt32(sdr1[3]);
                    ulike = Convert.ToInt32(sdr1[4]);
                    sdr1.Close();
                }
            if (like == 1)
            {
                good[i].Image = Image.FromFile(@"D:\VS实验\健身运动应用\Properties\icon图库\点赞1.png");     
            }
            else
            {
                good[i].Image = Image.FromFile(@"D:\VS实验\健身运动应用\Properties\icon图库\点赞.png");
            }   
        }
        private void badupdate(int i)
        {
            int like = 0;
            int ulike = 0;
            Label[] bad = new Label[5] { bad1, bad2, bad3, bad4, bad5 };
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string query1 = string.Format("SELECT  * FROM [like] where 用户名='{0}'and 动态num='{1}'", acc.Username, fnum[i]);
            SqlCommand command1 = new SqlCommand(query1, sqlconn);
            using (SqlDataReader sdr1 = command1.ExecuteReader())

                if (sdr1.Read())
                {
                    like = Convert.ToInt32(sdr1[3]);
                    ulike = Convert.ToInt32(sdr1[4]);
                    sdr1.Close();
                }
            if (ulike == 1)
            {
                bad[i].Image = Image.FromFile(@"D:\VS实验\健身运动应用\Properties\icon图库\bad1.png");
            }
            else
            {
                bad[i].Image = Image.FromFile(@"D:\VS实验\健身运动应用\Properties\icon图库\bad.png");
            }
            bad[i].Text =Convert.ToString(bsum[i]);
        }

        private void socialupdate()
        {
            PictureBox[] tp = new PictureBox[5] { tp1, tp2, tp3, tp4, tp5 };
            Label[] name = new Label[5] { name1, name2, name3, name4, name5 };
            Label[] text = new Label[5] { text1, text2, text3, text4, text5 };
            PictureBox[] p = new PictureBox[5] { p1, p2, p3, p4, p5 };

            string urltp = null;
            string urlp = null;
            string t = null;
            string n = null;
            int r;

            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                    sqlconn.Open();

            for (int i = 0; i < 5; i++)
            {
                Random random = new Random();
                r = random.Next(0, 100);
                string query1 = string.Format("SELECT  * FROM [user] WHERE 用户名='{0}'", acc.Username);
                SqlCommand command1 = new SqlCommand(query1, sqlconn);
                using (SqlDataReader sdr1 = command1.ExecuteReader())
                    if (sdr1.Read())
                    {
                        value[0] = Convert.ToInt32(sdr1[7]);
                        value[1] = Convert.ToInt32(sdr1[8]);
                        value[2] = Convert.ToInt32(sdr1[9]);
                        value[3] = Convert.ToInt32(sdr1[10]);
                        sdr1.Close();
                    }
  
                int av1 =100* value[0] / (value[0] + value[1] + value[2] + value[3] +200);
                int av2 =100* value[1] / (value[0] + value[1] + value[2] + value[3] +200);
                int av3 =100* value[2] / (value[0] + value[1] + value[2] + value[3] +200);
                int av4 =100* value[3] / (value[0] + value[1] + value[2] + value[3] +200);
                int av5 =100* 200 / (value[0] + value[1] + value[2] + value[3] + 200);

                string query = null;
                if(x==0)
                {
                    if ( r >= 0 && r <= av1)
                    {
                        query = string.Format("SELECT TOP 1 * FROM social WHERE num NOT IN ('{0}','{1}','{2}','{3}','{4}') and 运动='True' ORDER BY NEWID()", fnum[0], fnum[1], fnum[2], fnum[3], fnum[4]);
                    }
                    else if ( r > av1 && r <= av1 + av2)
                    {
                        query = string.Format("SELECT TOP 1 * FROM social WHERE num NOT IN ('{0}','{1}','{2}','{3}','{4}') and 健身='True' ORDER BY NEWID()", fnum[0], fnum[1], fnum[2], fnum[3], fnum[4]);
                    }
                    else if ( r > av1 + av2 && r <= av1 + av2 + av3)
                    {
                        query = string.Format("SELECT TOP 1 * FROM social WHERE num NOT IN ('{0}','{1}','{2}','{3}','{4}') and 饮食='True' ORDER BY NEWID()", fnum[0], fnum[1], fnum[2], fnum[3], fnum[4]);
                    }
                    else if ( r > av1 + av2 + av3 && r <= av1 + av2 + av3 + av4)
                    {
                        query = string.Format("SELECT TOP 1 * FROM social WHERE num NOT IN ('{0}','{1}','{2}','{3}','{4}') and 状态='True' ORDER BY NEWID()", fnum[0], fnum[1], fnum[2], fnum[3], fnum[4]);
                    }
                    else if ( r > av1 + av2 + av3 + av4 && r <= av1 + av2 + av3 + av4 + av5)
                    {
                        query = string.Format("SELECT TOP 1 * FROM social WHERE num NOT IN ('{0}','{1}','{2}','{3}','{4}') ORDER BY NEWID()", fnum[0], fnum[1], fnum[2], fnum[3], fnum[4]);
                    }
                }
                
               /* if (x == 0)
                {
                     query = string.Format("SELECT TOP 1 * FROM social WHERE num NOT IN ('{0}','{1}','{2}','{3}','{4}') ORDER BY NEWID()", fnum[0], fnum[1], fnum[2], fnum[3], fnum[4]);
                }*/
                else if(x == 1)
                {
                     query = "SELECT TOP 1 * FROM social WHERE num = (SELECT MAX(num) FROM social WHERE num NOT IN (SELECT TOP " + i + " num FROM social ORDER BY num DESC)) ORDER BY num DESC";
                }
                if(query!=null)
                {
                    SqlCommand command = new SqlCommand(query, sqlconn);
                    using (SqlDataReader sdr = command.ExecuteReader())
                        if (sdr.Read())
                        {
                            fnum[i] = Convert.ToInt32(sdr[0]);
                            n = Convert.ToString(sdr[1].ToString());
                            urltp = Convert.ToString(sdr[2].ToString());
                            t = Convert.ToString(sdr[3].ToString());
                            urlp = Convert.ToString(sdr[4].ToString());
                            gsum[i] = Convert.ToInt32(sdr[5]);
                            bsum[i] = Convert.ToInt32(sdr[6]);
                            sp[i] = Convert.ToString(sdr[7].ToString());
                            fi[i] = Convert.ToString(sdr[8].ToString());
                            di[i] = Convert.ToString(sdr[9].ToString());
                            co[i] = Convert.ToString(sdr[10].ToString());

                            sdr.Close();
                        }
                }
                else 
                {
                    query = "SELECT TOP 1 * FROM social WHERE num = (SELECT MAX(num) FROM social WHERE num NOT IN (SELECT TOP " + i + " num FROM social ORDER BY num DESC)) ORDER BY num DESC";
                    SqlCommand command = new SqlCommand(query, sqlconn);
                    using (SqlDataReader sdr = command.ExecuteReader())
                        if (sdr.Read())
                        {
                            fnum[i] = Convert.ToInt32(sdr[0]);
                            n = Convert.ToString(sdr[1].ToString());
                            urltp = Convert.ToString(sdr[2].ToString());
                            t = Convert.ToString(sdr[3].ToString());
                            urlp = Convert.ToString(sdr[4].ToString());
                            gsum[i] = Convert.ToInt32(sdr[5]);
                            bsum[i] = Convert.ToInt32(sdr[6]);
                            sp[i] = Convert.ToString(sdr[7].ToString());
                            fi[i] = Convert.ToString(sdr[8].ToString());
                            di[i] = Convert.ToString(sdr[9].ToString());
                            co[i] = Convert.ToString(sdr[10].ToString());

                            sdr.Close();
                        }
                }
                goodupdate(i);
                badupdate(i);
                    if (urltp != null)
                    {
                        tp[i].Image = Image.FromFile(urltp);
                    }
                    if (urlp != null)
                    {
                        p[i].Image = Image.FromFile(urlp);
                    }
                    if (n != null)
                    {
                        name[i].Text = n;         
                    }
                if (t != null)
                {
                    text[i].Text = t+" ";
                }
                if (sp[i]== "True      ")
                {
                    text[i].Text +="#运动";
                }
                if (fi[i]== "True      ")
                {
                    text[i].Text += "#健身";
                }
                if (di[i]== "True      ")
                {
                    text[i].Text +="#饮食";
                }
                if (co[i]== "True      ")
                {
                    text[i].Text +="#状态";
                }

             }             
            sqlconn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //实例化文件夹 并打开它
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            //将选中的图片路径 保存成string类型            
             purl = file.FileName;
            //判断路径是否为空            
            if (purl != null)
            {//借助Image.FromFile(string)转化为图片显示到picturebox控件内                
                this.pictureBox1.Image = Image.FromFile(purl);
            }
           
        }
        private bool ischeck()
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("文字不能为空");
                textBox1.Focus();
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ischeck())
            {  
                    SqlConnection sqlconn = null;
                    try
                    {
                        sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
                        sqlconn.Open();
                        string turl = string.Format("select 头像 from [user] where 用户名='{0}'", acc.Username);
                        string r = null;
                        SqlCommand cmd6 = new SqlCommand(turl, sqlconn);
                        SqlDataReader sdr6 = cmd6.ExecuteReader();
                        if (sdr6.Read())
                        {
                            r = Convert.ToString(sdr6[0].ToString());
                            sdr6.Close();
                        }
                     
                    string sql = string.Format("insert into social values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}');", acc.Username,r,textBox1.Text.Trim(),purl,0,0,checkBox1.Checked,checkBox2.Checked, checkBox3.Checked, checkBox4.Checked);         
                        SqlCommand cmd = new SqlCommand(sql, sqlconn);
                        int jg = cmd.ExecuteNonQuery();
                        if (jg > 0)
                        {
                            MessageBox.Show("发布成功");    
                        }
                        else
                        {
                            MessageBox.Show("发布失败");
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
            x = 1;
            socialupdate();
            pictureBox1.Image = null;
            textBox1.Text = " ";
            purl = null;
            checkBox1.Checked= false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void good(int e)
        {
            int like = 0;
            int ulike = 0;
            string[] t=new string[4];
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string query1 = string.Format("SELECT  * FROM [like] where 用户名='{0}'and 动态num='{1}'", acc.Username,fnum[e]);
            SqlCommand command1 = new SqlCommand(query1, sqlconn);
            using (SqlDataReader sdr1 = command1.ExecuteReader())
                if (sdr1.Read())
                {
                    like = Convert.ToInt32(sdr1[3]);
                    ulike = Convert.ToInt32(sdr1[4]);
                    sdr1.Close();
                }
            if (like == 1)
            {
                string sql = string.Format("update [like] set 喜欢=0 where 用户名='{0}' and 动态num='{1}'",acc.Username,fnum[e]);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                int jg = cmd.ExecuteNonQuery();

                string sql1 = string.Format("update social set 喜欢总数=喜欢总数-1 where  num='{0}'", fnum[e]);
                SqlCommand cmd1 = new SqlCommand(sql1, sqlconn);
                int jg1 = cmd1.ExecuteNonQuery();
               
                string sql2 = string.Format("select* from social  where  num='{0}'", fnum[e]);
                SqlCommand cmd2 = new SqlCommand(sql2, sqlconn);
                using (SqlDataReader sdr = cmd2.ExecuteReader())
                    if (sdr.Read())
                    {
                        gsum[e] = Convert.ToInt32(sdr[5]);
                        t[0]=Convert.ToString(sdr[7]);
                        t[1]=Convert.ToString(sdr[8]);
                        t[2]=Convert.ToString(sdr[9]);
                        t[3]=Convert.ToString(sdr[10]);
                        sdr.Close();
                    }

                if (t[0]== "True      ")
                {
                    string sql3 = string.Format("update [user] set 运动值=运动值-5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[1] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 健身值=健身值-5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[2] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 饮食值=饮食值-5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[3] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 状态值=状态值-5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                goodupdate(e);
            }
            else
            {
                string sql = string.Format("if exists( select * from [like] where 用户名 = '{0}' and 动态num =  '{1}')\n" +
             "begin\n" +
             "    update [like] set 喜欢 =  '{2}' where 用户名 =  '{3}' and 动态num =  '{4}'\n" +
             "end\n" +
             "else\n" +
             "begin\n" +
             "    insert into [like] values ( '{5}', '{6}',  '{7}',  '{8}')\n" +
             "end", acc.Username,fnum[e],1,acc.Username,fnum[e],acc.Username,fnum[e],1,0);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                int jg = cmd.ExecuteNonQuery();

                string sql1 = string.Format("update social set 喜欢总数=喜欢总数+1 where  num='{0}'", fnum[e]);
                SqlCommand cmd1 = new SqlCommand(sql1, sqlconn);
                int jg1 = cmd1.ExecuteNonQuery();

                string sql2 = string.Format("select* from social  where  num='{0}'", fnum[e]);
                SqlCommand cmd2 = new SqlCommand(sql2, sqlconn);
                using (SqlDataReader sdr = cmd2.ExecuteReader())
                    if (sdr.Read())
                    {
                        gsum[e] = Convert.ToInt32(sdr[5]);
                        t[0] = Convert.ToString(sdr[7]);
                        t[1] = Convert.ToString(sdr[8]);
                        t[2] = Convert.ToString(sdr[9]);
                        t[3] = Convert.ToString(sdr[10]);
                        sdr.Close();
                    }

                if (t[0] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 运动值=运动值+5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[1] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 健身值=健身值+5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[2] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 饮食值=饮食值+5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[3] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 状态值=状态值+5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                goodupdate(e);   
            }           
        }

        private void bad(int e)
        {
            int like = 0;
            int ulike = 0;
            string[] t = new string[4];
            SqlConnection sqlconn = new SqlConnection("server=LAPTOP-LJQH2OK2;uid=sa;pwd=123;database=健身运动");
            sqlconn.Open();
            string query1 = string.Format("SELECT  * FROM [like] where 用户名='{0}'and 动态num='{1}'", acc.Username, fnum[e]);
            SqlCommand command1 = new SqlCommand(query1, sqlconn);
            using (SqlDataReader sdr1 = command1.ExecuteReader())
                if (sdr1.Read())
                {
                    like = Convert.ToInt32(sdr1[3]);
                    ulike = Convert.ToInt32(sdr1[4]);
                    sdr1.Close();
                }
            if (ulike == 1)
            {
                string sql = string.Format("update [like] set 不喜欢=0 where 用户名='{0}' and 动态num='{1}'", acc.Username, fnum[e]);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                int jg = cmd.ExecuteNonQuery();

                string sql1 = string.Format("update social set 不喜欢总数=不喜欢总数-1 where  num='{0}'", fnum[e]);
                SqlCommand cmd1 = new SqlCommand(sql1, sqlconn);
                int jg1 = cmd1.ExecuteNonQuery();

                string sql2 = string.Format("select* from social  where  num='{0}'", fnum[e]);
                SqlCommand cmd2 = new SqlCommand(sql2, sqlconn);
                using (SqlDataReader sdr = cmd2.ExecuteReader())
                    if (sdr.Read())
                    {
                        bsum[e] = Convert.ToInt32(sdr[6]);
                        t[0] = Convert.ToString(sdr[7]);
                        t[1] = Convert.ToString(sdr[8]);
                        t[2] = Convert.ToString(sdr[9]);
                        t[3] = Convert.ToString(sdr[10]);
                        sdr.Close();
                    }

                if (t[0] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 运动值=运动值+5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[1] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 健身值=健身值+5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[2] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 饮食值=饮食值+5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[3] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 状态值=状态值+5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }

                badupdate(e);

            }
            else
            {
                string sql = string.Format("if exists( select * from [like] where 用户名 = '{0}' and 动态num =  '{1}')\n" +
             "begin\n" +
             "    update [like] set 不喜欢 =  '{2}' where 用户名 =  '{3}' and 动态num =  '{4}'\n" +
             "end\n" +
             "else\n" +
             "begin\n" +
             "    insert into [like] values ( '{5}', '{6}',  '{7}',  '{8}')\n" +
             "end", acc.Username, fnum[e], 1, acc.Username, fnum[e], acc.Username, fnum[e], 1, 0);
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                int jg = cmd.ExecuteNonQuery();

                string sql1 = string.Format("update social set 不喜欢总数=不喜欢总数+1 where  num='{0}'", fnum[e]);
                SqlCommand cmd1 = new SqlCommand(sql1, sqlconn);
                int jg1 = cmd1.ExecuteNonQuery();

                string sql2 = string.Format("select* from social  where  num='{0}'", fnum[e]);
                SqlCommand cmd2 = new SqlCommand(sql2, sqlconn);
                using (SqlDataReader sdr = cmd2.ExecuteReader())
                    if (sdr.Read())
                    {
                        bsum[e] = Convert.ToInt32(sdr[6]);
                        t[0] = Convert.ToString(sdr[7]);
                        t[1] = Convert.ToString(sdr[8]);
                        t[2] = Convert.ToString(sdr[9]);
                        t[3] = Convert.ToString(sdr[10]);
                        sdr.Close();
                    }

                if (t[0] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 运动值=运动值-5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[1] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 健身值=健身值-5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[2] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 饮食值=饮食值-5 where  用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }
                if (t[3] == "True      ")
                {
                    string sql3 = string.Format("update [user] set 状态值=状态值-5 where 用户名='{0}'", acc.Username);
                    SqlCommand cmd3 = new SqlCommand(sql3, sqlconn);
                    int jg3 = cmd3.ExecuteNonQuery();
                }

                badupdate(e);
            }

        }
        private void good1_Click(object sender, EventArgs e)
        {
            good(0);
        }

        private void good2_Click(object sender, EventArgs e)
        {
            good(1);
        }

        private void good3_Click(object sender, EventArgs e)
        {
            good(2);
        }

        private void good4_Click(object sender, EventArgs e)
        {
            good(3);
        }
        private void good5_Click(object sender, EventArgs e)
        {
            good(4);
        }
        private void bad1_Click(object sender, EventArgs e)
        {
           bad(0);
        }
        private void bad2_Click(object sender, EventArgs e)
        {
            bad(1);
        }

        private void bad3_Click(object sender, EventArgs e)
        {
            bad(2);
        }

        private void bad4_Click(object sender, EventArgs e)
        {
            bad(3);
        }

        private void bad5_Click(object sender, EventArgs e)
        {
            bad(4);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            x = 0;
            socialupdate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void text1_Click(object sender, EventArgs e)
        {

        }
    }
}
