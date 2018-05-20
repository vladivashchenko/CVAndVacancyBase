using AutoMapper;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.BLL.Infrastructure;
using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace CVAndVacancyBase.BLL.Services
{
    public class VacancyService:IService<VacancyDTO>
    {
        IUnitOfWork Database { get; set; }
        MapperConfiguration config = new AutoMapperConfiguration().Configure();

        public VacancyService(IUnitOfWork uow)
        {
            Database = uow;
            
        }
        public VacancyDTO Get(int id)
        {
            var vacancy = Database.Vacancies.Get(id);
            if (vacancy == null)
                throw new ValidationException("Not found","");
            var iMapper = config.CreateMapper();
            return iMapper.Map<Vacancy,VacancyDTO>(vacancy);
        }

        public IEnumerable<VacancyDTO> GetAll()
        {
            var iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<Vacancy>, List<VacancyDTO>>(Database.Vacancies.GetAll());
        }

        public void Add(VacancyDTO entity)
        {
            Employer employer = Database.Employers.Get(entity.EmployerId.Value);
            Vacancy vacancy = new Vacancy
            {
                Id = entity.Id,
                EmployerId = employer.Id,
                Name = entity.Name,
                Salary = entity.Salary,
                Employer = employer
            };
            Database.Vacancies.Add(vacancy);
            Database.Save();

        }

        public void Delete(int id)
        {
            Database.Vacancies.Delete(id);
            Database.Save();
        }

        public void Update(int id)
        {
            Database.Vacancies.Update(id);
            Database.Save();
        }
    }
}
