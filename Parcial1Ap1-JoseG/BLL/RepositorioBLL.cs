using Parcial1Ap1_JoseG.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Ap1_JoseG.BLL
{
    public class RepositorioBLL
    {
        public static bool Guardar(Empleados nuevo)
        {
            bool emp = false;
            using (var db = new Repositorio<Empleados>())
            {
                emp = db.Guardar(nuevo) != null;
            }
            return emp;
        }

        public static bool Eliminar(Empleados id)
        {
            bool resul = false;
            using (var db = new Repositorio<Empleados>())
            {
                resul = db.Eliminar(id);
            }
            return resul;
        }
    }
}
