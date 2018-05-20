using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVAndVacancyBase.DAL.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVAndVacancyBase.DAL.Entities
{
    public class CV : Entity
    {
        private string position;
        private string skills;
        private string education;
        private string workingExperience;
        private string goal;
        private string language;
        private Employee employee;


        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public string Position { get => position; set => position = value; }
        public string Skills { get => skills; set => skills = value; }
        public string Education { get => education; set => education = value; }
        public string WorkingExperience { get => workingExperience; set => workingExperience = value; }
        public string Goal { get => goal; set => goal = value; }
        public string Language { get => language; set => language = value; }
        public Employee Employee { get => employee; set => employee = value; }
    }
}
