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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Stojna Pusicic" && textBox2.Text == "123")
            {
                Pocetna_stranica f1 = new Pocetna_stranica(textBox2.Text);
                f1.Text = "Pocetna_stranica " + textBox1.Text;
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
