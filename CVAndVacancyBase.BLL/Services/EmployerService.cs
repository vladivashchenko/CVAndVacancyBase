using AutoMapper;
using System.Collections.Generic;
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
        MapperConfiguration config;
        IMapper mapper;

        public EmployerService(IUnitOfWork uow)
        {
            Database = uow;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }
        public EmployerDTO Get(int id)
        {
            var employer = Database.Employers.Get(id);
            if (employer == null)
                throw new ValidationException("Not found", "");
           return mapper.Map<Employer, EmployerDTO>(employer);
        }

        public IEnumerable<EmployerDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Employer>, List<EmployerDTO>>(Database.Employers.GetAll());
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
