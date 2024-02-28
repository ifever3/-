namespace 健身运动应用
{
    partial class home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel7 = new System.Windows.Forms.Panel();
            this.recommendbutton = new System.Windows.Forms.Button();
            this.feedbackbutton = new System.Windows.Forms.Button();
            this.bmibutton = new System.Windows.Forms.Button();
            this.waterremainbutton = new System.Windows.Forms.Button();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.recommendbutton);
            this.panel7.Controls.Add(this.feedbackbutton);
            this.panel7.Controls.Add(this.bmibutton);
            this.panel7.Controls.Add(this.waterremainbutton);
            this.panel7.Location = new System.Drawing.Point(0, 1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1067, 587);
            this.panel7.TabIndex = 13;
            // 
            // recommendbutton
            // 
            this.recommendbutton.BackColor = System.Drawing.Color.LightYellow;
            this.recommendbutton.FlatAppearance.BorderSize = 0;
            this.recommendbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recommendbutton.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recommendbutton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.recommendbutton.Image = global::健身运动应用.Properties.Resources.业务推荐;
            this.recommendbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.recommendbutton.Location = new System.Drawing.Point(130, 53);
            this.recommendbutton.Name = "recommendbutton";
            this.recommendbutton.Size = new System.Drawing.Size(378, 200);
            this.recommendbutton.TabIndex = 10;
            this.recommendbutton.Text = "今日运动推荐";
            this.recommendbutton.UseVisualStyleBackColor = false;
            this.recommendbutton.Click += new System.EventHandler(this.recommendbutton_Click);
            // 
            // feedbackbutton
            // 
            this.feedbackbutton.BackColor = System.Drawing.Color.LightYellow;
            this.feedbackbutton.FlatAppearance.BorderSize = 0;
            this.feedbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.feedbackbutton.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.feedbackbutton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.feedbackbutton.Image = global::健身运动应用.Properties.Resources.意见反馈;
            this.feedbackbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.feedbackbutton.Location = new System.Drawing.Point(576, 319);
            this.feedbackbutton.Name = "feedbackbutton";
            this.feedbackbutton.Size = new System.Drawing.Size(378, 200);
            this.feedbackbutton.TabIndex = 11;
            this.feedbackbutton.Text = "用户反馈";
            this.feedbackbutton.UseVisualStyleBackColor = false;
            this.feedbackbutton.Click += new System.EventHandler(this.feedbackbutton_Click);
            // 
            // bmibutton
            // 
            this.bmibutton.BackColor = System.Drawing.Color.LightYellow;
            this.bmibutton.FlatAppearance.BorderSize = 0;
            this.bmibutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bmibutton.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bmibutton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bmibutton.Image = global::健身运动应用.Properties.Resources.计算;
            this.bmibutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bmibutton.Location = new System.Drawing.Point(130, 319);
            this.bmibutton.Name = "bmibutton";
            this.bmibutton.Size = new System.Drawing.Size(378, 200);
            this.bmibutton.TabIndex = 1;
            this.bmibutton.Text = "    BMI体质指数计算";
            this.bmibutton.UseVisualStyleBackColor = false;
            this.bmibutton.Click += new System.EventHandler(this.bmibutton_Click);
            // 
            // waterremainbutton
            // 
            this.waterremainbutton.BackColor = System.Drawing.Color.LightYellow;
            this.waterremainbutton.FlatAppearance.BorderSize = 0;
            this.waterremainbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.waterremainbutton.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.waterremainbutton.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.waterremainbutton.Image = global::健身运动应用.Properties.Resources.提醒;
            this.waterremainbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.waterremainbutton.Location = new System.Drawing.Point(576, 53);
            this.waterremainbutton.Name = "waterremainbutton";
            this.waterremainbutton.Size = new System.Drawing.Size(378, 200);
            this.waterremainbutton.TabIndex = 0;
            this.waterremainbutton.Text = "  喝水提醒设置";
            this.waterremainbutton.UseVisualStyleBackColor = false;
            this.waterremainbutton.Click += new System.EventHandler(this.waterremainbutton_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1067, 587);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "home";
            this.Text = "home";
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button feedbackbutton;
        private System.Windows.Forms.Button bmibutton;
        private System.Windows.Forms.Button waterremainbutton;
        private System.Windows.Forms.Button recommendbutton;
    }
}