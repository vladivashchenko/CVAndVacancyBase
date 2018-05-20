using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVAndVacancyBase.DLL.Entities.Abstract;

namespace CVAndVacancyBase.DLL.Entities
{
    public class User : Entity
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

