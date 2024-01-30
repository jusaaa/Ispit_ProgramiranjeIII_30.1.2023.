using DLWMS.Data;
using Microsoft.EntityFrameworkCore;
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
    public partial class frmPretragaIB210156 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        public frmPretragaIB210156()
        {
            InitializeComponent();
            UcitajSpolove();
            PoveziDogadjaje();
        }

        private void PoveziDogadjaje()
        {
            cmbSpol.SelectedIndexChanged += PretraziStudente;
            dtpDatumOd.ValueChanged += PretraziStudente;
            dtpDatumDo.ValueChanged += PretraziStudente;
        }

        private void UcitajSpolove()
        {
            var spolovi = db.Spolovi.ToList();
            cmbSpol.ValueMember = "Id";
            cmbSpol.DisplayMember = "Naziv";
            cmbSpol.DataSource = spolovi;
        }

        private List<Student> PretraziStudenteUBazi(int spolID, DateTime datumOd, DateTime datumDo)
        {
            var rezultati = db.Studenti.Where(s => s.Spol.Id == spolID && s.DatumRodjenja >= datumOd && s.DatumRodjenja <= datumDo)
                .Include(s => s.Spol)
                .ToList();

            return rezultati;
        }
        private void PretraziStudente(object sender, EventArgs e)
        {
            int spolId = Convert.ToInt32(cmbSpol.SelectedValue);
            DateTime datumOd = dtpDatumOd.Value;
            DateTime datumDo = dtpDatumDo.Value;

            List<Student> rezultati = PretraziStudenteUBazi(spolId, datumOd, datumDo);
            AzurirajPrikazRezultata(rezultati);
        }

        private void AzurirajPrikazRezultata(List<Student> rezultati)
        {
            dgvPretraga.Rows.Clear();

            foreach (var student in rezultati)
            {
                var ocjeneStudenta = db.StudentiPredmeti.Where(s => s.StudentId == student.Id)
                .Select(s => s.Ocjena)
                .ToList();
                
               double prosjek = ocjeneStudenta.Average();
               double roundProsjek=Math.Round(prosjek, 2);

                dgvPretraga.Rows.Add(
                    student.Id,
                    student.BrojIndeksa,
                    $"{student.Ime} {student.Prezime}",
                    roundProsjek,
                    student.DatumRodjenja,
                    student.Aktivan
                );
            }
            dgvPretraga.Refresh();
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int studentId = Convert.ToInt32(dgvPretraga.Rows[e.RowIndex].Cells["Id"].Value);
            Student student=db.Studenti.Find(studentId);

            if (e.RowIndex >= 0 && e.ColumnIndex != dgvPretraga.Columns["Uvjerenja"].Index)
            {

                frmStudentInfoIB210156 frmStudentInfoIB210156 = new frmStudentInfoIB210156(student);
                frmStudentInfoIB210156.ShowDialog();
            }
            else
            {
                frmUvjerenjaIB210156 frmUvjerenjaIB210156=new frmUvjerenjaIB210156(student);
                frmUvjerenjaIB210156.ShowDialog();
            }
        }
    }
}
