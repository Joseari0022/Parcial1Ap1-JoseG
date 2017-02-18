using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1Ap1_JoseG.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Parcial1Ap1_JoseG.BLL
{
    public class Repositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Parcial1Db Context = null;

        public Repositorio()
        {
            Context = new Parcial1Db();
        }

        private DbSet<TEntity> EntitySet
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        public TEntity Guardar(TEntity e)
        {
            TEntity resul = null;
            try
            {
                EntitySet.Add(e);
                Context.SaveChanges();
                resul = e;
            }catch(Exception)
            {
                throw;
            }
            return resul;
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> id)
        {
            TEntity ret = null;
            try
            {
                ret = EntitySet.FirstOrDefault(id);
            }
            catch(Exception)
            {
                throw;
            }
            return ret;
        }

        public bool Eliminar(TEntity id)
        {
            bool resul = false;
            try
            {
                EntitySet.Attach(id);
                EntitySet.Remove(id);
                resul = Context.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            return resul;
        }

        public List<TEntity> GetList()
        {
            try
            {
                return EntitySet.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TEntity> GetListNombre(Expression<Func<TEntity, bool>> nombre)
        {
            try
            {
                return EntitySet.Where(nombre).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TEntity> GetListFecha(Expression<Func<TEntity, bool>> fecha)
        {
            try
            {
                return EntitySet.Where(fecha).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
