using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Jocuri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Creare_Bile();            
            Initializare_Directii(1);
            Bomba.Hide();
            Explozie.Hide();     
        }

        bool Stanga, Dreapta, Sus, Jos, Exista_Bomba, Ocupat = false;
        int Scor = 0;
        int viteza = 20, Sus_Jos = 54, viteza_T=7, viteza_L=7;
        int Timp = 1, Timp_Explozie = 1, Timp_Miscare = 1, Timp_Reafisare = 1, Timp_Recuperare=1;
        int Numar_Vieti = 3, Numar_Pietre = 10;
        private  PictureBox[,] P ; //Creez o matrice in care voi afisa tabloul final ( bile / pietre)
        private PictureBox Pietre_Destinatie;
        private PictureBox A1 = new PictureBox();// A1_A; //A1- Adversar1 A1_A- Abilitate A1

        // Creare Fundal    
        private string Locatie(string nume)
        {
            string Cale_Imagine = Directory.GetCurrentDirectory() + "\\Poze\\" + nume;
            return Cale_Imagine;
        }

        private void Creare_Bile()
        {
            int n = 6;
            P = new PictureBox[n, n];
            int nr = 1;
            int[] v = Pozitii_Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (Testez_Pozitie(v, nr))
                        P[i, j] = Creare_Imagine(Locatie("2.png"), i, j, 40); //Pietre
                    else
                    {
                        P[i, j] = Creare_Imagine(Locatie("1.png"), i, j, 40); //Bile
                    }                 
                    nr++;
                }
        }

        //Destinatie pentru pietre
        private void Destinatie_Pietre()
        {
            string Cale = Locatie("9.gif");
            int linie = Pozitie_Random(4, 10);
            int coloana = Pozitie_Random(9, 20);
            Pietre_Destinatie = Creare_Imagine(Cale, linie, coloana, 55);
        }

        private int _Linie(int a, int b) // b incrementeaza / decrementeaza linia
        {
            return (a - 55) / 55 + b;
        }

        private int _Coloana(int a, int b) // b incrementeaza / decrementeaza coloana
        {
            return (a - 155) / 65 + b;
        }

        private PictureBox Creare_Imagine(string Cale, int linie, int coloana, int latura) // Creare de PictureBox-uri (acestea vor fi afisate de matrice)
        {
            PictureBox p= new PictureBox();
            p.Name = "B" + linie.ToString()+coloana.ToString();
            p.ImageLocation = Cale;
            p.Height = latura;
            p.Width = latura;
            p.Top = linie * 55+ 55;
            p.Left = coloana * 65 + 155;
            p.BackColor = Color.Transparent;
            p.SizeMode = PictureBoxSizeMode.StretchImage;       
            p.Enabled = true;
            this.Controls.Add(p);
            return p;
        }

        private int[] Pozitii_Random() //Creez un vector de 10 nr random
        {
            int[] v = new int[10];
            for (int i = 0; i < 10; i++)
            {
                int nr = Pozitie_Random(0, 37);
                if (!Testez_Pozitie(v, nr))
                    v[i] = nr;
                else
                    i--;
            }
            return v;
        } 

        private int Pozitie_Random(int val_in,int val_fin)
        {
            Random rand = new Random();
            return rand.Next(val_in, val_fin);
        } //Generez un nr random

        private bool Testez_Pozitie(int[] a,int b) // Verific daca un element de tip int se gaseste intr-un vector
        {
            for (int i = 0; i < 10; i++)
            {
                if (a[i] == b)
                    return true;
            }
            return false;

        }

        //Creare Personaj_Principal
        private void Initializare_Directii(int n)
        {
            switch (n) // Afisam doar 1 dintre cele 3 pozitii
            {
                case 1: { Sonic2.Hide(); Sonic3.Hide(); break; }
                case 2: { Sonic1.Hide(); Sonic3.Hide(); break; }
                case 3: { Sonic1.Hide(); Sonic2.Hide(); break; }
            }          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            //Sonic
            if (e.KeyCode == Keys.Right)//right
                Dreapta = true;
              
            if (e.KeyCode == Keys.Left)
                Stanga = true;

            if (e.KeyCode == Keys.Up)
                Sus = true;
            
            if (e.KeyCode == Keys.Down)
                Jos = true;

            //Bomba
            if (e.KeyCode == Keys.Space)
            {
                Exista_Bomba = true;
                Bomba.Show();
                Bomba.Left = Sonic1.Left + 10;
                Bomba.Top = Sonic1.Top + 10;
            }

            //Muta Piatra
            if (e.KeyCode == Keys.X)
                Muta_Piatra();

 
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Sonic
            Initializare_Directii(1);
            Sonic1.Show();
            if (e.KeyCode == Keys.Left)
                Stanga = false;
            if (e.KeyCode == Keys.Right)
                Dreapta = false;
            if (e.KeyCode == Keys.Up)
                Sus = false;
            if (e.KeyCode == Keys.Down)
                Jos = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           Interzis();
            Muta_Dreapta();
            Muta_Stanga();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Scor_Joc.Text = "Scor: " + Scor.ToString();
            Interzis();
            Muta_Sus();
            Muta_Jos();

            //Explozie_Bomba
            Creare_Explozie();
            Animatie_Explozie();
            Reafisare_Bile();

            if (Sonic1.Left >= P[0, 5].Left + 55)
            {
                A1.Show();
                Miscare_Adversar_1();
            }

            //Termina Jocul
            if (Numar_Pietre==0)
                Termina_Joc("Ai castigat");
            else
            if (Pierde_Viata() == 0)
                Termina_Joc("Ai pierdut.");
            
        }

        //Pozitie Sonic
        private void Muta_Dreapta()
        {
         //   Interzis_D();
            if (Dreapta && Sonic1.Left < 1500)
            {
                Sonic2.Show();
                Initializare_Directii(2);
                Sonic1.Left += viteza;
                Sonic2.Left += viteza;
                Sonic3.Left += viteza;

            }
        }

        private void Muta_Stanga()
        {
            if (Stanga && Sonic1.Left > 0)
            {
                Sonic3.Show();
                Initializare_Directii(3);
                Sonic1.Left -= viteza;
                Sonic2.Left -= viteza;
                Sonic3.Left -= viteza;
            }
        }

        private void Muta_Sus()
        {
            if (Sus && Sonic1.Top > 5)
            {
                Sonic1.Top -= Sus_Jos;
                Sonic2.Top -= Sus_Jos;
                Sonic3.Top -= Sus_Jos;
            }

        }

        private void Muta_Jos()
        {
            if (Jos && (Sonic1.Top < 750))
            {
                Sonic1.Top += Sus_Jos;
                Sonic2.Top += Sus_Jos;
                Sonic3.Top += Sus_Jos;
            }
        }

        private void Creare_Explozie()
        {
            if (Exista_Bomba)
            {
                Timp++;
                if (Timp == 15)
                {
                    Bomba.Hide();
                    Explozie.Show();
                    Explozie.Left = Bomba.Left - 30;
                    Explozie.Top = Bomba.Top - 30;
                    Exista_Bomba = false;
                    Timp = 1;
                }
            }
        }

        private void Animatie_Explozie()
        {
            if (Explozie.Visible)
            {
                Timp_Explozie++;
                Distrugere();
                if (Timp_Explozie == 10)
                {
                    Explozie.Hide();
                    Timp_Explozie = 1;
                }
            }

        }

        //Folosire Bomba
        private void Distrugere()
        {
            string Cale_Imagine = Locatie("1.png");
            foreach (PictureBox p in P)
            {
                if (p.ImageLocation == Cale_Imagine)
                    if (Explozie.Bounds.IntersectsWith(p.Bounds))
                    {
                        p.Hide();
                        Scor += 10;
                    }
            }
        }

        private void Reafisare_Bile()
        {
            Timp_Reafisare++;
            Avertizare.Text = (125-Timp_Reafisare).ToString();
            if (Timp_Reafisare == 125)
            { 
                foreach (PictureBox p in P)
                    if (!p.Visible)
                        p.Show();
                Timp_Reafisare = 1;      
            }
        }
          
        private void Interzis()
        {
            string Cale_Imagine = Locatie("1.png");
            foreach (PictureBox p in P)
                if (p.ImageLocation == Cale_Imagine)
                {
                    if (Sonic1.Bounds.IntersectsWith(p.Bounds) && p.Visible )
                    {
                        Dreapta = false;
                        Stanga = false;
                        Sus = false;
                        Jos = false;
                    }
               }
        }


        //Comenzi pentru pietre
        private void Muta_Piatra()
        {
            string Cale_Imagine = Locatie("2.png");
            foreach (PictureBox p in P)
            {
                if (p.ImageLocation == Cale_Imagine)
                    if (!Ocupat)
                        Iau_Piatra(p);
                    else
                        Pun_Piatra(p);

            }
        }

        private void Iau_Piatra(PictureBox p)
        {
            if (Sonic1.Bounds.IntersectsWith(p.Bounds))
            {
                this.Controls.Remove(p); // Iau piatra
                Destinatie_Pietre(); //Creez portalul
                Adversar_1(); //Protejare portal
                Ocupat = true;
                Scor += 10;
            }
        }

        private void Pun_Piatra(PictureBox p)
        {
            if (Sonic1.Bounds.IntersectsWith(Pietre_Destinatie.Bounds))
            {
                Numar_Pietre--; //Scad nr de pietre
                this.Controls.Remove(Pietre_Destinatie);
                this.Controls.Remove(A1);
                Ocupat = false;
                Scor += 10;
            }
        }

        //Adversari
        private void Creare_Adversari()
        {
           
            Adversar_1();
            Adversar_2();
        }

        private PictureBox Animatie(string Poza, int linie, int coloana, int latura)
        {
            string Cale = Locatie(Poza);
            return Creare_Imagine(Cale, linie, coloana, latura);
        }

        private void Adversar_1()
        {
            int linie = _Linie(Pietre_Destinatie.Top, 1);
            int coloana = _Coloana(Pietre_Destinatie.Left, -1);
            A1 = Animatie("6.gif", linie, coloana, 50); //Adversar
            A1.Hide();

        }

        private void Miscare_Adversar_1()
        {
            if (Pietre_Destinatie != null)
            {
                int l1 = A1.Left;
                int c1 = A1.Top;
                int l2 = Pietre_Destinatie.Left;
                int c2 = Pietre_Destinatie.Top;

                Timp_Miscare++;
                if (Timp_Miscare < 20 && c1 > c2 - 55 && A1.Top > 5)
                    A1.Top -= viteza_T;
                else
                if (Timp_Miscare < 40 && l1 < l2 + 55 && A1.Left < 1500)
                    A1.Left += viteza_L;
                else
                if (Timp_Miscare < 60 && c1 < c2 + 55 && A1.Top < 750)
                    A1.Top += viteza_T;
                else
                if (Timp_Miscare < 80 && l1 > l2 - 55 && A1.Left > 0)
                    A1.Left -= viteza_L;
                else
                    Timp_Miscare = 1;
            }

        }

        private void Adversar_2()
        {
            int linie = _Linie(P[1, 5].Top, 1);
            int coloana = _Coloana(P[1, 5].Left, 2);
            int i = 0;
            while (i < 8)
            {
                Animatie("4.gif", linie + i, coloana, 100); // Adversar
                Animatie("12.gif", linie + i, coloana - 2, 150 ); //Abilitate          
                i += 4;
            }
        }

        //Termina Jocul

        private int Pierde_Viata()
        {
            Timp_Recuperare++;
            if ((Sonic1.Bounds.IntersectsWith(A1.Bounds)) ||
                (Sonic1.Bounds.IntersectsWith(Explozie.Bounds) && Explozie.Visible))
                if (Timp_Recuperare> 30)
            {
                Sterge_Viata();
                Numar_Vieti--;
                Timp_Recuperare = 1;
            }
            return Numar_Vieti;
        }

        private void Sterge_Viata()
        {
            switch (Numar_Vieti)
            {
                case 3: { this.Controls.Remove(Viata3); break; }
                case 2: { this.Controls.Remove(Viata2); break; }
                case 1: { this.Controls.Remove(Viata1); break; }
            }
        }

        private void Termina_Joc(string mesaj)
        {
            timer1.Stop();
            timer2.Stop();
            MessageBox.Show(mesaj + Scor_Joc.Text);
            this.Close();
        }

        
    }
}
