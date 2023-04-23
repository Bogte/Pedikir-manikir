using System;
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
    }
}
