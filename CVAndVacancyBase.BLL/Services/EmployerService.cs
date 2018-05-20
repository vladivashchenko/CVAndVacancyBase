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
    public class EmployerService : IService<EmployerDTO>
    {
        IUnitOfWork Database { get; set; }
        MapperConfiguration config = new AutoMapperConfiguration().Configure();

        public EmployerService(IUnitOfWork uow)
        {
            Database = uow;

        }
        public EmployerDTO Get(int id)
        {
            var employer = Database.Employers.Get(id);
            if (employer == null)
                throw new ValidationException("Not found", "");
            var iMapper = config.CreateMapper();
            return iMapper.Map<Employer, EmployerDTO>(employer);
        }

        public IEnumerable<EmployerDTO> GetAll()
        {
            var iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<Employer>, List<EmployerDTO>>(Database.Employers.GetAll());
        }

        
        public void Add(EmployerDTO entity)
        {
            Employer employer = new Employer
            {
                Id = entity.Id,
                Admin = false,
                Email = entity.Email,
                Location = entity.Location,
                Name = entity.Name,
                Password = entity.Password, 
            };
            Database.Employers.Add(employer);
            Database.Save();

        }

        public void Delete(int id)
        {
            Database.Employers.Delete(id);
            Database.Save();
        }

        public void Update(int id)
        {
            Database.Employers.Update(id);
            Database.Save();
        }
    }
}
