using Ninject;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CVAndVacancyBase.BLL.DTO;

namespace CVAndVacancyBase.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IService<VacancyDTO>>().To<VacancyService>();
            kernel.Bind<IService<CVDTO>>().To<CVService>();
            kernel.Bind<IService<EmployeeDTO>>().To<EmployeeService>();
            kernel.Bind<IService<EmployerDTO>>().To<EmployerService>();
        }
    }
}