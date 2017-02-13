using Parcial1Ap1_JoseG.DAL;
using Parcial1Ap1_JoseG.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Ap1_JoseG.BLL
{
    public class EmpleadosBll
    {
        public static bool Guardar(Empleados em)
        {
            bool retorno = false;
            try
            {
                using (var db = new Parcial1Db())
                {
                    if (Buscar(em.EmpleadoId) == null)
                    {
                        db.Empleados.Add(em);
                    }   
                    else
                    {
                        db.Entry(em).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public static bool Eliminar(Empleados e)
        {
            try
            {
                Parcial1Db db = new Parcial1Db();
                Empleados em = db.Empleados.Find(e);
                {
                    db.Empleados.Remove(e);
                    db.SaveChanges();
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
                throw;
            }
        }

        public static bool Eliminar(int v)
        {
            Parcial1Db db = new Parcial1Db();
            Empleados us = db.Empleados.Find(v);
            try
            {
                db.Empleados.Remove(us);
                db.SaveChanges();
                return false;
            }
            catch (Exception e)
            {
                return true;
                throw e;
            }
        }

        public static Empleados Buscar(int Id)
        {
            try
            {
                Parcial1Db db = new Parcial1Db();
                {
                    return db.Empleados.Find(Id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Empleados> GetLista()
        {
            List<Empleados> lista = new List<Empleados>();
            Parcial1Db db = new Parcial1Db();
            lista = db.Empleados.ToList();
            return lista;
        }

        public static List<Empleados> GetListaId(int empleadoid)
        {
            List<Empleados> lista = new List<Empleados>();
            Parcial1Db db = new Parcial1Db();
            lista = db.Empleados.Where(p => p.EmpleadoId == empleadoid).ToList();
            return lista;
        }

        public static List<Empleados> GetListaNombreEmpleado(string aux)
        {
            List<Empleados> lista = new List<Empleados>();
            Parcial1Db db = new Parcial1Db();
            lista = db.Empleados.Where(p => p.Nombres == aux).ToList();
            return lista;
        }

        public static List<Empleados> GetListaFecha(DateTime Desde, DateTime Hasta)
        {
            List<Empleados> lista = new List<Empleados>();
            Parcial1Db db = new Parcial1Db();
            lista = db.Empleados.Where(p => p.FechaNacimiento >= Desde && p.FechaNacimiento <= Hasta).ToList();
            return lista;
        }

        public static List<Empleados> GetListaSueldo(float aux)
        {
            List<Empleados> lista = new List<Empleados>();
            Parcial1Db db = new Parcial1Db();
            lista = db.Empleados.Where(p => p.Sueldo == aux).ToList();
            return lista;
        }
    }
}
