using DLWMS.Data;
using DLWMS.Data.IspitIB210156;
using DLWMS.WinForms.Izvjestaji;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IspitIB210156
{
    public partial class frmUvjerenjaIB210156 : Form
    {
        private Student student;
        DLWMSDbContext db = new DLWMSDbContext();

        public frmUvjerenjaIB210156(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void frmUvjerenjaIB210156_Load(object sender, EventArgs e)
        {
            UcitajUvjerenjaStudenta();
        }

        private void UcitajUvjerenjaStudenta()
        {
            var uvjerenja = db.StudentiUvjerenjaIB210156.Where(s => s.StudentId == student.Id).ToList();

            int brojUvjerenja = uvjerenja.Count();
            if (brojUvjerenja == 0)
            {
                btnDodaj.Enabled = false;
            }
            this.Text = $"Broj uvjerenja -> {brojUvjerenja}";

            dgvUvjerenja.Rows.Clear();
            foreach (var uvj in uvjerenja)
            {

                dgvUvjerenja.Rows.Add(
                 uvj.Id,
                 uvj.VrijemeKreiranja,
                 uvj.VrstaUvjerenja,
                 uvj.SvrhaUvjerenja,
                 uvj.Uplatnica,
                 uvj.Printano
                 );
            }
            dgvUvjerenja.Refresh();
        }
        private void ObrisiUvjerenje(int uvjerenjeId)
        {
            var uvjerenje = db.StudentiUvjerenjaIB210156.Find(uvjerenjeId);
            if (uvjerenje != null)
            {
                db.StudentiUvjerenjaIB210156.Remove(uvjerenje);
                db.SaveChanges();
            }
        }

        private void dgvUvjerenja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvUvjerenja.Columns["Brisi"].Index)
            {
                int uvjerenjeId = Convert.ToInt32(dgvUvjerenja.Rows[e.RowIndex].Cells["Id"].Value);
                if (MessageBox.Show("Jeste li sigurni da želite obrisati uvjerenje?", "Sigurnosna potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObrisiUvjerenje(uvjerenjeId);
                    dgvUvjerenja.Rows.RemoveAt(e.RowIndex);

                    UcitajUvjerenjaStudenta();
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvUvjerenja.Columns["Printaj"].Index)
            {
                int uvjerenjeId = Convert.ToInt32(dgvUvjerenja.Rows[e.RowIndex].Cells["Id"].Value);

                var dtoUvjerenje = new dtoUvjerenje
                {
                    ImePrezime=$"{student.Ime} {student.Prezime}",
                    BrojIndeksa=student.BrojIndeksa,
                    Svrha = dgvUvjerenja.Rows[e.RowIndex].Cells["Svrha"].Value.ToString(),
                    Vrsta = dgvUvjerenja.Rows[e.RowIndex].Cells["Vrsta"].Value.ToString()
                };
                var print = new frmIzvjestaji(dtoUvjerenje);
                print.ShowDialog();

                var uvjerenje = db.StudentiUvjerenjaIB210156.Find(uvjerenjeId);
                uvjerenje.Printano = 1;
                db.SaveChanges();
            }

        }

        private void btnNoviZahtjev_Click(object sender, EventArgs e)
        {
            frmNovoUvjerenjeIB210156 frmNovoUvjerenjeIB210156 = new frmNovoUvjerenjeIB210156(student);
            DialogResult dialogResult = frmNovoUvjerenjeIB210156.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                UcitajUvjerenjaStudenta();
            }

        }
        private byte[] DohvatiPrvuSlikuUplatnice(int studentId)
        {
            var uplatnica=db.StudentiUvjerenjaIB210156.Where(s=>s.StudentId == studentId).
                Select(s=>s.Uplatnica)
                .FirstOrDefault();

            return uplatnica;
        }
        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            int brojZahtjeva = Convert.ToInt32(txtBrojZahtjeva.Text);
            string vrstaUvjerenja = cmbVrstaUvjerenja.Text;
            string svrhaIzdavanja=txtSvrhaIzdavanja.Text;

            await (Task.Run(() => DodajUvjerenje(vrstaUvjerenja,svrhaIzdavanja,brojZahtjeva)));

            UcitajUvjerenjaStudenta();
        }

        private void DodajUvjerenje(string vrstaUvjerenja, string svrhaIzdavanja, int brojZahtjeva)
        {
            for (int i = 0; i < brojZahtjeva; i++)
            {
                StudentiUvjerenjaIB210156 studentiUvjerenja = new StudentiUvjerenjaIB210156
                {
                    StudentId = student.Id,
                    VrijemeKreiranja=DateTime.Now,
                    VrstaUvjerenja=vrstaUvjerenja,
                    SvrhaUvjerenja=svrhaIzdavanja,
                    Uplatnica=DohvatiPrvuSlikuUplatnice(student.Id),
                    Printano=0
                };
                db.StudentiUvjerenjaIB210156.Add(studentiUvjerenja);
                db.SaveChanges();

                string formatVremena = "HH:mm:ss";
                string novaPoruka = $"{DateTime.Now.ToString(formatVremena)} -> {vrstaUvjerenja} ({student.BrojIndeksa}) - {student.Ime} {student.Prezime} u svrhu {svrhaIzdavanja}{Environment.NewLine}";

                Task.Delay(300).Wait();

                Invoke(new Action(() => {
                    txtInfo.Text += novaPoruka;
                    txtInfo.SelectionStart = txtInfo.TextLength;
                    txtInfo.ScrollToCaret();
                }));        
            }
            MessageBox.Show("Dodavanje novih zahtijeva je zavrseno","Obavještenje",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
    public class dtoUvjerenje
    {
        public string ImePrezime { get; set; }
        public string BrojIndeksa { get; set; }
        public string Vrsta { get; set; }
        public string Svrha { get; set; }
    }
}
