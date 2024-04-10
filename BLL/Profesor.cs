using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Profesor
    {
        public int id {  get; set; }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string apelldio { get; set; }
        public double HorasTrabajadas { get; set; }
        public double PrecioHoras { get; set; }
        public double AFP { get; set; }
        public double SS { get; set; }
        public double totalDescuento { get; set; }
        public double sueldoBase { get; set; }
        public double sueldoNeto { get; set; }

        public void CalcularSueldo()
        {
            sueldoBase = PrecioHoras * HorasTrabajadas;
            CalcularDescuento();
            sueldoNeto = sueldoBase - totalDescuento;
        }

        public void CalcularDescuento()
        {
            SS = sueldoBase * 0.03;
            AFP = sueldoBase * 0.04;
            totalDescuento = SS + AFP;
        }
    }
}
