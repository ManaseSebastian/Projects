namespace SortProgram
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteProjectButton = new System.Windows.Forms.Button();
            this.addProjectButton = new System.Windows.Forms.Button();
            this.openProjectButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.pathRadioButton = new System.Windows.Forms.RadioButton();
            this.DirectoryRadioButton = new System.Windows.Forms.RadioButton();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.projectsTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Khaki;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(178, 316);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(133, 35);
            this.addButton.TabIndex = 39;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Khaki;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(39, 316);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(133, 35);
            this.updateButton.TabIndex = 38;
            this.updateButton.Text = "Update Path";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteProjectButton
            // 
            this.deleteProjectButton.BackColor = System.Drawing.Color.Khaki;
            this.deleteProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteProjectButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteProjectButton.Location = new System.Drawing.Point(43, 135);
            this.deleteProjectButton.Name = "deleteProjectButton";
            this.deleteProjectButton.Size = new System.Drawing.Size(268, 37);
            this.deleteProjectButton.TabIndex = 37;
            this.deleteProjectButton.Text = "Sterge un Proiect";
            this.deleteProjectButton.UseVisualStyleBackColor = false;
            this.deleteProjectButton.Click += new System.EventHandler(this.deleteProjectButton_Click);
            // 
            // addProjectButton
            // 
            this.addProjectButton.BackColor = System.Drawing.Color.Khaki;
            this.addProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProjectButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProjectButton.Location = new System.Drawing.Point(43, 101);
            this.addProjectButton.Name = "addProjectButton";
            this.addProjectButton.Size = new System.Drawing.Size(268, 37);
            this.addProjectButton.TabIndex = 36;
            this.addProjectButton.Text = "Adauga un Proiect";
            this.addProjectButton.UseVisualStyleBackColor = false;
            this.addProjectButton.Click += new System.EventHandler(this.addProjectButton_Click);
            // 
            // openProjectButton
            // 
            this.openProjectButton.BackColor = System.Drawing.Color.Khaki;
            this.openProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openProjectButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openProjectButton.Location = new System.Drawing.Point(43, 67);
            this.openProjectButton.Name = "openProjectButton";
            this.openProjectButton.Size = new System.Drawing.Size(268, 37);
            this.openProjectButton.TabIndex = 35;
            this.openProjectButton.Text = "Deschide un Proiect";
            this.openProjectButton.UseVisualStyleBackColor = false;
            this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.BackColor = System.Drawing.Color.Transparent;
            this.messageLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(39, 175);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(71, 21);
            this.messageLabel.TabIndex = 34;
            this.messageLabel.Text = "Metoda:";
            // 
            // pathRadioButton
            // 
            this.pathRadioButton.AutoSize = true;
            this.pathRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.pathRadioButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathRadioButton.Location = new System.Drawing.Point(71, 230);
            this.pathRadioButton.Name = "pathRadioButton";
            this.pathRadioButton.Size = new System.Drawing.Size(122, 25);
            this.pathRadioButton.TabIndex = 33;
            this.pathRadioButton.Text = "Path Project";
            this.pathRadioButton.UseVisualStyleBackColor = false;
            this.pathRadioButton.CheckedChanged += new System.EventHandler(this.pathRadioButton_CheckedChanged);
            // 
            // DirectoryRadioButton
            // 
            this.DirectoryRadioButton.AutoSize = true;
            this.DirectoryRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.DirectoryRadioButton.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryRadioButton.Location = new System.Drawing.Point(69, 199);
            this.DirectoryRadioButton.Name = "DirectoryRadioButton";
            this.DirectoryRadioButton.Size = new System.Drawing.Size(159, 25);
            this.DirectoryRadioButton.TabIndex = 32;
            this.DirectoryRadioButton.Text = "Directory Project";
            this.DirectoryRadioButton.UseVisualStyleBackColor = false;
            this.DirectoryRadioButton.CheckedChanged += new System.EventHandler(this.DirectoryRadioButton_CheckedChanged);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTextBox.Location = new System.Drawing.Point(39, 282);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(272, 28);
            this.pathTextBox.TabIndex = 29;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.BackColor = System.Drawing.Color.Transparent;
            this.pathLabel.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(39, 258);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(146, 21);
            this.pathLabel.TabIndex = 28;
            this.pathLabel.Text = "Introduceti Calea :";
            // 
            // projectsTreeView
            // 
            this.projectsTreeView.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectsTreeView.Location = new System.Drawing.Point(327, 41);
            this.projectsTreeView.Name = "projectsTreeView";
            this.projectsTreeView.Size = new System.Drawing.Size(218, 331);
            this.projectsTreeView.TabIndex = 27;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(587, 436);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteProjectButton);
            this.Controls.Add(this.addProjectButton);
            this.Controls.Add(this.openProjectButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.pathRadioButton);
            this.Controls.Add(this.DirectoryRadioButton);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.projectsTreeView);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteProjectButton;
        private System.Windows.Forms.Button addProjectButton;
        private System.Windows.Forms.Button openProjectButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.RadioButton pathRadioButton;
        private System.Windows.Forms.RadioButton DirectoryRadioButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TreeView projectsTreeView;
    }
}