using AutoMapper;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.BLL.Infrastructure;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CVAndVacancyBase.Controllers
{
    [Authorize]
    public class AccountsController : ApiController
    {
        IUserService service;
        MapperConfiguration config;
        IMapper mapper;

        public AccountsController() { }

        public AccountsController(IUserService service)
        {
            this.service = service;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }

        // GET work-app/accounts
        public IEnumerable<UserModelView> Get()
        {
            return mapper.Map<IEnumerable<UserDTO>, List<UserModelView>>(service.GetAll());
        }

        // GET work-app/accounts/5
        public UserModelView Get(int id)
        {
            UserModelView user = mapper.Map<UserDTO, UserModelView>(service.Get(id));
            return user;
        }


        [AllowAnonymous]
        [Route("work-app/accounts/RegisterEmployer")]
        public void PostEmployer([FromBody]UserModelView value)
        {
            var user = mapper.Map<UserModelView, UserDTO>(value);
            user.Role = UserDTO.Roles.Employer;
            service.Add(user);
        }
        [AllowAnonymous]
        [Route("work-app/accounts/RegisterEmployee")]

        public void PostEmployee([FromBody]UserModelView value)
        {
            var user = mapper.Map<UserModelView, UserDTO>(value);
            user.Role = UserDTO.Roles.Employee;
            service.Add(user);
        }

        // PUT work-app/accounts/5
        public void Put(int id, [FromBody]UserModelView value)
        {
            var user = mapper.Map<UserModelView, UserDTO>(value);
            service.Update(user);
        }
        // DELETE work-app/accounts/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
