namespace SortProgram
{
    partial class RegisterWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterWindow));
            this.ageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.ageLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.conditionCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ageNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ageNumericUpDown
            // 
            this.ageNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageNumericUpDown.Location = new System.Drawing.Point(198, 176);
            this.ageNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ageNumericUpDown.Name = "ageNumericUpDown";
            this.ageNumericUpDown.Size = new System.Drawing.Size(59, 28);
            this.ageNumericUpDown.TabIndex = 15;
            this.ageNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ageNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(83, 129);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(174, 28);
            this.passwordTextBox.TabIndex = 14;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(83, 74);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(174, 28);
            this.nameTextBox.TabIndex = 13;
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.Khaki;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.registerButton.Location = new System.Drawing.Point(83, 274);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(174, 31);
            this.registerButton.TabIndex = 11;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.Location = new System.Drawing.Point(79, 178);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(40, 21);
            this.ageLabel.TabIndex = 10;
            this.ageLabel.Text = "Age";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(79, 105);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(84, 21);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(79, 44);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 21);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Name";
            // 
            // conditionCheckBox
            // 
            this.conditionCheckBox.AutoSize = true;
            this.conditionCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.conditionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conditionCheckBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.conditionCheckBox.Location = new System.Drawing.Point(56, 226);
            this.conditionCheckBox.Name = "conditionCheckBox";
            this.conditionCheckBox.Size = new System.Drawing.Size(256, 21);
            this.conditionCheckBox.TabIndex = 12;
            this.conditionCheckBox.Text = "I read the terms and conditions";
            this.conditionCheckBox.UseVisualStyleBackColor = false;
            this.conditionCheckBox.CheckedChanged += new System.EventHandler(this.conditionCheckBox_CheckedChanged);
            // 
            // RegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(346, 390);
            this.Controls.Add(this.ageNumericUpDown);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.conditionCheckBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "RegisterWindow";
            this.Text = "RegisterWindow";
            ((System.ComponentModel.ISupportInitialize)(this.ageNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ageNumericUpDown;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.CheckBox conditionCheckBox;
    }
}