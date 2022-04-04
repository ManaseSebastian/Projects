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
    public partial class Form2 : Form
    {
        private static Form2 instance;
        private int price = 0;

        public Form2()
        {
            InitializeComponent();
            label2.Text = "Total: " + this.price + " lei";
        }

        public static Form2 getInstance()
        {
            if (instance == null)
            {
                instance = new Form2();
            }
            return instance;
        }

        public CheckedListBox CommandList
        {
            get
            {
                return checkedListBox1;
            }
        }

        private void buttonCommand_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter("Comenzi.txt", true);
            foreach (string s in checkedListBox1.CheckedItems)
            {
                file.Write(s + "\n");
            }
            file.Write("Total: " + this.price + " lei");
            MessageBox.Show("Comanda a fost inregistrata");
            file.Write("\n");
            file.Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                string[] s1 = checkedListBox1.SelectedItem.ToString().Split('-');
                string[] s2 = s1[1].Split(' ');
                int priceItem = int.Parse(s2[1]) * int.Parse(s2[3]);
                if (e.CurrentValue == CheckState.Checked)
                {
                    this.price -= priceItem;
                }
                else
                {
                    this.price += priceItem;
                }
                label2.Text = "Total: " + this.price + " lei";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

