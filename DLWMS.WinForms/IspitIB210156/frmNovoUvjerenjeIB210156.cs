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
using DLWMS.WinForms.Helpers;
using DLWMS.Data.IspitIB210156;

namespace DLWMS.WinForms.IspitIB210156
{
    public partial class frmNovoUvjerenjeIB210156 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        private Student student;

        public frmNovoUvjerenjeIB210156(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private bool ValidirajFormu()
        {
            if (!Validator.ValidirajKontrolu(cmbVrstaUvjerenja, errorProvider1, "Odaberite vrstu uvjerenja!"))
            {
                return false;
            }
            if (!Validator.ValidirajKontrolu(txtSvrhaIzdavanja, errorProvider1, "Unesite svrhu izdavanja!"))
            {
                return false;
            }
            if (!Validator.ValidirajKontrolu(pbUplatnica, errorProvider1, "Unesite sliku uplatnice!"))
            {
                return false;
            }
            return true;
        }

        private void pbUplatnica_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbUplatnica.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            UnesiPodatkeUBazu();
        }

        private void UnesiPodatkeUBazu()
        {
           if(!ValidirajFormu())
            {
                MessageBox.Show("Molimo Vas unesite sve potrebne podatke!","Pogrešan unos",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
                return;
            }
            StudentiUvjerenjaIB210156 studentiUvjerenja = new StudentiUvjerenjaIB210156
            {
                StudentId=this.student.Id,
                VrijemeKreiranja=DateTime.Now,
                VrstaUvjerenja=cmbVrstaUvjerenja.Text,
                SvrhaUvjerenja=txtSvrhaIzdavanja.Text,
                Uplatnica=ImageHelper.FromImageToByte(pbUplatnica.Image),
                Printano=0
            };
            db.StudentiUvjerenjaIB210156.Add(studentiUvjerenja);
            db.SaveChanges();
            this.Close();
        }
    }
}
