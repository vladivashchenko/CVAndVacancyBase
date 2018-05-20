using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CVAndVacancyBase.DLL.Repositories.Abstract;
using CVAndVacancyBase.DLL.EF;
using CVAndVacancyBase.DLL.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DLL.Repositories
{
    class EmployerRepository:IRepositiry<Employer>
    {
        private ModelContext db;

        public EmployerRepository(ModelContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employer> GetList()
        {
            return db.Employers;
        }
        public Employer Get(int id)
        {
            return db.Employers.Find(id);
        }
        public void Create(Employer Emr)
        {
            db.Employers.Add(Emr);
        }
        public void Update(Employer Emr)
        {
            db.Entry(Emr).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Employer Emr = db.Employers.Find(id);
            if (Emr != null)
                db.Employers.Remove(Emr);
        }
    }
}
