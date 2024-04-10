using BLL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class frmVisorReportes : Form
    {
        public frmVisorReportes()
        {
            InitializeComponent();
        }

        private void frmVisorReportes_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void Imprimir(string nombreReporte, string titulo,  List<Profesor> listaProfesor)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = nombreReporte;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsProfesor", listaProfesor));

            ReportParameter miparametroTitulo = new ReportParameter("Titulo", titulo.ToString());
            this.reportViewer1.LocalReport.SetParameters(miparametroTitulo);
            this.reportViewer1.RefreshReport();
            this.Show();
        }
    }
}
