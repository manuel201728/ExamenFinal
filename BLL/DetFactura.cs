using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetFactura
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Impuesto { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

    }
}
