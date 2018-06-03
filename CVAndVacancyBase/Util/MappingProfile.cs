using AutoMapper;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.Util
{
    public class MappingProfile: Profile
    {
        public MappingProfile(){
            CreateMap<CVDTO, CVModelView>().ReverseMap();
            CreateMap<VacancyDTO, VacancyModelView>().ReverseMap();
            CreateMap<UserDTO, UserModelView>().ReverseMap();
        }
    }
}

