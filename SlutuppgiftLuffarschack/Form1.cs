using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlutuppgiftLuffarschack
{
    public partial class Form1 : Form
    {
        //true = X tur och false = O tur
        bool tur = true;
        int tur_antal = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void omToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Detta är mitt slutprojekt!", "Hejsan Tobias");
        }

        private void stängToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //stäng ner programmet
            Application.Exit();
        }

        private void knapp_klick(object sender, EventArgs e)

        {
            Button b = (Button)sender;
            if (tur)
                b.Text = "X";
            else
                b.Text = "O";

            tur = !tur;
            b.Enabled = false;

            tur_antal++;

            vinnare();
        }

        private void vinnare()
        {
            bool det_finns_en_vinnare = false;


            //Här gör vi så att man kan vinna med att ha tre i rad horistontellt
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                det_finns_en_vinnare = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                det_finns_en_vinnare = true;

            //Här gör vi så att man kan vinna med att ha tre i rad vertikalt
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                det_finns_en_vinnare = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                det_finns_en_vinnare = true;

            //Här gör vi så att man kan vinna med att ha tre i rad diagonalt
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                det_finns_en_vinnare = true;


            //blir det tre i rad för X eller O uppstår det en message box som säger vinnare till en av dom
            if (det_finns_en_vinnare)
            {
                disableButtons();

                String vinnare = " ";
                if (tur)
                    vinnare = "O";
                else
                    vinnare = "X";

                MessageBox.Show(vinnare + " är vinnaren!");
            }
            else
            {
                //Om det har gått 9 omgångar kommer det upp en message box som säger oavgjort
                if (tur_antal == 9)
                    MessageBox.Show("Oavgjort!");

            }
        }

        //funktionen låter en inte klicka igen på en knapp som redan har blivit nertryckt
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }

        }

        //börja om på "Nytt Spel"
        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tur = true;
            tur_antal = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = " ";
                }
            }
            catch { }
        }
    }
}
