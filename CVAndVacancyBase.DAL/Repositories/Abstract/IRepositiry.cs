using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DLL.Repositories.Abstract
{
    interface IRepositiry<T>
        where T:class
    {
        IEnumerable<T> GetList(); 
        T Get(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id);    
    }
}
