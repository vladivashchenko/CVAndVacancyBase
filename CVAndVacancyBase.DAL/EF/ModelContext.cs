using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CVAndVacancyBase.DAL.Entities;

namespace CVAndVacancyBase.DAL.EF
{
    public class ModelContext : DbContext
    {
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<CV> CVes { get; set; }


        public ModelContext(string connection) : base(connection)
        {
        }
        static ModelContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CV>()
                .HasRequired(cv => cv.Employee)
                .WithMany(e => e.CVes)
                .HasForeignKey(m => m.EmployeeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Vacancy>()
                .HasRequired(v => v.Employer)
                .WithMany(o => o.Vacancies)
                .HasForeignKey(o => o.EmployerId)
                .WillCascadeOnDelete(true);
        }
    }
}