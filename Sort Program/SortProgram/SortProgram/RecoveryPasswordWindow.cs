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
    public partial class RecoveryPasswordWindow : Form
    {
        string fileName = "\\User.txt";
        public RecoveryPasswordWindow()
        {
            InitializeComponent();
        }

        private void getPassword_Click(object sender, EventArgs e)
        {
            string Cale = Directory.GetCurrentDirectory();
            if (File.Exists(Cale + fileName))
            {
                StreamReader file = new StreamReader("User.txt");
                string s;
                string[] ss;
                int index = 1;
                bool sem = false;
                do
                {
                    s = file.ReadLine();
                    if (s != null && s != "")
                    {
                        ss = s.Split();
                        if (ss[1] == "Name:")
                        {
                            index += 3;
                            if (ss[2] == nameTextBox.Text)
                            {
                                s = file.ReadLine();
                                ss = s.Split();
                                passwordTextBox.Text = ss[1];
                                file.Close();
                                sem = true;
                            }
                        }
                    }
                } while (s != null && sem == false);
                if (sem == false)
                {
                    MessageBox.Show("Acest utilizator nu exista. Creati un cont nou.");
                    nameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    file.Close();
                }
            }
            else
            {
                MessageBox.Show("Acest utilizator nu exista. Creati un cont nou.");
                nameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }
    }
}
