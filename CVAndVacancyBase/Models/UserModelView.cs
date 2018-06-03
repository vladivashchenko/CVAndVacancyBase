using CVAndVacancyBase.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.Models
{
    public class UserModelView : Entity
    {
        public enum Roles { Admin, Employer, Employee };
        private string email;
        private string password;
        private string name;
        private string address;
        private string telephone;
        private Roles role;

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
        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
            }
        }
        public Roles Role
        {
            get { return role; }
            set
            {
                role = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }
    }
}
