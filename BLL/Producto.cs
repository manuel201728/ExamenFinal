using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Producto
    {
        public List<Ingrediente> listaIngrediente = new List<Ingrediente>();

        public void AgregarProfesor(Ingrediente ingrediente)
        {
            if (listaIngrediente.Count > 0)
            {
                Ingrediente ingrediente1 = listaIngrediente.Last();
                ingrediente.id = ingrediente1.id + 1;
            }
            else
            {
                ingrediente.id = 1;
            }

            listaIngrediente.Add(ingrediente);
        }

        public List<Ingrediente> ListarProfesor()
        {
            return listaIngrediente;
        }

        public void BorrarProfesor(Ingrediente ingrediente)
        {
            listaIngrediente.Remove(ingrediente);
        }
    }
}
