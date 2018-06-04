using AutoMapper;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.Models;
using CVAndVacancyBase.Util;
using System.Collections.Generic;
using System.Web.Http;


namespace CVAndVacancyBase.Controllers
{
    public class VacanciesController : ApiController
    {
        IService<VacancyDTO> service;
        MapperConfiguration config;
        IMapper mapper;

        public VacanciesController() { }

        public VacanciesController(IService<VacancyDTO> service)
        {
            this.service = service;
            config = new AutoMapperConfiguration().Configure();
            mapper = config.CreateMapper();
        }

        // GET work-app/vacancies
        public IEnumerable<VacancyModelView> Get()
        {
            return mapper.Map<IEnumerable<VacancyDTO>, List<VacancyModelView>>(service.GetAll());
        }

        // GET work-app/vacancies/5
        public VacancyModelView Get(int id)
        {
            return mapper.Map<VacancyDTO, VacancyModelView>(service.Get(id));
        }

        // POST work-app/vacancies
        public void Post([FromBody]VacancyModelView value)
        {
            var vacancy = mapper.Map<VacancyModelView, VacancyDTO>(value);
            service.Add(vacancy);
        }

        // PUT work-app/vacancies/5
        public void Put(int id, [FromBody]VacancyModelView value)
        {
            var vacancy = mapper.Map<VacancyModelView, VacancyDTO>(value);
            service.Update(vacancy);
        }

        // DELETE work-app/vacancies/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
