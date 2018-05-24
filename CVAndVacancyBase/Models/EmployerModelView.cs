using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.Models
{
    public class EmployerModelView:User
    {
        string location;

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
            }
        }
    }
}
