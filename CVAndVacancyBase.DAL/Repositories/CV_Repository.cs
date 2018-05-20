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
    class CV_Repository:IRepositiry<CV>
    {
        private ModelContext db;
        
        public CV_Repository(ModelContext db)
        {
            this.db = db;
        }
        public IEnumerable<CV> GetList()
        {
            return db.CVs;
        }
        public CV Get(int id)
        {
            return db.CVs.Find(id);
        }
        public void Create(CV cv)
        {
            db.CVs.Add(cv);
        }
        public void Update(CV cv)
        {
            db.Entry(cv).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            CV cv = db.CVs.Find(id);
            if (cv != null)
                db.CVs.Remove(cv);
        }
    }
}
