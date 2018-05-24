using CVAndVacancyBase.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.Models
{
    public class User: Entity
    {
        private string email;
        private string password;
        private string name;
        private bool admin;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public bool Admin
        {
            get { return admin; }
            set
            {
                admin = value;
            }
        }
    }
}
