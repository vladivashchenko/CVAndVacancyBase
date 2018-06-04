using Moq;
using NUnit.Framework;
using System;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.BLL.Services;
using CVAndVacancyBase.BLL.Infrastructure;


namespace CVAndVacancyBase.Tests.BLL
{
    [TestFixture]
    public class VacancyServiseTest
    {
        private IService<VacancyDTO> vacancyService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<Vacancy>> vacancyRepository;

        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            vacancyRepository = new Mock<IRepository<Vacancy>>();
            uow.Setup(x => x.Vacancies).Returns(vacancyRepository.Object);
            uow.Setup(x => x.Users.Get(It.IsAny<int>())).Returns(new User { Name = It.IsAny<string>() });
            vacancyService = new VacancyService(uow.Object);
        }
        [Test]
        public void Add_TryToCreateNullElement_ShouldThrowException()
        {
            //act & assert
            Assert.Throws<ValidationException>(() => vacancyService.Add(null));
        }
        [Test]
        public void Add_TryToCreate_RepositoryShouldCallOnce()
        {
            //act
            var vacancy = new VacancyDTO { Name = It.IsAny<string>(), EmployerId = It.IsAny<int>() };
            vacancyService.Add(vacancy);

            //assert
            vacancyRepository.Verify(x => x.Add(It.IsAny<Vacancy>()), Times.Once);
        }

        [Test]
        public void Update_TryToEdinNullValue_ShouldThrowException()
        {
            //act & assert
            Assert.Throws<ValidationException>(() => vacancyService.Update(null));
        }

        [Test]
        public void Update_TryToEdinNonExictingVacancy_ShouldThrowException()
        {
            //arrange
            vacancyRepository.Setup(x => x.Get(It.Is<int>(y => y > 0))).Returns<Vacancy>(null);

            //act & assert
            Assert.Throws<ValidationException>(() => vacancyService.Update(It.IsAny<VacancyDTO>()));
        }

        [Test]
        public void Update_TryToEdit_RepositoryShouldCallOnce()
        {
            //arrange
            vacancyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Vacancy()
            {
                Name = It.IsAny<string>(),
                EmployerId = It.IsAny<int>()
            });

            //act 
            vacancyService.Update(new VacancyDTO { Name = It.IsAny<string>(), EmployerId = It.IsAny<int>() });

            //assert
            vacancyRepository.Verify(x => x.Update(It.IsAny<Vacancy>()), Times.Once);
        }

        [Test]
        public void RemoveVacancy_TryToRemoveVacancy_RepositoryShouldCallOnce()
        {
            //arrange
            vacancyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Vacancy
            {
                Id = It.IsAny<int>(),
                EmployerId = It.IsAny<int>(),
                Name = It.IsAny<string>()
            });

            //act
            vacancyService.Delete(It.IsAny<int>());

            //assert
            vacancyRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

    }
}