namespace PuzzleGame
{
    partial class StartScreen
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
            this.Title = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.About_btn = new System.Windows.Forms.Button();
            this.Help_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Title.Location = new System.Drawing.Point(234, 54);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(304, 54);
            this.Title.TabIndex = 0;
            this.Title.Text = "Puzzle Game";
            // 
            // Start_btn
            // 
            this.Start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_btn.Location = new System.Drawing.Point(308, 135);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(157, 75);
            this.Start_btn.TabIndex = 1;
            this.Start_btn.Text = "START";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // About_btn
            // 
            this.About_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_btn.Location = new System.Drawing.Point(308, 229);
            this.About_btn.Name = "About_btn";
            this.About_btn.Size = new System.Drawing.Size(157, 75);
            this.About_btn.TabIndex = 2;
            this.About_btn.Text = "ABOUT";
            this.About_btn.UseVisualStyleBackColor = true;
            this.About_btn.Click += new System.EventHandler(this.About_btn_Click);
            // 
            // Help_btn
            // 
            this.Help_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help_btn.Location = new System.Drawing.Point(308, 321);
            this.Help_btn.Name = "Help_btn";
            this.Help_btn.Size = new System.Drawing.Size(157, 75);
            this.Help_btn.TabIndex = 3;
            this.Help_btn.Text = "HELP";
            this.Help_btn.UseVisualStyleBackColor = true;
            this.Help_btn.Click += new System.EventHandler(this.Help_btn_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Help_btn);
            this.Controls.Add(this.About_btn);
            this.Controls.Add(this.Start_btn);
            this.Controls.Add(this.Title);
            this.Name = "StartScreen";
            this.Text = "Puzzle Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Button About_btn;
        private System.Windows.Forms.Button Help_btn;
    }
}