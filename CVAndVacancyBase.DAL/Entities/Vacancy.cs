using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVAndVacancyBase.DAL.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVAndVacancyBase.DAL.Entities
{
    public class Vacancy : Entity
    {
        private string name;
        private Decimal salary;
        private User employer;

        [ForeignKey("Employer")]
        public int? EmployerId { get; set; }

        public string Name { get => name; set => name = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public User Employer { get => employer; set => employer = value; }
    }
}
