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
    public class AccountController : ApiController
    {
        IUserService service;
        MapperConfiguration config;
        IMapper mapper;

        public AccountController() { }
        public AccountController(IUserService service)
        {
            this.service = service;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }

        // GET api/values
        public IEnumerable<UserModelView> Get()
        {
            return mapper.Map<IEnumerable<UserDTO>, List<UserModelView>>(service.GetAll());
        }

        // GET api/values/5
        public UserModelView Get(int id)
        {
            var user = mapper.Map<UserDTO, UserModelView>(service.Get(id));
            return user;
        }

        // POST api/values
        public void Post([FromBody]UserModelView value)
        {
            var user = mapper.Map<UserModelView, UserDTO>(value);
            service.Add(user);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]UserModelView value)
        {
            var user = mapper.Map<UserModelView, UserDTO>(value);
            service.Update(user);
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
