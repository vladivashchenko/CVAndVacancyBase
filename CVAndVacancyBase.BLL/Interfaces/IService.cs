using CVAndVacancyBase.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.Interfaces
{
    public interface IService<T> where T:Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(int id);
        void Delete(int id);
    }
}
