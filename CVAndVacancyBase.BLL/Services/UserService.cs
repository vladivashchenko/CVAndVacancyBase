using AutoMapper;
using System.Collections.Generic;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.BLL.Infrastructure;
using CVAndVacancyBase.DAL.Entities;
using System.Linq;

namespace CVAndVacancyBase.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        MapperConfiguration config;
        IMapper mapper;

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }
        public UserDTO Get(int id)
        {
            var user = Database.Users.Get(id);
            if (user == null)
                throw new ValidationException("User Not found", "");

            return mapper.Map<User, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public void Add(UserDTO entity)
        {
            if (entity == null)
                throw new ValidationException("Add entity can't be null!", "");
            User user = new User
            {
                Id = entity.Id,
                Address = entity.Address,
                Email = entity.Email,
                Name = entity.Name,
                Password = entity.Password,
                Role = (User.Roles)entity.Role,
                Telephone = entity.Telephone
            };
            Database.Users.Add(user);
            Database.Save();

        }

        public void Delete(int id)
        {
            Database.Users.Delete(id);
            Database.Save();
        }

        public void Update(UserDTO entity)
        {
            if (entity == null)
                throw new ValidationException("Update entity can't be null", "");
            User user = Database.Users.Get(entity.Id);
            if(user==null)
                throw new ValidationException("User not found", "");

            user.Address = entity.Address;
            user.Email = entity.Email;
            user.Role = (User.Roles)entity.Role;
            user.Name = entity.Name;
            user.Password = entity.Password;
            user.Telephone = entity.Telephone;
            
            Database.Users.Update(user);
            Database.Save();
        }

        public UserDTO ValidateUser(string email, string password)
        {
            List<UserDTO> users= mapper.Map<IEnumerable<User>,List<UserDTO>>(Database.Users.GetBy(us => us.Email == email && us.Password == password));
            var user = users.First();

            return user;
        }
    }
}
