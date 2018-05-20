using CVAndVacancyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CV> CVes { get; }
        IRepository<Vacancy> Vacancies { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Employer> Employers { get; }

        void Save();
    }
}
