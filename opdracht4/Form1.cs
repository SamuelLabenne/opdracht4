namespace Opdracht_4
{
    public partial class Form1 : Form
    {
        FouteRij<TeDoen> taken = new FouteRij<TeDoen>();
        public delegate void Meedelen(string taken);
        int teller = 0;
        TeDoen huidig;
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            datum.Visible = true;
            button5.BackColor = Color.Green;
            button6.BackColor = Color.Green;
        }

        // toon alle taken op een text veld
        public void toonTextVeld(string taken)
        {
            ObjectInfo.Text = taken;
        }

        // toon alle taken op een message box
        public void toonMessageBox(string taken)
        {
            MessageBox.Show(taken);
        }

        // laat datum input tonen/verborgen
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                datum.Visible = false;
            }
            else
            {
                datum.Visible = true;
            }
        }

        // voeg een nieuwe todo toe
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                taken.Toevoegen(new TeDoen(datum.Value, titel.Text, description.Lines));
                titel.Text = "";
                description.Text = "";
            }
            else
            {
                MessageBox.Show("Er is geen datum.");
                titel.Text = "";
                description.Text = "";
            }
        }

        // toon alle tedoen in de lijst één voor één
        private void button2_Click(object sender, EventArgs e)
        {
            List<TeDoen> kopieTaken = taken.Copy();
            if (kopieTaken.Count > 0)
            {
                titel.Text = kopieTaken.ElementAt(teller).Titel;
                description.Lines = kopieTaken.ElementAt(teller).Informatie;
                datum.Value = (DateTime)kopieTaken.ElementAt(teller).Tijdstip;
                huidig = kopieTaken.ElementAt(teller);
                teller++;
                if (teller == kopieTaken.Count)
                {
                    teller = 0;
                }
            } else
            {
                description.Text = "Geen taken.";
            }

        }

        // verwijdert huidig taak 
        private void button3_Click(object sender, EventArgs e)
        {
            taken.Verwijderen(huidig);
            teller = 0;
            titel.Text = "";
            description.Text = "";
        }

        // zet huidig taak op laatste
        private void button4_Click(object sender, EventArgs e)
        {
            taken.ZetAchteraan(huidig);
            titel.Text = "";
            description.Text = "";
        }

        // verandert de kleur van btn toon textveld
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Green)
            {
                button5.BackColor = Color.Red;
            }
            else
            {
                button5.BackColor = Color.Green;
            }
        }

        // verandert de kleur van btn toon message box
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.Green)
            {
                button6.BackColor = Color.Red;
            }
            else
            {
                button6.BackColor = Color.Green;
            }
        }

        // toon alle taken in een textveld of messagebox
        private void ToonBtn_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Green)
            {
                //ObjectInfo.Text = taken.ToString();
                Meedelen meedelen = toonTextVeld;
                meedelen(taken.ToString());

            }
            else if (button5.BackColor == Color.Red)
            {
                ObjectInfo.Text = "";
            }

            if (button6.BackColor == Color.Green)
            {
                //MessageBox.Show(taken.ToString());
                Meedelen meedelen = toonMessageBox;
                toonMessageBox(taken.ToString());
            }
        }

        // text velden opkuisen
        private void button7_Click(object sender, EventArgs e)
        {
            titel.Text = "";
            description.Text = "";
            ObjectInfo.Text = "";
        }

        // alle taken verwijderen 
        private void button8_Click(object sender, EventArgs e)
        {
            taken.Leegmaken();
            titel.Text = "";
            description.Text = "";
            ObjectInfo.Text = "";
        }
    }
}