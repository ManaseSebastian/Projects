using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int M_Viteza = 6; //Viteza Minion
        int B_Viteza = 6; //Viteza Block-uri
        int scor = 0;

        public Form1()
        {
            InitializeComponent();      
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Setare_Viteze();         
            Monede();
            Scor_Joc.Text = "Scor " + scor.ToString();

            //Partea de jos
            if (B_Jos.Left < -150)
            {
                B_Jos.Left = 800; 
                scor++;
            }
            else
                if ((B_Jos1.Left < -150) && (scor % 15 == 0))
            {
                B_Jos1.Left = 600;
                scor++;
            }

            //Partea de sus
            if (B_Sus.Left < -150)
            {
                B_Sus.Left = 750;
                scor++;
            }
            else
                if ((B_Sus1.Left < -200) && (scor % 20 == 0))
            {
                B_Sus1.Left = 650;
                scor++;
            }

            if (Conditie())
                Termina_Joc();
        }

        private bool Conditie()
        {
            if (Minion.Bounds.IntersectsWith(B_Sus.Bounds) ||
               Minion.Bounds.IntersectsWith(B_Jos.Bounds) ||
               Minion.Bounds.IntersectsWith(Linie.Bounds) ||
               Minion.Bounds.IntersectsWith(B_Jos1.Bounds) ||
               Minion.Bounds.IntersectsWith(B_Sus1.Bounds) ||
               (Minion.Top < -25))
               return true;
            return false;
        }

        private void Setare_Viteze()
        {
            Minion.Top += M_Viteza;
            B_Jos.Left -= B_Viteza;
            B_Jos1.Left -= B_Viteza;
            B_Sus.Left -= B_Viteza;
            B_Sus1.Left -= B_Viteza;
        }

        private void Monede()
        {
            foreach (Control p in this.Controls)
                if (p.Name[0] == 'C')
                {
                    p.Left -= B_Viteza; // Setez viteza Monedelor
                    if (Minion.Bounds.IntersectsWith(p.Bounds) && p.Visible)
                    {
                        p.Hide();
                        scor++;
                    }
                   else
                   if (!p.Visible)
                    {
                        p.Left = Genereaza_Pozitie();
                        p.Show();
                    }
                    else
                         if (((scor + 1) % 20 == 0) && p.Visible)
                    {
                        p.Hide();
                    }

                }
        }

        private int Genereaza_Pozitie()  //Se genereaza o pozitie random a monedei
        {
            Random rand = new Random();
            return rand.Next(801, 1000);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                M_Viteza = -10;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                M_Viteza = 10;
        }

       private void Termina_Joc()
        {
            timer1.Stop();
            MessageBox.Show("Jocul s-a terminat. Scor: "+scor);
            this.Close();
        }
       
    }
}
