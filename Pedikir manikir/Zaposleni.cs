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

namespace Pedikir_manikir
{
    public partial class Zaposleni : Form
    {
        DataTable podaci, pom;
        SqlCommand menjanja;

        public Zaposleni()
        {
            InitializeComponent();
        }

        private void Zaposleni_Load(object sender, EventArgs e)
        {
            Osvezi();

            pom = new DataTable();//Dodavanje
            pom = Konekcija.Unos("SELECT DISTINCT Uloga FROM Plata");
            string[] pomocna = new string[pom.Rows.Count];
            for (int i = 0; i < pom.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(pom.Rows[i]["Uloga"]);
                comboBox2.Items.Add(pomocna[i]);
            }
        }

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Zaposleni.id, ime, prezime, Datum_zaposlenja, JMBG, Telefon, Adresa, Email, Plata.Uloga, Plata.Plata, lozinka FROM Zaposleni JOIN Plata ON Plata.id = Zaposleni.plata_id");
            dataGridView1.DataSource = podaci;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int indeks = dataGridView1.CurrentRow.Index;

                textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Id"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Ime"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Prezime"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Datum_zaposlenja"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["JMBG"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Telefon"].Value);
                textBox7.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Adresa"].Value);
                textBox8.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Email"].Value);
                textBox9.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Plata"].Value);
                comboBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Uloga"].Value);
                textBox10.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Lozinka"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "Pedikir manikir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    menjanja = new SqlCommand();
                    menjanja.CommandText = ("DELETE FROM Zaposleni WHERE id = " + textBox1.Text);

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "Pedikir manikir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                        throw new Exception();

                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT id FROM Plata WHERE Uloga = '" + comboBox2.Text + "'");
                    int plata_id = (int)podaci.Rows[0][0];

                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT * FROM Zaposleni WHERE ime = '" + textBox2.Text + "' AND prezime = '" + textBox3.Text + "' AND Datum_zaposlenja = '" + textBox4.Text + "' AND Adresa = '" + textBox7.Text + "' AND JMBG = '" + textBox5.Text + "' AND Telefon = '" + textBox6.Text + "' AND Email = '" + textBox8.Text + "' AND Lozinka = " + textBox10.Text + " AND plata_id = " + plata_id);
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    podaci = Konekcija.Unos("SELECT * FROM Zaposleni WHERE JMBG = '" + textBox5.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    podaci = Konekcija.Unos("SELECT * FROM Zaposleni WHERE Telefon = '" + textBox6.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    podaci = Konekcija.Unos("SELECT * FROM Zaposleni WHERE Email = '" + textBox8.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    menjanja = new SqlCommand();
                    menjanja.CommandText = ("INSERT INTO Zaposleni VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', " + textBox10.Text + ", " + plata_id + ")");

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
                MessageBox.Show("Ne mozete da dodate vec postojece podatke! - " + ex.Source, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlConnection con = new SqlConnection(Konekcija.Veza());
                con.Close();
                Osvezi();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT Plata FROM Plata WHERE Uloga = '" + comboBox2.Text + "'");
            textBox9.Text = Convert.ToString(podaci.Rows[0][0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "Pedikir manikir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "" || textBox9.Text == "" || comboBox2.Text == "")
                        throw new Exception();

                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT id FROM Plata WHERE Uloga = '" + comboBox2.Text + "'");
                    int plata_id = (int)podaci.Rows[0][0];

                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT * FROM Zaposleni WHERE ime = '" + textBox2.Text + "' AND prezime = '" + textBox3.Text + "' AND Datum_zaposlenja = '" + textBox4.Text + "' AND Adresa = '" + textBox7.Text + "' AND JMBG = '" + textBox5.Text + "' AND Telefon = '" + textBox6.Text + "' AND Email = '" + textBox8.Text + "' AND Lozinka = " + textBox10.Text + " AND plata_id = " + plata_id);
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    if (textBox5.Text.Length != 13) throw new Exception();

                    menjanja = new SqlCommand();
                    menjanja.CommandText = ("UPDATE Zaposleni SET Ime = '" + textBox2.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET Prezime = '" + textBox3.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET Datum_zaposlenja = '" + textBox4.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET JMBG = '" + textBox5.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET Telefon = '" + textBox6.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET Adresa = '" + textBox7.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET Email = '" + textBox8.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET Lozinka = " + textBox10.Text + " WHERE id = " + textBox1.Text +
                        " UPDATE Zaposleni SET plata_id = " + plata_id + " WHERE id = " + textBox1.Text);

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
    }
}
