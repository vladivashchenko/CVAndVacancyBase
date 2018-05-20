using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVAndVacancyBase.DLL.Repositories.Abstract;
using CVAndVacancyBase.DLL.EF;
using CVAndVacancyBase.DLL.Entities;
using System.Data.Entity;

namespace CVAndVacancyBase.DLL.Repositories
{
    class VacancyRepository:IRepositiry<Vacancy>
    {
        private ModelContext db;

        public VacancyRepository(ModelContext db)
        {
            this.db = db;
        }
        public IEnumerable<Vacancy> GetList()
        {
            return db.Vacancies;
        }
        public Vacancy Get(int id)
        {
            return db.Vacancies.Find(id);
        }
        public void Create(Vacancy vac)
        {
            db.Vacancies.Add(vac);
        }
        public void Update(Vacancy vac)
        {
            db.Entry(vac).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Vacancy vac = db.Vacancies.Find(id);
            if (vac != null)
                db.Vacancies.Remove(vac);
        }
    }
}
