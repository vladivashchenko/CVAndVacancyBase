using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.DTO
{
    public class EmployeeDTO:User
    {
        private int age;
        private string telephone;

        public int Age { get => age; set => age = value; }
        public string Telephone { get => telephone; set => telephone = value; }
    }
}
