using DLWMS.Data;
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
    public partial class frmStudentInfoIB210156 : Form
    {
        DLWMSDbContext db=new DLWMSDbContext();
        private Student student;

        public frmStudentInfoIB210156(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void frmStudentInfoIB210156_Load(object sender, EventArgs e)
        {
            this.Text=student.BrojIndeksa.ToString();
            lblImePrezime.Text = $"{student.Ime} {student.Prezime}";
            pbSlika.Image = Helpers.ImageHelper.FromByteToImage(student.Slika);
            lblProsjek.Text = $"Prosjek: {IzracunajProsjekStudenta(student.Id).ToString()}";

        }
        public double IzracunajProsjekStudenta(int studentId)
        {
            var ocjeneStudenta=db.StudentiPredmeti.Where(s=>s.StudentId==studentId)
                .Select(s=>s.Ocjena)
                .ToList();

            if (!ocjeneStudenta.Any())
            {
                return 0.0;
            }

            double prosjek = ocjeneStudenta.Average();
            double roundProsjek=Math.Round(prosjek,2);
            return roundProsjek;
        }
    }
}
