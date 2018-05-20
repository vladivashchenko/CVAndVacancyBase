using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVAndVacancyBase.DLL.Repositories.Abstract;
using CVAndVacancyBase.DLL.EF;
using CVAndVacancyBase.DLL.Entities;
using CVAndVacancyBase.DLL.Repositories;
using System.Data.Entity;

namespace CVAndVacancyBase.DLL
{
    class UnitOfWork : IDisposable
    {
        private ModelContext db = new ModelContext();
        private CV_Repository CvRe;
        private VacancyRepository VaRe;
        private EmployeeRepository EmpRe;
        private EmployerRepository EmrRe;
        public CV_Repository CVs
        {
            get
            {
                if (CvRe == null)
                    CvRe = new CV_Repository(db);
                return CvRe;
            }
        }
        public VacancyRepository Vacancies
        {
            get
            {
                if (VaRe == null)
                    VaRe = new VacancyRepository(db);
                return VaRe;
            }
        }
        public EmployeeRepository Employees
        {
            get
            {
                if (EmpRe == null)
                    EmpRe = new EmployeeRepository(db);
                return EmpRe;
            }
        }
        public EmployerRepository Employers
        {
            get
            {
                if (EmrRe == null)
                    EmrRe = new EmployerRepository(db);
                return EmrRe;
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
