using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pedikir_manikir
{
    public partial class Rezervacija : Form
    {
        DataTable podaci, pom;
        SqlCommand menjanja;

        public Rezervacija()
        {
            InitializeComponent();
        }

        private void Rezervacija_Load(object sender, EventArgs e)
        {
            Osvezi();

            pom = new DataTable();//Dodavanje
            pom = Konekcija.Unos("SELECT DISTINCT ime + ' ' + prezime AS 'klijent' FROM Klijent");
            string[] pomocna = new string[pom.Rows.Count];
            for (int i = 0; i < pom.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(pom.Rows[i]["klijent"]);
                comboBox1.Items.Add(pomocna[i]);
            }

            pom = new DataTable();//Dodavanje zaposlenih
            pom = Konekcija.Unos("SELECT DISTINCT Ime + ' ' + Prezime AS 'Z' FROM Zaposleni");
            pomocna = new string[pom.Rows.Count];
            for (int i = 0; i < pom.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(pom.Rows[i]["Z"]);
                comboBox2.Items.Add(pomocna[i]);
            }

            pom = new DataTable();//Dodavanje naziva
            pom = Konekcija.Unos("SELECT DISTINCT Naziv FROM Usluga");
            pomocna = new string[pom.Rows.Count];
            for (int i = 0; i < pom.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(pom.Rows[i]["Naziv"]);
                comboBox3.Items.Add(pomocna[i]);
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int indeks = dataGridView1.CurrentRow.Index;

                textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Id"].Value);
                comboBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Klijent"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Telefon klijenta"].Value);
                comboBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Zaposleni"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Telefon zaposlenog"].Value);
                comboBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Naziv"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Cena"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Datum i vreme"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Napomena"].Value);
            }
        }

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Rezervacija.id, Klijent.Ime + ' ' + Klijent.Prezime AS 'Klijent', Klijent.Telefon AS 'Telefon klijenta', Zaposleni.Ime + ' ' + Zaposleni.Prezime AS 'Zaposleni', Zaposleni.Telefon AS 'Telefon zaposlenog', Usluga.Naziv, Usluga.Cena, datum_vreme AS 'Datum i vreme', napomena FROM Rezervacija JOIN Klijent ON Klijent.id = klijent_id JOIN Zaposleni ON Zaposleni.id = zaposleni_id JOIN Usluga ON Usluga.id = usluga_id");
            dataGridView1.DataSource = podaci;
        }

    }
}
