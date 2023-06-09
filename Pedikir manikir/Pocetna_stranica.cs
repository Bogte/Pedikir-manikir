﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pedikir_manikir
{
    public partial class Pocetna_stranica : Form
    {
        string tabela;

        public Pocetna_stranica(string ime)
        {
            tabela = ime;

            InitializeComponent();
        }

        private void klijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klijent f1 = new Klijent();
            f1.ShowDialog();
        }

        private void Pocetna_stranica_Load(object sender, EventArgs e)
        {
            
        }

        private void plataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plata f1 = new Plata();
            f1.ShowDialog();
        }

        private void uslugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usluga f1 = new Usluga();
            f1.ShowDialog();
        }

        private void zaposleniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zaposleni f1 = new Zaposleni();
            f1.ShowDialog();
        }

        private void rezervacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezervacija f1 = new Rezervacija();
            f1.ShowDialog();
        }

        private void slobodniTerminiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Slobodni_termini f1 = new Slobodni_termini();
            f1.ShowDialog();
        }
    }
}
