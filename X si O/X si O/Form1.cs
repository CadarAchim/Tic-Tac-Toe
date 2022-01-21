using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_si_O
{
    public partial class Form1 : Form
    {
        bool mutare = true; //in momentul in care primul jucator face mutarea indiferent daca e X sau O acel jucator incepe, iar daca e fals continua jucatorul urmator
        int count = 0; //numaratoarea mutarilor din runda este stocata in count

        public Form1()
        {
            InitializeComponent();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)//comentarii inutile, doar un exemplu...
        {
            MessageBox.Show("by Cadar Achim Mircea", "About the game, just some simple instructions");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//apasand Exit te scoate automat din joc
        {
            Application.Exit();
        }
        private void buton_click(object sender, EventArgs e)//initializeaza prima mutare cu X apoi cu O
        {
            Button b = (Button)sender;
            if (mutare)
                b.Text = "X";
            else
                b.Text = "O";

            mutare = !mutare;//dezactiveaza daca pe X e mutare sa nu se poata schimba in O
            b.Enabled = false;
            count++;

            checkForWinner();
        }
        private void checkForWinner()//verifica castigatorii pe orizontala, verticala sau diagonala
        {
            bool castigator = false;

            //verificare castigatori pe orizontala
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                castigator = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                castigator = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                castigator = true;

            //verificare castigatori pe verticala
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                castigator = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                castigator = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                castigator = true;

            //verificare castigatori pe diagonala
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                castigator = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                castigator = true;
           

            if (castigator)//verifica cine a castigat
            {
                disableButtons();
                string castig = "";
                if (mutare)
                    castig = "O";
                else
                    castig = "X";
                MessageBox.Show(castig + " Castigator!");
            }
            else//verifica daca este egalitate
            {
                if (count == 9)
                    MessageBox.Show("Egalitate!");
            }
        }
        private void disableButtons()//in caz ca a castigat unul din jucatori se dezactiveaza toate butoanele pentru a nu mai continua jocul
        {
            try
            {
                foreach (Control c in Controls)//verifica butoanele neapasate si le dezactiveaza
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)//new game
        {
            Application.Restart();
        }
    }
}
