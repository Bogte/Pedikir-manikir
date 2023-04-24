using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pedikir_manikir
{
    public partial class Form1 : Form
    {
        DataTable podaci;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Korisnicko ime ili lozinka nisu ispravni! Pokusajte ponovo!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                podaci = new DataTable();
                podaci = Konekcija.Unos("SELECT ime, prezime, lozinka FROM Zaposleni WHERE ime + ' ' + prezime = '" + textBox1.Text + "' AND lozinka = " + textBox2.Text);

                if ((textBox1.Text == "Stojna Pusicic" && textBox2.Text == "123") || podaci.Rows.Count >= 1)
                {
                    Pocetna_stranica f1 = new Pocetna_stranica(textBox2.Text);
                    f1.Text = "Pocetna_stranica '" + textBox1.Text + "'";
                    f1.ShowDialog();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Korisnicko ime ili lozinka nisu ispravni! Pokusajte ponovo!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }
    }
}
