using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL.Entities
{
    public class Employer : User
    {
        string location;
        ICollection<Vacancy> vacancies;

        public string Location { get => location; set => location = value; }
        public virtual ICollection<Vacancy> Vacancies { get => vacancies; set => vacancies = value; }
    }
}
