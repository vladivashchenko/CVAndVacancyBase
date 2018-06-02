using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVAndVacancyBase.DAL.Entities.Abstract;

namespace CVAndVacancyBase.DAL.Entities
{
    public class User : Entity
    {
        public enum Roles { Admin,Employer,Employee};
        private string email;
        private string password;
        private string name;
        private int age;
        private string location;
        private string telephone;  
        private Roles role;
        private ICollection<CV> cves;
        private ICollection<Vacancy> vacancies;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public Roles Role{ get => role; set => role = value; }
        public virtual ICollection<CV> CVes { get => cves; set => cves = value; }
        public int Age { get => age; set => age = value; }
        public string Location { get => location; set => location = value; }
        public virtual ICollection<Vacancy> Vacancies { get => vacancies; set => vacancies = value; }
    }
}

