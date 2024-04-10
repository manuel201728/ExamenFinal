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
    public partial class frmFactura : Form
    {
        Factura objFactura = new Factura();

        public frmFactura()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text.Equals("") && txtProducto.Text.Equals("") && txtCantidad.Text.Equals("") && txtPrecio.Text.Equals(""))
            {
                MessageBox.Show("Algunos cuadros estan vacio.");
            }
            else
            {
                DetFactura objDetFactura = new DetFactura();
                objFactura.Cliente = txtCliente.Text;
                objDetFactura.Producto = txtProducto.Text;
                objDetFactura.Cantidad = Convert.ToInt32(txtCantidad.Text);
                objDetFactura.Precio = Convert.ToDouble(txtPrecio.Text);
                objFactura.AgregarDetFactur(objDetFactura);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = objFactura.ListarProducto();

                //Para Darle Formato de DINERO a las Columnas
                dataGridView1.Columns[3].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[4].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[6].DefaultCellStyle.Format = "c";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "c";
                limpiar();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int id;
            int countList = objFactura.ListarProducto().Count();

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
                    DetFactura detFactura = new DetFactura();
                    detFactura = objFactura.ListaDetalle.Find(x => x.Id == id);
                    objFactura.QuitarProducto(detFactura);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = objFactura.ListarProducto();
                    MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "CONFIMACION DE ELIMINACION", MessageBoxButtons.OK);
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmVisorReportes objvisor = new frmVisorReportes();

            List<DetFactura> listaDetFactura = objFactura.ListarProducto();

            string nombreReporte = "ExamenFinal.Reportes.FacturaRPT.rdlc";
            string encabezado = "COMERCIAL H&E\r\nCalle colon # 25, mercado\r\npúblico de Barahona, R.D";
            string data = "Factura No.: 01\r\nCliente: " + objFactura.Cliente;
            string pie = "****** GRACIAS POR SU COMPRA ******";

            objvisor.ImprimirFactura(nombreReporte, encabezado, data, listaDetFactura, pie);


            limpiar();
            this.txtCliente.Text = string.Empty;
        }

        private void limpiar()
        {
            this.txtProducto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
        }
    }
}
