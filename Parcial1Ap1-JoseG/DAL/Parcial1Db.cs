using Parcial1Ap1_JoseG.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Ap1_JoseG.DAL
{
    public class Parcial1Db : DbContext
    {
        public Parcial1Db() : base("ConStr")
        {

        }
        public DbSet<Empleados> Empleados {get; set; }
    }
}
