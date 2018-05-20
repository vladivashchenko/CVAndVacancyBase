using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.DTO
{
    public class EmployerDTO:User
    {
        string location;

        public string Location { get => location; set => location = value; }
    }
}
