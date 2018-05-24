﻿using AutoMapper;
using System.Collections.Generic;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.BLL.Infrastructure;
using CVAndVacancyBase.DAL.Entities;

namespace CVAndCVBase.BLL.Services
{
    public class CVService : IService<CVDTO>
    {
        IUnitOfWork Database { get; set; }
        MapperConfiguration config;
        IMapper mapper;

        public CVService(IUnitOfWork uow)
        {
            Database = uow;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }
        public CVDTO Get(int id)
        {
            var cv = Database.CVes.Get(id);
            if (cv == null)
                throw new ValidationException("Not found", "");
            
            return mapper.Map<CV, CVDTO>(cv);
        }

        public IEnumerable<CVDTO> GetAll()
        {
            return mapper.Map<IEnumerable<CV>, List<CVDTO>>(Database.CVes.GetAll());
        }

        public void Add(CVDTO entity)
        {
            Employee employee = Database.Employees.Get(entity.EmployeeId.Value);
            CV cv = new CV
            {
                Id = entity.Id,
                EmployeeId = employee.Id,
                Education = entity.Education,
                Goal = entity.Goal,
                Language = entity.Language,
                Position = entity.Position,
                Skills = entity.Skills,
                WorkingExperience = entity.WorkingExperience,
                Employee = employee
            };
            Database.CVes.Add(cv);
            Database.Save();

        }

        public void Delete(int id)
        {
            Database.CVes.Delete(id);
            Database.Save();
        }

        public void Update(int id)
        {
            Database.CVes.Update(id);
            Database.Save();
        }
    }
}
