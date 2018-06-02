using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.Models { 

    public class EmployeeModelView:User
    {
        private int age;
        private string telephone;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }
        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
            }
        }
    }
}
