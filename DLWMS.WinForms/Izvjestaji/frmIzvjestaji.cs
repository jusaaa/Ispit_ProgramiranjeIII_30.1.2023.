using DLWMS.WinForms.IspitIB210156;
using Microsoft.Reporting.WinForms;

namespace DLWMS.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private dtoUvjerenje dtoUvjerenje;

        public frmIzvjestaji(dtoUvjerenje dtoUvjerenje)
        {
            InitializeComponent();
            this.dtoUvjerenje = dtoUvjerenje;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {       
            var rpc=new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImePrezime", dtoUvjerenje.ImePrezime));
            rpc.Add(new ReportParameter("BrojIndeksa", dtoUvjerenje.BrojIndeksa));
            rpc.Add(new ReportParameter("VrstaUvjerenja", dtoUvjerenje.Vrsta));
            rpc.Add(new ReportParameter("svrha", dtoUvjerenje.Svrha));

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.RefreshReport();
        }
    }
}
