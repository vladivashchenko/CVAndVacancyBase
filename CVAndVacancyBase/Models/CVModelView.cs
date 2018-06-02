using CVAndVacancyBase.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.Models
{
    public class CVModelView : Entity
    {
        private string position;
        private string skills;
        private string education;
        private string workingExperience;
        private string goal;
        private string language;


        public int? EmployeeId { get; set; }

        public string Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }
        public string Skills
        {
            get { return skills; }
            set
            {
                skills = value;
            }
        }
        public string Education
        {
            get { return education; }
            set
            {
                education = value;
            }
        }
        public string WorkingExperience
        {
            get { return workingExperience; }
            set
            {
                workingExperience = value;
            }
        }
        public string Goal
        {
            get { return goal; }
            set
            {
                goal = value;
            }
        }
        public string Language
        {
            get { return language; }
            set
            {
                language = value;
            }
        }

    }
}
