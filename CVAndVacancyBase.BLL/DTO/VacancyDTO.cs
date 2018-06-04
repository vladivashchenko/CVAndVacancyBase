using CVAndVacancyBase.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.DTO
{
    public class VacancyDTO : Entity
    {
        private string name;
        private Decimal salary;

        public int? EmployerId { get; set; }
        public string Name { get => name; set => name = value; }
        public decimal Salary { get => salary; set => salary = value; }
    }
}
