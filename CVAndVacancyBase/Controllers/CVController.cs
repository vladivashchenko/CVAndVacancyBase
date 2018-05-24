using AutoMapper;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.Models;
using CVAndVacancyBase.Util;
using System.Collections.Generic;
using System.Web.Http;

namespace CVAndVacancyBase.Controllers
{
    public class CVController : ApiController
    {
        IService<CVDTO> service;
        MapperConfiguration config;
        IMapper mapper;

        public CVController(IService<CVDTO> service)
        {
            this.service = service;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }

        // GET api/values
        public IEnumerable<CVModelView> Get()
        {
            return mapper.Map<IEnumerable<CVDTO>, List<CVModelView>>(service.GetAll());
        }

        // GET api/values/5
        public CVModelView Get(int id)
        {
            return mapper.Map<CVDTO, CVModelView>(service.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]CVModelView value)
        {
            var cv = mapper.Map<CVModelView, CVDTO>(value);
            service.Add(cv);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]CVModelView value)
        {
            var cv = mapper.Map<CVModelView, CVDTO>(value);
            service.Update(cv);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
