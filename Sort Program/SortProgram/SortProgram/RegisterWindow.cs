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
    public partial class RegisterWindow : Form
    {
        string fileName = "\\User.txt";
        public RegisterWindow()
        {
            InitializeComponent();
            registerButton.Enabled = false;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (ageNumericUpDown.Value < 10)
                MessageBox.Show("You are not the right age");
            else
            {
                if (nameTextBox.Text == "")
                    MessageBox.Show("Enter the account name");
                else
                    if (passwordTextBox.Text == "")
                    MessageBox.Show("Enter the account password");
                else
                    CreateAccount();
            }
        }

        void CreateAccount()
        {
            int index = verifyName();
            if (index != 0)
            {
                StreamWriter file = File.AppendText("User.txt");
               // File.SetAttributes("User.txt", FileAttributes.Hidden);
                index = index / 3 + 1;
                file.WriteLine();
                file.WriteLine(index.ToString() + ") Name: " + nameTextBox.Text);
                file.WriteLine("Password: " + passwordTextBox.Text);
                MessageBox.Show("The account has been successfully \n registered!");
                nameTextBox.Text = "";
                passwordTextBox.Text = "";
                file.Close();
            }
        }

        int verifyName()
        {
            string path = Directory.GetCurrentDirectory();
            try
            {
                StreamReader fisier1 = new StreamReader("User.txt");
                string s;
                string[] ss;
                int index = 1;
                bool sem = true;
                do
                {
                    s = fisier1.ReadLine();
                    if (s != null && s != "")
                    {
                        ss = s.Split();
                        if (ss[1] == "Name:")
                        {
                            index += 3;
                            if (ss[2] == nameTextBox.Text)
                            {
                                MessageBox.Show("This name is already in use");
                                nameTextBox.Text = "";
                                passwordTextBox.Text = "";
                                sem = false;
                            }
                        }
                    }
                } while (s != null && sem == true);
                fisier1.Close();
                if (sem == false)
                    return 0;
                else
                    return index;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return 0;
        }

        private void conditionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            registerButton.Enabled = true;
            string path = Directory.GetCurrentDirectory();
            if (!File.Exists(path + fileName))
            {
                File.Create(fileName);
            }
        }
    }
}
