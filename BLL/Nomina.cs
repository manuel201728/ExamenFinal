using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Nomina
    {
        public List<Profesor> listaProfesores = new List<Profesor>();

        public void AgregarProfesor(Profesor profesor)
        {
            if (listaProfesores.Count > 0)
            {
                Profesor profesor1 = listaProfesores.Last();
                profesor.id = profesor1.id + 1;
            }
            else
            {
                profesor.id = 1;
            }

            listaProfesores.Add(profesor);
        }

        public List<Profesor> ListarProfesor()
        {
            return listaProfesores;
        }

        public void BorrarProfesor(Profesor profesor)
        {
            listaProfesores.Remove(profesor);
        }
    }
}
