using CVAndVacancyBase.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAndVacancyBase.BLL.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        UserDTO ValidateUser(string email, string password);
    }
}
