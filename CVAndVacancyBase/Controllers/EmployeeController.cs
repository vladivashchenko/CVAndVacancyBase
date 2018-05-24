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
    public class EmployeeController : ApiController
    {
        IService<EmployeeDTO> service;
        MapperConfiguration config;
        IMapper mapper;

        public EmployeeController(IService<EmployeeDTO> service, MapperConfiguration config, IMapper mapper)
        {
            this.service = service;
            this.config = config;
            this.mapper = mapper;
        }

        // GET api/values
        public IEnumerable<EmployeeModelView> Get()
        {
            return mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeModelView>>(service.GetAll());
        }

        // GET api/values/5
        public EmployeeModelView Get(int id)
        {
            return mapper.Map<EmployeeDTO, EmployeeModelView>(service.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]EmployeeModelView value)
        {
            var cv = mapper.Map<EmployeeModelView, EmployeeDTO>(value);
            service.Add(cv);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]EmployeeModelView value)
        {
            var employee = mapper.Map<EmployeeModelView, EmployeeDTO>(value);
            service.Update(employee);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
