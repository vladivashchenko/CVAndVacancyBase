using CVAndVacancyBase.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.Models
{
    public class VacancyModelView : Entity
    {
        private string name;
        private Decimal salary;

        public int? EmployerId { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                salary = value;
            }
        }
    }
}
