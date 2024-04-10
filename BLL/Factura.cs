using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Factura
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }

        public DetFactura detFactura;
        public List<DetFactura> ListaDetalle = new List<DetFactura>();


        public void AgregarDetFactur(DetFactura detFactura)
        {
            this.detFactura = detFactura;

            if (ListaDetalle.Count > 0)
            {
                DetFactura detFactura1 = ListaDetalle.Last();
                detFactura.Id = detFactura1.Id + 1;
            }
            else
            {
                detFactura.Id = 1;
            }

            CalcularFactura();
            CalcularImpuesto();
            CalcularDescuento();
            CalcularTotal();
            ListaDetalle.Add(detFactura);
        }

        public void QuitarProducto(DetFactura detFactura)
        {
            ListaDetalle.Remove(detFactura);
        }

        public void CalcularFactura()
        {
            detFactura.Subtotal = detFactura.Precio * detFactura.Cantidad;
        }

        public void CalcularImpuesto()
        {
            detFactura.Impuesto = detFactura.Subtotal * 0.18;
        }

        public void CalcularDescuento()
        {
            detFactura.Descuento = detFactura.Subtotal * 0.05;
        }

        public void CalcularTotal()
        {
            detFactura.Total = detFactura.Subtotal + detFactura.Impuesto - detFactura.Descuento;
        }


        public List<DetFactura> ListarProducto()
        {
            return ListaDetalle;
        }
    }
}
