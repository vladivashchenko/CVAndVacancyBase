using CVAndVacancyBase.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.DTO
{
    public class UserDTO: Entity
    {
        public enum Roles { Admin, Employer, Employee };
        private string email;
        private string password;
        private string name;
        private string address;
        private string telephone;
        private Roles role;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public Roles Role { get => role; set => role = value; }
        public string Address { get => address; set => address = value; }
    }
}


