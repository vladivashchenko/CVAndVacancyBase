using AutoMapper;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.Models;
using CVAndVacancyBase.Util;
using System.Collections.Generic;
using System.Web.Http;

namespace CVAndVacancyBase.Controllers
{
    public class CVsController : ApiController
    {
        IService<CVDTO> service;
        MapperConfiguration config;
        IMapper mapper;

        public CVsController() { }

        public CVsController(IService<CVDTO> service)
        {
            this.service = service;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }

        // GET work-app/cvs
        public IEnumerable<CVModelView> Get()
        {
            return mapper.Map<IEnumerable<CVDTO>, List<CVModelView>>(service.GetAll());
        }

        // GET work-app/cvs/5
        public CVModelView Get(int id)
        {
            return mapper.Map<CVDTO, CVModelView>(service.Get(id));
        }

        // POST work-app/cvs
        [HttpPost]
        public void Post([FromBody]CVModelView value)
        {
            var cv = mapper.Map<CVModelView, CVDTO>(value);
            service.Add(cv);
        }

        // PUT work-app/cvs/5
        [HttpPut]
        public void Put(int id, [FromBody]CVModelView value)
        {
            var cv = mapper.Map<CVModelView, CVDTO>(value);
            service.Update(cv);
        }

        // DELETE work-app/cvs/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
