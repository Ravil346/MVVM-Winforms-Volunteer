using BuisnesLogic.Service.Clients;
using BuisnessLogic;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services.Repositories;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using BuisnesLogic.ServicesInterface;
using Data;
using Data.ConstStorages;
using Moq;
using BuisnessLogic.Models.Result;
namespace UnitTests.Repositories
{
    public class TestUserRepository
    {
        private IUserRepositry<UserInfoRequest> userRepositry;
        private UnitOfWork unitOfWork;
        private Mock<IYandexClient> MockYandexClient => new Mock<IYandexClient>();
        public TestUserRepository()
        {
            //Arrange

            MockYandexClient.Setup(x => x.AddModel(It.IsAny<Stream>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(new AwsActionResultModel() { resultUrlFromModel = "s", isCorrect = true}));
            
            var unitofwork = new UnitOfWork(new AppDbContext(AppConstStorage.ConnectionDb, "admin", "admin"),MockYandexClient.Object);

            unitOfWork = unitofwork;

            userRepositry = new UserRepository(unitofwork);
        }
        [Fact]
        public void GetUserUseEmail()
        {
            //Act
            string email = "Admin@gmail.com";

            userRepositry.Create(new UserInfoRequest
            {
                Email = email,
            });

            // unitOfWork.SaveAll();

            var user = userRepositry.Get(email);

            //Assert
            Assert.NotNull(user);
        }
        [Fact]
        public void GetUserUseId()
        {
            //Arrange
            int id = 1;
            //Act
            userRepositry.Create(new UserInfoRequest
            {
                Id = id,
            });
            //unitOfWork.SaveAll();

            var user = userRepositry.Get(id);

            //Assert
            Assert.NotNull(user);
        }
        [Fact]
        public void GetUserWhichNull()
        {
            //Act
            var user = userRepositry.Get("??");

            //Assert
            Assert.Throws<ArgumentNullException>(() => user);
        }
        [Fact]
        public void CreateUser()
        {
            //Act
            userRepositry.Create(new UserInfoRequest()
            {
                Email = "Admin@gmail.com",
                Surname = "Name",
                Name = "Name",
                ScoutGroup = "Test"
            });
        }
        [Fact]
        public void CreateUserWithNullParams()
        {
            //Act
            try
            {
                userRepositry.Create(new UserInfoRequest()
                {
                });
            }
            catch (Exception ex) when (ex.Message.Contains("This"))
            {
                //Assert
                Assert.True(true);
                return;
            }
        }
        [Fact]
        public void CreateUserSimilarEmail()
        {
            //Arrange
            string commonEmail = "Admin@gmail.com";
            //Act
            userRepositry.Create(new UserInfoRequest()
            {
                Email = commonEmail,
            });
            
            userRepositry.Create(new UserInfoRequest()
            {
                Email = commonEmail,
            });
        }
        [Fact]
        public void DeleteUser()
        {
            //Arrange
            string commonEmail = "Admin@gmail.com";

            //Act
            userRepositry.Create(new UserInfoRequest()
            {
                Email = commonEmail,
            });

            userRepositry.Delete(commonEmail);
        }
        [Fact]
        public void DeleteUserWhichIsNotExists()
        {
            //Arrange
            string commonEmail = "Admin@gmail.com";
            try
            {
                userRepositry.Delete(commonEmail);
            }
            catch (NullReferenceException ex)
            {
                //Assert
                Assert.True(true);
            }
        }
        [Fact]
        public void UpdateUser()
        {
            //Arrange
            string commonEmail = "Admin@gmail.com";

            //Act
            userRepositry.Create(new UserInfoRequest()
            {
                Email = commonEmail,
            });

            userRepositry.Update(commonEmail, new UserInfoRequest()
            {
                Surname = "Test",
                Name = "Test",
                IsAdmin = true,
            });

        }
    }
}
