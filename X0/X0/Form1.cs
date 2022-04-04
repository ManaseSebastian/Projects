using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace X0
{
    public partial class X0 : Form
    {
        int nr_click;// pot vedea cine a castigat
        int[,] a = new int[3, 3]; // Consideram x->1 si 0->2
        int Scor1 = 0;
        int Scor2 = 0;

        void Initializare()
        {
            X.BackColor = Color.Yellow;
            zero.BackColor = Color.White;
            nr_click = 0;
            buton1.Text = "";
            buton2.Text = "";
            buton3.Text = "";
            buton4.Text = "";
            buton5.Text = "";
            buton6.Text = "";
            buton7.Text = "";
            buton8.Text = "";
            buton9.Text = "";
            int nr = 3; // Initializare termeni
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    a[i, j] = nr;
                    nr++;
                }
            buton1.BackColor = Color.White;             
            buton2.BackColor = Color.White;
            buton3.BackColor = Color.White;
            buton4.BackColor = Color.White;
            buton5.BackColor = Color.White;
            buton6.BackColor = Color.White;
            buton7.BackColor = Color.White;
            buton8.BackColor = Color.White;
            buton9.BackColor = Color.White;
        }

        public X0()
        {
            InitializeComponent();
            Initializare();
            
           
        }

        void rand0()
        { 
            X.BackColor = Color.White;
            zero.BackColor = Color.Yellow;
        }

        void randX()
        {
            zero.BackColor = Color.White;
            X.BackColor = Color.Yellow;
        }

        private void buton1_Click(object sender, EventArgs e)
        {
            if (buton1.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton1.Text = "X";
                    a[0, 0] = 1;
                    rand0();
                }
                else
                {
                    buton1.Text = "0";
                    a[0, 0] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
                
            }
        }

        private void buton2_Click(object sender, EventArgs e)
        {
            if (buton2.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton2.Text = "X";
                    a[0, 1] = 1;
                    rand0();
                }
                else
                {
                    buton2.Text = "0";
                    a[0, 1] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
                
            }
        }

        private void buton3_Click(object sender, EventArgs e)
        {
            if (buton3.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton3.Text = "X";
                    a[0, 2] = 1;
                    rand0();
                }
                else
                {
                    buton3.Text = "0";
                    a[0, 2] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
               
            }
        }

        private void buton4_Click(object sender, EventArgs e)
        {
            if (buton4.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton4.Text = "X";
                    a[1, 0] = 1;
                    rand0();
                }
                else
                {
                    buton4.Text = "0";
                    a[1, 0] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
                
            }
        }

        private void buton5_Click(object sender, EventArgs e)
        {
            if (buton5.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton5.Text = "X";
                    a[1, 1] = 1;
                    rand0();
                }
                else
                {
                    buton5.Text = "0";
                    a[1, 1] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
                
            }
        }

        private void buton6_Click(object sender, EventArgs e)
        {
            if (buton6.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton6.Text = "X";
                    a[1, 2] = 1;
                    rand0();
                }
                else
                {
                    buton6.Text = "0";
                    a[1, 2] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
                
            }
        }

        private void buton7_Click(object sender, EventArgs e)
        {
            if (buton7.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton7.Text = "X";
                    a[2, 0] = 1;
                    rand0();
                }
                else
                {
                    buton7.Text = "0";
                    a[2, 0] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
               
            }
        }

        private void buton8_Click(object sender, EventArgs e)
        {
            if (buton8.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton8.Text = "X";
                    a[2, 1] = 1;
                    rand0();
                }
                else
                {
                    buton8.Text = "0";
                    a[2, 1] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
                
            }
        }

        private void buton9_Click(object sender, EventArgs e)
        {
            if (buton9.Text == "")
            {
                if (nr_click % 2 == 0)
                {
                    buton9.Text = "X";
                    a[2, 2] = 1;
                    rand0();
                }
                else
                {
                    buton9.Text = "0";
                    a[2, 2] = 2;
                    randX();
                }
                nr_click++;
                Castigator();
                
            }
        }

        void Castigator()
        {
            if (((a[0, 0] == a[0, 1]) && (a[0, 1] == a[0, 2])) ||
                ((a[1, 0] == a[1, 1]) && (a[1, 1] == a[1, 2])) ||
                ((a[2, 0] == a[2, 1]) && (a[2, 1] == a[2, 2])) ||
                ((a[0, 0] == a[1, 0]) && (a[1, 0] == a[2, 0])) ||
                ((a[0, 1] == a[1, 1]) && (a[1, 1] == a[2, 1])) ||
                ((a[0, 2] == a[1, 2]) && (a[1, 2] == a[2, 2])) ||
                ((a[0, 0] == a[1, 1]) && (a[1, 1] == a[2, 2])) ||
                ((a[0, 2] == a[1, 1]) && (a[1, 1] == a[2, 0])))
            {
                Colorare();
                if (nr_click % 2 != 0)
                {
                    MessageBox.Show("X a castigat!");
                    Scor1++;
                    ScorX.Text = Scor1.ToString();
                }
                else
                {
                    MessageBox.Show("0 a castigat!");
                    Scor2++;
                    Scor0.Text = Scor2.ToString();
                }
                Initializare();
            }
            else
                if (nr_click == 9)
                {
                    MessageBox.Show("Nimeni nu a castigat");
                    Initializare();
                }
        }

        void Colorare()
        {
            if ((a[0, 0] == a[0, 1]) && (a[0, 1] == a[0, 2]))
            {
                buton1.BackColor = Color.Yellow;
                buton2.BackColor = Color.Yellow;
                buton3.BackColor = Color.Yellow;
            }
            else
                if ((a[1, 0] == a[1, 1]) && (a[1, 1] == a[1, 2]))
            {
                buton4.BackColor = Color.Yellow;
                buton5.BackColor = Color.Yellow;
                buton6.BackColor = Color.Yellow;
            }
            else
               if ((a[2, 0] == a[2, 1]) && (a[2, 1] == a[2, 2]))
            {
                buton7.BackColor = Color.Yellow;
                buton8.BackColor = Color.Yellow;
                buton9.BackColor = Color.Yellow;
            }
            else
            if ((a[0, 0] == a[1, 0]) && (a[1, 0] == a[2, 0]))
            {
                buton1.BackColor = Color.Yellow;
                buton4.BackColor = Color.Yellow;
                buton7.BackColor = Color.Yellow;
            }
            else
            if ((a[0, 1] == a[1, 1]) && (a[1, 1] == a[2, 1]))
            {
                buton2.BackColor = Color.Yellow;
                buton5.BackColor = Color.Yellow;
                buton8.BackColor = Color.Yellow;
            }
            else
            if ((a[0, 2] == a[1, 2]) && (a[1, 2] == a[2, 2]))
            {
                buton3.BackColor = Color.Yellow;
                buton6.BackColor = Color.Yellow;
                buton9.BackColor = Color.Yellow;
            }
            else
            if ((a[0, 0] == a[1, 1]) && (a[1, 1] == a[2, 2]))
            {
                buton1.BackColor = Color.Yellow;
                buton5.BackColor = Color.Yellow;
                buton9.BackColor = Color.Yellow;
            }
            else
            if ((a[0, 2] == a[1, 1]) && (a[1, 1] == a[2, 0]))
            {
                buton3.BackColor = Color.Yellow;
                buton5.BackColor = Color.Yellow;
                buton7.BackColor = Color.Yellow;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Initializare();
            Scor1 = 0;
            Scor2 = 0;
            ScorX.Text = Scor1.ToString();
            Scor0.Text = Scor2.ToString();
        }
    }
}