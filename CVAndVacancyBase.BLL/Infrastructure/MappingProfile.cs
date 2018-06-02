using AutoMapper;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile(){
            CreateMap<CV, CVDTO>().ReverseMap();
            CreateMap<Vacancy, VacancyDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

