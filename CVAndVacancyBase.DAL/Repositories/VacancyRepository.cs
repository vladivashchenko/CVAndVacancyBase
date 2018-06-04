using CVAndVacancyBase.DAL.EF;
using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.DAL.Repositories
{
    public class VacancyRepository : GenericRepository<Vacancy>
    {
        public VacancyRepository(ModelContext context) : base(context)
        {
        }
    }
}
