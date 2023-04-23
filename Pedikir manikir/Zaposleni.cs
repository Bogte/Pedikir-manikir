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
        DataTable podaci;
        SqlCommand menjanja;

        public Zaposleni()
        {
            InitializeComponent();
        }

        private void Zaposleni_Load(object sender, EventArgs e)
        {
            Osvezi();
        }

        private void Osvezi()
        {
            podaci = new DataTable();
            podaci = Konekcija.Unos("SELECT ime, prezime, Datum_zaposlenja, JMBG, Telefon, Adresa, Email, Plata.Uloga, Plata.Plata, lozinka FROM Zaposleni JOIN Plata ON Plata.id = Zaposleni.plata_id");
            dataGridView1.DataSource = podaci;
        }

    }
}
