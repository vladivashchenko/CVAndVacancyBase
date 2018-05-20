using CVAndVacancyBase.BLL.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.DTO
{
    public class User: Entity
    {
        private string email;
        private string password;
        private string name;
        private bool admin;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public bool Admin { get => admin; set => admin = value; }
    }
}
