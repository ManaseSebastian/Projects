using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SortProgram
{
    public partial class LoginWindow : Form
    {
        string fileName = "\\User.txt";
        public LoginWindow()
        {
            string path = Directory.GetCurrentDirectory() + fileName;
            if (File.Exists(path))
            {
               File.SetAttributes("User.txt", FileAttributes.Hidden);
            }
            InitializeComponent();
            rememberUser();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Enter the account name");
            }
            else
            {
                if (passwordTextBox.Text == "")
                    MessageBox.Show("Enter the account password");
                else
                {
                    LoginAction();
                    MakeDirProject();
                }
            }
        }

        void MakeDirProject()
        {
            string path = Directory.GetCurrentDirectory();
            if (!Directory.Exists(path + "\\Project"))
                Directory.CreateDirectory(path + "\\Project");
        }

        // public static LoginWindow forma1;
        void LoginAction()
        {
            MainWindow mainWindow = new MainWindow();
            string name = nameTextBox.Text;
            string password = passwordTextBox.Text;
            bool sem = false;
            int nrCrt = 1;
            string path = Directory.GetCurrentDirectory();

            try
            {
                StreamReader file = new StreamReader("User.txt");
                string s = file.ReadLine();
                while (s != null && sem == false)
                {
                    string[] ss = s.Split();
                    if (ss[0] == nrCrt.ToString() + ")")
                    {
                        nrCrt++;
                        if (name == ss[2])
                        {
                            s = file.ReadLine();
                            ss = s.Split();
                            if (password == ss[1])
                            {
                                mainWindow.Show();
                                // forma1 = this;
                                this.Hide();
                                sem = true;
                            }
                        }
                    }
                    s = file.ReadLine();
                }
                file.Close();
                if (sem != true)
                    MessageBox.Show("Cont inexistent");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void rememberUser()
        {
            string Cale = Directory.GetCurrentDirectory();
            if (File.Exists(Cale + "\\Remember.txt"))
            {
                StreamReader fisier = new StreamReader("Remember.txt");
                if (fisier != null)
                {
                    nameTextBox.Text = fisier.ReadLine();
                    passwordTextBox.Text = fisier.ReadLine();
                }
                fisier.Close();
            }
        }

        private void rememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter fisier = new StreamWriter("Remember.txt");
            if (rememberCheckBox.Checked)
            {
                fisier.WriteLine(nameTextBox.Text);
                fisier.WriteLine(passwordTextBox.Text);
            }
            else
                fisier.WriteLine("");
            fisier.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createAccountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        private void forgetLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecoveryPasswordWindow recoveryPassword = new RecoveryPasswordWindow();
            recoveryPassword.Show();
        }
    }
}
