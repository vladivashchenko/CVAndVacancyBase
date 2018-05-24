using AutoMapper;
using System.Collections.Generic;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.BLL.Infrastructure;
using CVAndVacancyBase.DAL.Entities;

namespace CVAndCVBase.BLL.Services
{
    public class EmployeeService : IService<EmployeeDTO>
    {
        IUnitOfWork Database { get; set; }
        MapperConfiguration config;
        IMapper mapper;

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }
        public EmployeeDTO Get(int id)
        {
            var employee = Database.Employees.Get(id);
            if (employee == null)
                throw new ValidationException("Not found", "");

            return mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }

        public void Add(EmployeeDTO entity)
        {
            Employee employee = new Employee
            {
                Id = entity.Id,
                Admin = false,
                Email = entity.Email,
                Name = entity.Name,
                Password = entity.Password,
                Age = entity.Age,
                Telephone = entity.Telephone
            };
            Database.Employees.Add(employee);
            Database.Save();

        }

        public void Delete(int id)
        {
            Database.Employees.Delete(id);
            Database.Save();
        }

        public void Update(int id)
        {
            Database.Employees.Update(id);
            Database.Save();
        }
    }
}
