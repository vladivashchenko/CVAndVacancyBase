using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.BLL.Services;
using CVAndVacancyBase.BLL.Infrastructure;

namespace CVAndVacancyBase.Tests.BLL
{
    class CVServiceTest
    {
        private IService<CVDTO> cvService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<CV>> cvRepository;

        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            cvRepository = new Mock<IRepository<CV>>();
            uow.Setup(x => x.CVes.Get(It.IsAny<int>())).Returns(new CV { });
            uow.Setup(x => x.CVes).Returns(cvRepository.Object);

            cvService = new CVService(uow.Object);
        }
        [Test]
        public void Add_TryToCreateNullElement_ShouldThrowException()
        {
            //act & assert
            Assert.Throws<ValidationException>(() => cvService.Add(null));
        }
        [Test]
        public void Add_TryToCreate_RepositoryShouldCallOnce()
        {
            //act
            var cv = new CVDTO
            {
                Position = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Skills = It.IsAny<string>(),
                Education = It.IsAny<string>(),
                Language = It.IsAny<string>(),
                WorkingExperience = It.IsAny<string>(),
                Goal = It.IsAny<string>(),

            };
            cvService.Add(cv);

            //assert
            cvRepository.Verify(x => x.Add(It.IsAny<CV>()), Times.Once);
        }

        [Test]
        public void Update_TryToEdinNullValue_ShouldThrowException()
        {
            //act & assert
            Assert.Throws<ValidationException>(() => cvService.Update(null));
        }

        [Test]
        public void Update_TryToEdinNonExictingCV_ShouldThrowException()
        {
            //arrange
            cvRepository.Setup(x => x.Get(It.Is<int>(y => y > 0))).Returns<CV>(null);

            //act & assert
            Assert.Throws<ValidationException>(() => cvService.Update(It.IsAny<CVDTO>()));
        }

        [Test]
        public void Update_TryToEdit_RepositoryShouldCallOnce()
        {
            //arrange
            cvRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new CV()
            {
                Position = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Skills = It.IsAny<string>(),
                Education = It.IsAny<string>(),
                Language = It.IsAny<string>(),
                WorkingExperience = It.IsAny<string>(),
                Goal = It.IsAny<string>()
            });

            //act 
            cvService.Update(new CVDTO
            {
                Position = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Skills = It.IsAny<string>(),
                Education = It.IsAny<string>(),
                Language = It.IsAny<string>(),
                WorkingExperience = It.IsAny<string>(),
                Goal = It.IsAny<string>()
            });

            //assert
            cvRepository.Verify(x => x.Update(It.IsAny<CV>()), Times.Once);
        }

        [Test]
        public void RemoveCV_TryToRemoveUser_RepositoryShouldCallOnce()
        {
            //arrange
            cvRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new CV
            {
                Position = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Skills = It.IsAny<string>(),
                Education = It.IsAny<string>(),
                Language = It.IsAny<string>(),
                WorkingExperience = It.IsAny<string>(),
                Goal = It.IsAny<string>()
            });

            //act
            cvService.Delete(It.IsAny<int>());

            //assert
            cvRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
