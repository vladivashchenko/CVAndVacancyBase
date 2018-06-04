using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
