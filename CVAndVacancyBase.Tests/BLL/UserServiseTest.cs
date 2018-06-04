using Moq;
using NUnit.Framework;
using System;
using CVAndVacancyBase.BLL.Interfaces;
using CVAndVacancyBase.BLL.DTO;
using CVAndVacancyBase.DAL.Interfaces;
using CVAndVacancyBase.DAL.Entities;
using CVAndVacancyBase.BLL.Services;
using CVAndVacancyBase.BLL.Infrastructure;
using System.Collections.Generic;


namespace CVAndVacancyBase.Tests.BLL
{
    [TestFixture]
    public class UserServiseTest
    {
        private IService<UserDTO> userService;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<User>> userRepository;

        [SetUp]
        public void Load()
        {
            uow = new Mock<IUnitOfWork>();
            userRepository = new Mock<IRepository<User>>();
            uow.Setup(x => x.Users.Get(It.IsAny<int>())).Returns(new User {});
            uow.Setup(x => x.Users).Returns(userRepository.Object);
       
            userService = new UserService(uow.Object);
        }
        [Test]
        public void Add_TryToCreateNullElement_ShouldThrowException()
        {
            //act & assert
            Assert.Throws<ValidationException>(() => userService.Add(null));
        }
        [Test]
            public void Add_TryToCreate_RepositoryShouldCallOnce()
        {
            //act
            var user = new UserDTO
            {
                Name = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>(),
                Address = It.IsAny<string>(),
                Telephone = It.IsAny<string>(),
                Role = It.IsAny<UserDTO.Roles>()
            };
            userService.Add(user);

            //assert
            userRepository.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void Update_TryToEdinNullValue_ShouldThrowException()
        {
            //act & assert
            Assert.Throws<ValidationException>(() => userService.Update(null));
        }

        [Test]
        public void Update_TryToEdinNonExictingCV_ShouldThrowException()
        {
            //arrange
            userRepository.Setup(x => x.Get(It.Is<int>(y => y > 0))).Returns<User>(null);

            //act & assert
            Assert.Throws<ValidationException>(() => userService.Update(It.IsAny<UserDTO>()));
        }

        [Test]
        public void Update_TryToEdit_RepositoryShouldCallOnce()
        {
            //arrange
            userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new User()
            {
                Name = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>(),
                Address = It.IsAny<string>(),
                Telephone = It.IsAny<string>(),
                Role = It.IsAny<User.Roles>()
            });

            //act 
            userService.Update(new UserDTO {
                Name = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>(),
                Address = It.IsAny<string>(),
                Telephone = It.IsAny<string>(),
                Role = It.IsAny<UserDTO.Roles>()
            });

            //assert
            userRepository.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void RemoveUser_TryToRemoveUser_RepositoryShouldCallOnce()
        {
            //arrange
            userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new User
            {
                Name = It.IsAny<string>(),
                Id = It.IsAny<int>(),
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>(),
                Address = It.IsAny<string>(),
                Telephone = It.IsAny<string>(),
                Role = It.IsAny<User.Roles>()
            });

            //act
            userService.Delete(It.IsAny<int>());

            //assert
            userRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

    }
}
