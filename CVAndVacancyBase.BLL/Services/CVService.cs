﻿using AutoMapper;
using System.Collections.Generic;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.BLL.Infrastructure;
using CVAndVacancyBase.DAL.Entities;

namespace CVAndVacancyBase.BLL.Services
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
                throw new ValidationException("CV not found", "");
            
            return mapper.Map<CV, CVDTO>(cv);
        }

        public IEnumerable<CVDTO> GetAll()
        {
            return mapper.Map<IEnumerable<CV>, List<CVDTO>>(Database.CVes.GetAll());
        }

        public void Add(CVDTO entity)
        {
            if (entity == null)
                throw new ValidationException("CV can't be null", "");
            User employee = Database.Users.Get(entity.EmployeeId.Value);
            if (employee == null)
                throw new ValidationException("Employee not found", "");
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

        public void Update(CVDTO entity)
        {
            if (entity == null)
                throw new ValidationException("CV can't be null", "");
            CV cv = Database.CVes.Get(entity.Id);
            if (cv == null)
                throw new ValidationException("CV not found", "");
            User employee = Database.Users.Get(entity.EmployeeId.Value);
            if (employee == null)
                throw new ValidationException("Employee not found", "");

            cv.Goal = entity.Goal;
            cv.Language = entity.Language;
            cv.Position = entity.Position;
            cv.Skills = entity.Skills;
            cv.WorkingExperience = entity.WorkingExperience;
            cv.Education = entity.Education;
            cv.EmployeeId = entity.EmployeeId;
            cv.Employee = employee;

            Database.CVes.Update(cv);
            Database.Save();
        }
    }
}
