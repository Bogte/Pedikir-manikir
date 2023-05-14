using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
                comboBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Naziv usluge"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Cena"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Datum i vreme"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Napomena"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "Pedikir manikir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    menjanja = new SqlCommand();
                    menjanja.CommandText = ("DELETE FROM Rezervacija WHERE id = " + textBox1.Text);

                    SqlConnection con = new SqlConnection(Konekcija.Veza());
                    con.Open();
                    menjanja.Connection = con;
                    menjanja.ExecuteNonQuery();
                    con.Close();

                    Osvezi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ne mozete da obrisete ove podatake, druge tabele zahtevaju ove podatake! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Close();
                Osvezi();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "Pedikir manikir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
                        throw new Exception();

                    string[] klijent = comboBox1.Text.Split();
                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT id FROM Klijent WHERE ime = '" + klijent[0] + "' AND prezime = '" + klijent[1] + "'");
                    int klijent_id = (int)podaci.Rows[0][0];

                    string[] zaposleni = comboBox2.Text.Split();
                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT id FROM Zaposleni WHERE ime = '" + zaposleni[0] + "' AND prezime = '" + zaposleni[1] + "'");
                    int zaposleni_id = (int)podaci.Rows[0][0];

                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT id FROM Usluga WHERE Naziv = '" + comboBox3.Text + "'");
                    int usluga_id = (int)podaci.Rows[0][0];

                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT * FROM Rezervacija WHERE klijent_id = '" + klijent_id + "' AND zaposleni_id = '" + zaposleni_id + "' AND usluga_id = '" + usluga_id + "' AND datum_vreme = '" + textBox5.Text + "' AND napomena = '" + textBox6.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    menjanja = new SqlCommand();
                    menjanja.CommandText = ("UPDATE Rezervacija SET klijent_id = '" + klijent_id + "' WHERE id = " + textBox1.Text +
                        " UPDATE Rezervacija SET zaposleni_id = " + zaposleni_id + " WHERE id = " + textBox1.Text +
                        " UPDATE Rezervacija SET usluga_id = " + usluga_id + " WHERE id = " + textBox1.Text +
                        " UPDATE Rezervacija SET datum_vreme = '" + textBox5.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Rezervacija SET napomena = '" + textBox6.Text + "' WHERE id = " + textBox1.Text);

                    SqlConnection con = new SqlConnection(Konekcija.Veza());
                    con.Open();
                    menjanja.Connection = con;
                    menjanja.ExecuteNonQuery();
                    con.Close();

                    Osvezi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podatak vec postoji u tabeli - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Close();
                Osvezi();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "Pedikir manikir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
                        throw new Exception();

                    string[] pom = textBox5.Text.Split(' ');
                    if ((pom[1] == "10:00:00" && pom[2] == "AM") || (pom[1] == "11:00:00" && pom[2] == "AM") || (pom[1] == "12:00:00" && pom[2] == "AM") || (pom[1] == "1:00:00" && pom[2] == "PM") || (pom[1] == "2:00:00" && pom[2] == "PM") || (pom[1] == "3:00:00" && pom[2] == "PM") || (pom[1] == "4:00:00" && pom[2] == "PM") || (pom[1] == "9:00:00" && pom[2] == "AM") || (pom[1] == "8:00:00" && pom[2] == "AM"))
                    {

                        string[] klijent = comboBox1.Text.Split();
                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Klijent WHERE ime = '" + klijent[0] + "' AND prezime = '" + klijent[1] + "'");
                        int klijent_id = (int)podaci.Rows[0][0];

                        string[] zaposleni = comboBox2.Text.Split();
                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Zaposleni WHERE ime = '" + zaposleni[0] + "' AND prezime = '" + zaposleni[1] + "'");
                        int zaposleni_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT id FROM Usluga WHERE Naziv = '" + comboBox3.Text + "'");
                        int usluga_id = (int)podaci.Rows[0][0];

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT zaposleni_id, datum_vreme FROM Rezervacija WHERE zaposleni_id = " + zaposleni_id + "AND datum_vreme = '" + textBox5.Text + "'");
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        podaci = new DataTable();
                        podaci = Konekcija.Unos("SELECT * FROM Rezervacija WHERE klijent_id = '" + klijent_id + "' AND zaposleni_id = '" + zaposleni_id + "' AND usluga_id = '" + usluga_id + "' AND datum_vreme = '" + textBox5.Text + "' AND napomena = '" + textBox6.Text + "'");
                        if (podaci.Rows.Count >= 1) throw new Exception();

                        menjanja = new SqlCommand();
                        menjanja.CommandText = ("INSERT INTO Rezervacija VALUES (" + klijent_id + ", " + zaposleni_id + ", " + usluga_id + ", '" + textBox5.Text + "', '" + textBox6.Text + "')");

                        SqlConnection con = new SqlConnection(Konekcija.Veza());
                        con.Open();
                        menjanja.Connection = con;
                        menjanja.ExecuteNonQuery();
                        con.Close();

                        Osvezi();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ne mozete da dodate vec postojece podatke! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Close();
                Osvezi();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] pom = comboBox1.Text.Split();
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Telefon FROM Klijent WHERE Ime = '" + pom[0] + "' AND Prezime = '" + pom[1] + "'");
            textBox2.Text = Convert.ToString(podaci.Rows[0][0]);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] pom = comboBox2.Text.Split();
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Telefon FROM Zaposleni WHERE Ime = '" + pom[0] + "' AND Prezime = '" + pom[1] + "'");
            textBox3.Text = Convert.ToString(podaci.Rows[0][0]);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Cena FROM Usluga WHERE Naziv = '" + comboBox3.Text + "'");
            textBox4.Text = Convert.ToString(podaci.Rows[0][0]);
        }

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Rezervacija.id, Klijent.Ime + ' ' + Klijent.Prezime AS 'Klijent', Klijent.Telefon AS 'Telefon klijenta', Zaposleni.Ime + ' ' + Zaposleni.Prezime AS 'Zaposleni', Zaposleni.Telefon AS 'Telefon zaposlenog', Usluga.Naziv AS 'Naziv usluge', Usluga.Cena, datum_vreme AS 'Datum i vreme', napomena FROM Rezervacija JOIN Klijent ON Klijent.id = klijent_id JOIN Zaposleni ON Zaposleni.id = zaposleni_id JOIN Usluga ON Usluga.id = usluga_id");
            dataGridView1.DataSource = podaci;
        }

    }
}
