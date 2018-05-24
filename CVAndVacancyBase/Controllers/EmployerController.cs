using AutoMapper;
using CVAndVacancyBase.BLL.DTO;
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
    public class EmployerController : ApiController
    {
        IService<EmployerDTO> service;
        MapperConfiguration config;
        IMapper mapper;

        public EmployerController(IService<EmployerDTO> service, MapperConfiguration config, IMapper mapper)
        {
            this.service = service;
            this.config = config;
            this.mapper = mapper;
        }

        // GET api/values
        public IEnumerable<EmployerModelView> Get()
        {
            return mapper.Map<IEnumerable<EmployerDTO>, List<EmployerModelView>>(service.GetAll());
        }

        // GET api/values/5
        public EmployerModelView Get(int id)
        {
            return mapper.Map<EmployerDTO, EmployerModelView>(service.Get(id));
        }

        // POST api/values
        public void Post([FromBody]EmployerModelView value)
        {
            var cv = mapper.Map<EmployerModelView, EmployerDTO>(value);
            service.Add(cv);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]EmployerModelView value)
        {
            var employer = mapper.Map<EmployerModelView, EmployerDTO>(value);
            service.Update(employer);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
