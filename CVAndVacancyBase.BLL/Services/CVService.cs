using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ninject;
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
        MapperConfiguration config = new AutoMapperConfiguration().Configure();

        public CVService(IUnitOfWork uow)
        {
            Database = uow;

        }
        public CVDTO Get(int id)
        {
            var cv = Database.CVes.Get(id);
            if (cv == null)
                throw new ValidationException("Not found", "");
            var iMapper = config.CreateMapper();
            return iMapper.Map<CV, CVDTO>(cv);
        }

        public IEnumerable<CVDTO> GetAll()
        {
            var iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<CV>, List<CVDTO>>(Database.CVes.GetAll());
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
