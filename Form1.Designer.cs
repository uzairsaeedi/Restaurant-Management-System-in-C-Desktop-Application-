namespace RMS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_role = new Label();
            rb_employee = new RadioButton();
            rb_admin = new RadioButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lbl_login = new Label();
            btn_login = new Button();
            lbl_password = new Label();
            txt_password = new TextBox();
            lbl_username = new Label();
            txt_username = new TextBox();
            checkBox1 = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_role
            // 
            lbl_role.AutoSize = true;
            lbl_role.Location = new Point(33, 242);
            lbl_role.Name = "lbl_role";
            lbl_role.Size = new Size(41, 15);
            lbl_role.TabIndex = 34;
            lbl_role.Text = "Role:";
            // 
            // rb_employee
            // 
            rb_employee.AutoSize = true;
            rb_employee.Location = new Point(127, 263);
            rb_employee.Name = "rb_employee";
            rb_employee.Size = new Size(88, 19);
            rb_employee.TabIndex = 33;
            rb_employee.TabStop = true;
            rb_employee.Text = "Employee";
            rb_employee.UseVisualStyleBackColor = true;
            // 
            // rb_admin
            // 
            rb_admin.AutoSize = true;
            rb_admin.Location = new Point(48, 261);
            rb_admin.Name = "rb_admin";
            rb_admin.Size = new Size(65, 19);
            rb_admin.TabIndex = 31;
            rb_admin.TabStop = true;
            rb_admin.Text = "Admin";
            rb_admin.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel1.Location = new Point(299, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(316, 408);
            panel1.TabIndex = 30;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._65434;
            pictureBox1.Location = new Point(99, 182);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoSize = true;
            label1.BackColor = Color.LightSlateGray;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold);
            label1.Location = new Point(91, 71);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(146, 78);
            label1.TabIndex = 13;
            label1.Text = "Restaurant \r\nManagement \r\nSystem";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl_login
            // 
            lbl_login.AutoSize = true;
            lbl_login.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold);
            lbl_login.Location = new Point(53, 87);
            lbl_login.Name = "lbl_login";
            lbl_login.Size = new Size(148, 28);
            lbl_login.TabIndex = 29;
            lbl_login.Text = "Login Screen";
            // 
            // btn_login
            // 
            btn_login.BackColor = SystemColors.GradientActiveCaption;
            btn_login.Cursor = Cursors.Hand;
            btn_login.FlatStyle = FlatStyle.Popup;
            btn_login.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_login.Location = new Point(63, 310);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(120, 33);
            btn_login.TabIndex = 28;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(32, 183);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(69, 15);
            lbl_password.TabIndex = 27;
            lbl_password.Text = "Password";
            // 
            // txt_password
            // 
            txt_password.Location = new Point(29, 201);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(241, 21);
            txt_password.TabIndex = 26;
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Location = new Point(32, 134);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(73, 15);
            lbl_username.TabIndex = 25;
            lbl_username.Text = "Username";
            // 
            // txt_username
            // 
            txt_username.Location = new Point(29, 150);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(241, 21);
            txt_username.TabIndex = 24;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(141, 229);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(127, 19);
            checkBox1.TabIndex = 35;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 406);
            Controls.Add(checkBox1);
            Controls.Add(lbl_role);
            Controls.Add(rb_employee);
            Controls.Add(rb_admin);
            Controls.Add(panel1);
            Controls.Add(lbl_login);
            Controls.Add(btn_login);
            Controls.Add(lbl_password);
            Controls.Add(txt_password);
            Controls.Add(lbl_username);
            Controls.Add(txt_username);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_role;
        private RadioButton rb_employee;
        private RadioButton rb_admin;
        private Panel panel1;
        private Label label1;
        private Label lbl_login;
        private Button btn_login;
        private Label lbl_password;
        private TextBox txt_password;
        private Label lbl_username;
        private TextBox txt_username;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
    }
}
