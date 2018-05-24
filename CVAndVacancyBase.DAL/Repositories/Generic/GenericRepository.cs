using CVAndVacancyBase.DAL.EF;
using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.DAL.Entities.Abstract;
using CVAndVacancyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL.Repositories.Generic
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ModelContext Dbcontext;
        protected readonly IDbSet<TEntity> Dbset;

        protected GenericRepository(ModelContext context)
        {
            Dbcontext = context;
            Dbset = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Dbset.AsEnumerable();
        }

        public virtual IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Dbset.Where(predicate).AsEnumerable();
        }

        public virtual void Add(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = Dbset.Find(id);
            Dbset.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Dbcontext.Entry(entity).State = EntityState.Modified;
        }

    }
}

