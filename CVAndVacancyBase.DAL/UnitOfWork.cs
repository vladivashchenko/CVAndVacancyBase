using CVAndVacancyBase.DAL.EF;
using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ModelContext db;
        private IRepository<CV> cvRepository;
        private IRepository<Vacancy> vacancyRepository;
        private IRepository<Employee> employeeRepository;
        private IRepository<Employer> employerRepository;

        public UnitOfWork(string connectionString)
        {
            db = new ModelContext(connectionString);
        }
        public IRepository<CV> CVes
        {
            get
            {
                if (cvRepository == null)
                    cvRepository = new CVRepository(db);
                return cvRepository;
            }
        }

        public IRepository<Vacancy> Vacancies
        {
            get
            {
                if (vacancyRepository == null)
                    vacancyRepository = new VacancyRepository(db);
                return vacancyRepository;
            }
        }
        public IRepository<Employer> Employers
        {
            get
            {
                if (employerRepository == null)
                    employerRepository = new EmployerRepository(db);
                return employerRepository;
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}