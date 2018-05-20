using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CVAndVacancyBase.DLL.Entities;

namespace CVAndVacancyBase.DLL.EF
{
    class ModelContext:DbContext
    {
        public virtual DbSet<CV> CVs { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }

        public ModelContext() 
            : base("library")
        { 
        }
    }
   
}
