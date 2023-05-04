namespace SortProgram
{
    partial class LoginWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginWindow));
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.rememberCheckBox = new System.Windows.Forms.CheckBox();
            this.forgetLinkLabel = new System.Windows.Forms.LinkLabel();
            this.helloLabel = new System.Windows.Forms.Label();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.createAccountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.loginGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.BackColor = System.Drawing.Color.White;
            this.loginGroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginGroupBox.BackgroundImage")));
            this.loginGroupBox.Controls.Add(this.rememberCheckBox);
            this.loginGroupBox.Controls.Add(this.forgetLinkLabel);
            this.loginGroupBox.Controls.Add(this.helloLabel);
            this.loginGroupBox.Controls.Add(this.UserPictureBox);
            this.loginGroupBox.Controls.Add(this.createAccountLinkLabel);
            this.loginGroupBox.Controls.Add(this.loginButton);
            this.loginGroupBox.Controls.Add(this.passwordTextBox);
            this.loginGroupBox.Controls.Add(this.nameTextBox);
            this.loginGroupBox.Controls.Add(this.passwordLabel);
            this.loginGroupBox.Controls.Add(this.nameLabel);
            this.loginGroupBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginGroupBox.Location = new System.Drawing.Point(38, 43);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Size = new System.Drawing.Size(347, 484);
            this.loginGroupBox.TabIndex = 7;
            this.loginGroupBox.TabStop = false;
            // 
            // rememberCheckBox
            // 
            this.rememberCheckBox.AutoSize = true;
            this.rememberCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.rememberCheckBox.Location = new System.Drawing.Point(27, 313);
            this.rememberCheckBox.Name = "rememberCheckBox";
            this.rememberCheckBox.Size = new System.Drawing.Size(140, 25);
            this.rememberCheckBox.TabIndex = 10;
            this.rememberCheckBox.Text = "Remember me";
            this.rememberCheckBox.UseVisualStyleBackColor = false;
            this.rememberCheckBox.CheckedChanged += new System.EventHandler(this.rememberCheckBox_CheckedChanged);
            // 
            // forgetLinkLabel
            // 
            this.forgetLinkLabel.AutoSize = true;
            this.forgetLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.forgetLinkLabel.Image = ((System.Drawing.Image)(resources.GetObject("forgetLinkLabel.Image")));
            this.forgetLinkLabel.Location = new System.Drawing.Point(178, 313);
            this.forgetLinkLabel.Name = "forgetLinkLabel";
            this.forgetLinkLabel.Size = new System.Drawing.Size(146, 21);
            this.forgetLinkLabel.TabIndex = 9;
            this.forgetLinkLabel.TabStop = true;
            this.forgetLinkLabel.Text = "Forget Password?";
            this.forgetLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgetLinkLabel_LinkClicked);
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.BackColor = System.Drawing.Color.Transparent;
            this.helloLabel.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloLabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.helloLabel.Image = ((System.Drawing.Image)(resources.GetObject("helloLabel.Image")));
            this.helloLabel.Location = new System.Drawing.Point(82, 138);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(163, 32);
            this.helloLabel.TabIndex = 8;
            this.helloLabel.Text = "Hello World!";
            // 
            // UserPictureBox
            // 
            this.UserPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("UserPictureBox.Image")));
            this.UserPictureBox.Location = new System.Drawing.Point(107, 27);
            this.UserPictureBox.Name = "UserPictureBox";
            this.UserPictureBox.Size = new System.Drawing.Size(113, 88);
            this.UserPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.UserPictureBox.TabIndex = 7;
            this.UserPictureBox.TabStop = false;
            // 
            // createAccountLinkLabel
            // 
            this.createAccountLinkLabel.AutoSize = true;
            this.createAccountLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.createAccountLinkLabel.Image = ((System.Drawing.Image)(resources.GetObject("createAccountLinkLabel.Image")));
            this.createAccountLinkLabel.Location = new System.Drawing.Point(26, 422);
            this.createAccountLinkLabel.Name = "createAccountLinkLabel";
            this.createAccountLinkLabel.Size = new System.Drawing.Size(148, 21);
            this.createAccountLinkLabel.TabIndex = 5;
            this.createAccountLinkLabel.TabStop = true;
            this.createAccountLinkLabel.Text = "Create an Account";
            this.createAccountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createAccountLinkLabel_LinkClicked);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Khaki;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.Black;
            this.loginButton.Location = new System.Drawing.Point(30, 358);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(272, 42);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(27, 269);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(275, 28);
            this.passwordTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(27, 206);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(275, 28);
            this.nameTextBox.TabIndex = 2;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.Image = ((System.Drawing.Image)(resources.GetObject("passwordLabel.Image")));
            this.passwordLabel.Location = new System.Drawing.Point(24, 241);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(84, 21);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Image = ((System.Drawing.Image)(resources.GetObject("nameLabel.Image")));
            this.nameLabel.Location = new System.Drawing.Point(24, 178);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 21);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // closeButton
            // 
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(366, -1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(42, 38);
            this.closeButton.TabIndex = 11;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(420, 540);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.loginGroupBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginWindow";
            this.Text = "Form1";
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.CheckBox rememberCheckBox;
        private System.Windows.Forms.LinkLabel forgetLinkLabel;
        private System.Windows.Forms.Label helloLabel;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private System.Windows.Forms.LinkLabel createAccountLinkLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button closeButton;
    }
}

