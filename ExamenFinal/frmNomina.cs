using BLL;
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
    public partial class frmNomina : Form
    {
        Nomina objNomina = new Nomina();

        public frmNomina()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals("") && txtApellido.Text.Equals("") && txtHT.Text.Equals("") && txtPH.Text.Equals(""))
            {
                MessageBox.Show("Algunos cuadros estan vacio.");
            }
            else
            {
                Profesor objProfesor = new Profesor();
                objProfesor.nombre = txtNombre.Text;
                objProfesor.apelldio = txtApellido.Text;
                objProfesor.HorasTrabajadas = Convert.ToDouble(txtHT.Text);
                objProfesor.PrecioHoras = Convert.ToDouble(txtPH.Text);
                objProfesor.CalcularSueldo();
                objNomina.AgregarProfesor(objProfesor);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = objNomina.ListarProfesor();

                //Para Darle Formato de DINERO a las Columnas
                dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[9].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[10].DefaultCellStyle.Format = "c";
                limpiar();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int id;
            int countList = objNomina.ListarProfesor().Count();

            if (countList > 0)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            else
            {
                return;
            }

            if (id > 0)
            {
                var resp = MessageBox.Show("Seguro que desea borrar este prodesor de la nomina?", "CONFIMACION DE ELIMINACION", MessageBoxButtons.YesNo);
                if (resp == DialogResult.Yes)
                {
                    Profesor profesor = new Profesor();
                    profesor = objNomina.listaProfesores.Find(x => x.id == id);
                    objNomina.BorrarProfesor(profesor);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = objNomina.ListarProfesor();
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CONFIMACION DE ELIMINACION", MessageBoxButtons.OK);
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmVisorReportes objvisor = new frmVisorReportes();

            List<Profesor> listaProfesor = objNomina.ListarProfesor();

            string nombreReporte = "ExamenFinal.Reportes.NominaRPT.rdlc";
            string titulo = "NOMINA DE PROFESORES";

            objvisor.Imprimir(nombreReporte, titulo, listaProfesor);
        }

        private void limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtHT.Text = string.Empty;
            this.txtPH.Text = string.Empty;
        }
    }
}
