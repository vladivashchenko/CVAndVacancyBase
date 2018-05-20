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
    class EmployeeRepository:IRepositiry<Employee>
    {
        private ModelContext db;

        public EmployeeRepository(ModelContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> GetList()
        {
            return db.Employees;
        }
        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }
        public void Create(Employee Emp)
        {
            db.Employees.Add(Emp);
        }
        public void Update(Employee Emp)
        {
            db.Entry(Emp).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Employee Emp = db.Employees.Find(id);
            if (Emp != null)
                db.Employees.Remove(Emp);
        }
    }
}
