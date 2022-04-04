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

namespace Tema1
{
    public partial class Form1 : Form
    {
        private string[] lines = new string[25];

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            richTextBox.Hide();
            pictureBox.Hide();
            label.Hide();
            commandbutton.Enabled = false;

            StreamReader file = new StreamReader("Meniu.txt");
            int n = 0;
            string s = "";
            while ((s = file.ReadLine()) != null)
            {
                lines[n] = s;
                n++;
            }
            for (int i = 0; i < n; i += 3)
            {
                comboBox1.Items.Add(lines[i]);
            }
            file.Close();
            radioButton1.Text = "Mica";
            radioButton2.Text = "Medie";
            radioButton3.Text = "Mare";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string price = "";
                foreach (RadioButton radioButton in GroupBox.Controls)
                {
                    if (radioButton.Checked)
                    {
                        price = radioButton.Text;
                    }
                }
                if (numericUpDown1.Value > 0)
                {
                    string command = comboBox1.SelectedItem.ToString() + " " + price + " " + numericUpDown1.Value + " buc";
                    listBox1.Items.Add(command);
                    Form2.getInstance().CommandList.Items.Add(command);
                    commandbutton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Introduceti nr de bucati.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alege un tip de pizza." + ex.Message);
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            
            int index = listBox1.SelectedIndex;
            Form2.getInstance().CommandList.SetSelected(index, true);
            Form2.getInstance().CommandList.Items.Remove(Form2.getInstance().CommandList.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void commandbutton_Click(object sender, EventArgs e)
        {
            Form2.getInstance().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton1.Text = "Mica";
            radioButton2.Text = "Medie";
            radioButton3.Text = "Mare";

            richTextBox.Show();
            pictureBox.Show();
            label.Show();

            int index = 3 * comboBox1.SelectedIndex;
            richTextBox.Text = lines[index + 1];

            string path = Directory.GetCurrentDirectory() + "\\Pictures\\";
            pictureBox.ImageLocation = path + lines[index] + ".png";

            string[] prices = lines[index + 2].Split(',');
            radioButton1.Text = radioButton1.Text + "-" + prices[0];
            radioButton2.Text = radioButton2.Text + "-" + prices[1];
            radioButton3.Text = radioButton3.Text + "-" + prices[2];
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
