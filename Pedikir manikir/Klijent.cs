using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pedikir_manikir
{
    public partial class Klijent : Form
    {
        DataTable podaci;
        SqlCommand menjanja;

        public Klijent()
        {
            InitializeComponent();
        }

        private void Klijent_Load(object sender, EventArgs e)
        {
            Osvezi();   
        }

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT * FROM Klijent");
            dataGridView1.DataSource = podaci;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int indeks = dataGridView1.CurrentRow.Index;

                textBox1.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["id"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Ime"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Prezime"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Datum_rodjenja"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["JMBG"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Telefon"].Value);
                textBox7.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Adresa"].Value);
                textBox8.Text = Convert.ToString(dataGridView1.Rows[indeks].Cells["Email"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ove podatake?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    menjanja = new SqlCommand();
                    menjanja.CommandText = ("DELETE FROM Klijent WHERE id = " + textBox1.Text);

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
                if (MessageBox.Show("Da li ste sigurni da zelite da izmenite ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                        throw new Exception();

                    menjanja = new SqlCommand();

                    podaci = new DataTable();

                    podaci = Konekcija.Unos("SELECT * FROM Klijent WHERE ime = '" + textBox2.Text + "' AND prezime = '" + textBox3.Text + "' AND Datum_rodjenja = '" + textBox4.Text + "' AND Adresa = '" + textBox7.Text + "' AND JMBG = '" + textBox5.Text + "' AND Telefon = '" + textBox6.Text + "' AND Email = '" + textBox8.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();
                    
                    if (textBox5.Text.Length != 13) throw new Exception();

                    menjanja.CommandText = ("UPDATE Klijent SET Ime = '"+ textBox2.Text + "' WHERE id = " + textBox1.Text + 
                        " UPDATE Klijent SET Prezime = '" + textBox3.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Klijent SET Datum_rodjenja = '" + textBox4.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Klijent SET JMBG = '" + textBox5.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Klijent SET Telefon = '" + textBox6.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Klijent SET Adresa = '" + textBox7.Text + "' WHERE id = " + textBox1.Text +
                        " UPDATE Klijent SET Email = '" + textBox8.Text + "' WHERE id = " + textBox1.Text);


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
                if (MessageBox.Show("Da li ste sigurni da zelite da dodate ove podatke?", "EsDnevnik", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                        throw new Exception();

                    podaci = new DataTable();
                    podaci = Konekcija.Unos("SELECT * FROM Klijent WHERE ime = '" + textBox2.Text + "' AND prezime = '" + textBox3.Text + "' AND Datum_rodjenja = '" + textBox4.Text + "' AND Adresa = '" + textBox7.Text + "' AND JMBG = '" + textBox5.Text + "' AND Telefon = '" + textBox6.Text + "' AND Email = '" + textBox8.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    podaci = Konekcija.Unos("SELECT * FROM Klijent WHERE JMBG = '" + textBox5.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    podaci = Konekcija.Unos("SELECT * FROM Klijent WHERE Telefon = '" + textBox6.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    podaci = Konekcija.Unos("SELECT * FROM Klijent WHERE Email = '" + textBox8.Text + "'");
                    if (podaci.Rows.Count >= 1) throw new Exception();

                    menjanja = new SqlCommand();
                    menjanja.CommandText = ("INSERT INTO Klijent VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "')");

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
    }
}
