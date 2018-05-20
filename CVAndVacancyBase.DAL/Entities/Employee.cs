using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL.Entities
{
    public class Employee : User
    {
        private int age;
        private string telephone;
        private ICollection<CV> cves;

        public int Age { get => age; set => age = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public virtual ICollection<CV> CVes { get => cves; set => cves = value; }
    }       
}
