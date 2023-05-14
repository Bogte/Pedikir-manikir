using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pedikir_manikir
{
    public partial class Slobodni_termini : Form
    {
        DataTable podaci;

        public Slobodni_termini()
        {
            InitializeComponent();
        }

        private void Slobodni_termini_Load(object sender, EventArgs e)
        {
            DataTable pom = new DataTable();//Dodavanje zaposlenih
            pom = Konekcija.Unos("SELECT DISTINCT Ime + ' ' + Prezime AS 'Z' FROM Zaposleni");
            string[] pomocna = new string[pom.Rows.Count];
            for (int i = 0; i < pom.Rows.Count; i++)
            {
                pomocna[i] = Convert.ToString(pom.Rows[i]["Z"]);
                comboBox1.Items.Add(pomocna[i]);
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            Osvezi();
        }

        private void Osvezi()
        {
            dataGridView1.Rows[0].Cells["Vreme"].Value = "8:00AM";
            dataGridView1.Rows[1].Cells["Vreme"].Value = "9:00AM";
            dataGridView1.Rows[2].Cells["Vreme"].Value = "10:00AM";
            dataGridView1.Rows[3].Cells["Vreme"].Value = "11:00AM";
            dataGridView1.Rows[4].Cells["Vreme"].Value = "12:00AM";
            dataGridView1.Rows[5].Cells["Vreme"].Value = "1:00PM";
            dataGridView1.Rows[6].Cells["Vreme"].Value = "2:00PM";
            dataGridView1.Rows[7].Cells["Vreme"].Value = "3:00PM";
            dataGridView1.Rows[8].Cells["Vreme"].Value = "4:00PM";

            dataGridView1.Rows[0].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[1].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[2].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[3].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[4].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[5].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[6].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[7].Cells["Slobodno"].Value = false;
            dataGridView1.Rows[8].Cells["Slobodno"].Value = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Osvezi();

            if (textBox1.Text != "" && comboBox2.Text != "")
            {
                string[] zaposleni = comboBox1.Text.Split();
                podaci = new DataTable();
                podaci = Konekcija.Unos("SELECT id FROM Zaposleni WHERE ime = '" + zaposleni[0] + "' AND prezime = '" + zaposleni[1] + "'");
                int zaposleni_id = (int)podaci.Rows[0][0];

                podaci = new DataTable();
                podaci = Konekcija.Unos("SELECT RIGHT(datum_vreme, 7) AS 'Vreme' FROM Rezervacija WHERE convert(varchar(11), datum_vreme) = '" + comboBox2.Text + " " + textBox1.Text + "' AND zaposleni_id = " + zaposleni_id);
                for (int i = 0; i < podaci.Rows.Count; i++)
                {
                    for (int j = 0; j <= 8; j++)
                    {
                        if ((string)dataGridView1.Rows[j].Cells["Vreme"].Value == Convert.ToString(podaci.Rows[i]["Vreme"]).Trim())
                        {
                            dataGridView1.Rows[j].Cells["Slobodno"].Value = true;
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Osvezi();

            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                string[] zaposleni = comboBox1.Text.Split();
                podaci = new DataTable();
                podaci = Konekcija.Unos("SELECT id FROM Zaposleni WHERE ime = '" + zaposleni[0] + "' AND prezime = '" + zaposleni[1] + "'");
                int zaposleni_id = (int)podaci.Rows[0][0];

                podaci = new DataTable();
                podaci = Konekcija.Unos("SELECT RIGHT(datum_vreme, 7) AS 'Vreme' FROM Rezervacija WHERE convert(varchar(11), datum_vreme) = '" + comboBox2.Text + " " + textBox1.Text + "' AND zaposleni_id = " + zaposleni_id);
                for (int i = 0; i < podaci.Rows.Count; i++)
                {
                    for (int j = 0; j <= 8; j++)
                    {
                        if ((string)dataGridView1.Rows[j].Cells["Vreme"].Value == Convert.ToString(podaci.Rows[i]["Vreme"]).Trim())
                        {
                            dataGridView1.Rows[j].Cells["Slobodno"].Value = true;
                        }
                    }
                }
            }
        }
    }
}
