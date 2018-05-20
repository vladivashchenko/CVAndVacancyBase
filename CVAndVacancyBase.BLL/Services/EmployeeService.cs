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
    public class EmployeeService : IService<EmployeeDTO>
    {
        IUnitOfWork Database { get; set; }
        MapperConfiguration config = new AutoMapperConfiguration().Configure();

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;

        }
        public EmployeeDTO Get(int id)
        {
            var employee = Database.Employees.Get(id);
            if (employee == null)
                throw new ValidationException("Not found", "");
            var iMapper = config.CreateMapper();
            return iMapper.Map<Employee, EmployeeDTO>(employee);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
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
