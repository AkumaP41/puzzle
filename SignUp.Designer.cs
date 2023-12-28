namespace PuzzleGame
{
    partial class SignUp
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
            this.Lbl_User = new System.Windows.Forms.Label();
            this.Lbl_Psswrd = new System.Windows.Forms.Label();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_SignUp = new System.Windows.Forms.Button();
            this.tb_ConfirmPW = new System.Windows.Forms.TextBox();
            this.lbl_confirmPW = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_User
            // 
            this.Lbl_User.AutoSize = true;
            this.Lbl_User.Location = new System.Drawing.Point(283, 52);
            this.Lbl_User.Name = "Lbl_User";
            this.Lbl_User.Size = new System.Drawing.Size(98, 16);
            this.Lbl_User.TabIndex = 1;
            this.Lbl_User.Text = "Tên đăng nhập";
            // 
            // Lbl_Psswrd
            // 
            this.Lbl_Psswrd.AutoSize = true;
            this.Lbl_Psswrd.Location = new System.Drawing.Point(320, 87);
            this.Lbl_Psswrd.Name = "Lbl_Psswrd";
            this.Lbl_Psswrd.Size = new System.Drawing.Size(61, 16);
            this.Lbl_Psswrd.TabIndex = 2;
            this.Lbl_Psswrd.Text = "Mật khẩu";
            // 
            // tb_Username
            // 
            this.tb_Username.Location = new System.Drawing.Point(396, 49);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(150, 22);
            this.tb_Username.TabIndex = 3;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(396, 84);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '●';
            this.tb_Password.Size = new System.Drawing.Size(150, 22);
            this.tb_Password.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = PuzzleGame.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(35, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_SignUp
            // 
            this.btn_SignUp.Location = new System.Drawing.Point(385, 203);
            this.btn_SignUp.Name = "btn_SignUp";
            this.btn_SignUp.Size = new System.Drawing.Size(103, 47);
            this.btn_SignUp.TabIndex = 6;
            this.btn_SignUp.Text = "Đăng ký";
            this.btn_SignUp.UseVisualStyleBackColor = true;
            this.btn_SignUp.Click += new System.EventHandler(this.btn_SignUp_Click);
            // 
            // tb_ConfirmPW
            // 
            this.tb_ConfirmPW.Location = new System.Drawing.Point(396, 119);
            this.tb_ConfirmPW.Name = "tb_ConfirmPW";
            this.tb_ConfirmPW.PasswordChar = '●';
            this.tb_ConfirmPW.Size = new System.Drawing.Size(150, 22);
            this.tb_ConfirmPW.TabIndex = 5;
            // 
            // lbl_confirmPW
            // 
            this.lbl_confirmPW.AutoSize = true;
            this.lbl_confirmPW.Location = new System.Drawing.Point(297, 122);
            this.lbl_confirmPW.Name = "lbl_confirmPW";
            this.lbl_confirmPW.Size = new System.Drawing.Size(84, 16);
            this.lbl_confirmPW.TabIndex = 8;
            this.lbl_confirmPW.Text = "Xác nhận MK";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(286, 157);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(95, 16);
            this.lbl_Name.TabIndex = 9;
            this.lbl_Name.Text = "Tên người chơi";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(396, 154);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(150, 22);
            this.tb_Name.TabIndex = 6;
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 290);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_confirmPW);
            this.Controls.Add(this.tb_ConfirmPW);
            this.Controls.Add(this.btn_SignUp);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.Lbl_Psswrd);
            this.Controls.Add(this.Lbl_User);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SignUp";
            this.Text = "Đăng Ký";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lbl_User;
        private System.Windows.Forms.Label Lbl_Psswrd;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Button btn_SignUp;
        private System.Windows.Forms.TextBox tb_ConfirmPW;
        private System.Windows.Forms.Label lbl_confirmPW;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox tb_Name;
    }
}