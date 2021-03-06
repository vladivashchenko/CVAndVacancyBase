﻿using AutoMapper;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.Infrastructure;
using CVAndVacancyBase.DAL.Interfaces;
using System.Collections.Generic;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Entities;

namespace CVAndVacancyBase.BLL.Services
{
    public class VacancyService:IService<VacancyDTO>
    {
        IUnitOfWork Database { get; set; }
        MapperConfiguration config;
        IMapper mapper;

        public VacancyService(IUnitOfWork uow)
        {
            Database = uow;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }
        public VacancyDTO Get(int id)
        {
            var vacancy = Database.Vacancies.Get(id);
            if (vacancy == null)
                throw new ValidationException("Vacancy not found","");

            return mapper.Map<Vacancy,VacancyDTO>(vacancy);
        }

        public IEnumerable<VacancyDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Vacancy>, List<VacancyDTO>>(Database.Vacancies.GetAll());
        }

        public void Add(VacancyDTO entity)
        {
            if (entity == null)
                throw new ValidationException("Vacancy can't be null", "");
            User employer = Database.Users.Get(entity.EmployerId.Value);
            if (employer == null)
                throw new ValidationException("Employer not found", "");
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

        public void Update(VacancyDTO entity)
        {
            if (entity == null)
                throw new ValidationException("Vacancy can't be null", "");
            Vacancy vacancy = Database.Vacancies.Get(entity.Id);
            if (vacancy == null)
                throw new ValidationException("Vacancy not found", "");
            User employer = Database.Users.Get(entity.EmployerId.Value);
            if (employer == null)
                throw new ValidationException("Employer not found", "");

            vacancy.Name = entity.Name;
            vacancy.EmployerId = entity.EmployerId;
            vacancy.Employer = employer;
            vacancy.Salary = entity.Salary;

            Database.Vacancies.Update(vacancy);
            Database.Save();
        }
    }
}
