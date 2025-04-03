using BuisnessLogic.Models.Result;
using BuisnessLogic.Services.Repositories;
using BuisnessLogic;
using Data.ConstStorages;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogic.ServicesInterface;
using Moq;
using Data.Interfaces;
using BuisnessLogic.Models.Request;
using Data.Entities;
using System.Xml.Linq;

namespace UnitTests.Repositories
{
    public class TestModulesRepository
    {
        private Mock<IYandexClient> MockYandexClient => new Mock<IYandexClient>();
        private UnitOfWork unitOfWork;
        private IModuleRepository<ModuleInfoRequest> moduleRepository;
        private IUserRepositry<UserInfoRequest> userRepository;
        public TestModulesRepository()
        {
            //Arrange

            MockYandexClient.Setup(x => x.AddModel(It.IsAny<Stream>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(new AwsActionResultModel() { resultUrlFromModel = "s", isCorrect = true }));

            var unitofwork = new UnitOfWork(new AppDbContext(AppConstStorage.ConnectionDb, "admin", "admin"), MockYandexClient.Object);

            unitOfWork = unitofwork;

            moduleRepository = new ModulesRepository(unitOfWork);

            userRepository = new UserRepository(unitOfWork);
        }
        [Fact]
        public void AddModule()
        {
            //Arrange
            var name = "Test";
            //Act
            moduleRepository.AddModule(new ModuleInfoRequest()
            {
                Name = name,
                TestTasks = new List<Aim>()
                {
                    new Aim { Content = new Content() { Text = name } }
                }
            });
        }
        [Fact]
        public void AddLinkOnUser()
        {
            //Arrange
            userRepository.Create(new UserInfoRequest()
            {
                Name = "Test",
                Email = "Test@gmail.com"
            });

            var user = userRepository.Get("Test@gmail.com");
            //Act
            moduleRepository.AddLinkOnUser(new ModuleInfoRequest()
            {
                Name = "Test",
            }, user!.Id);
        }
        [Fact]
        public void DeleteModule()
        {
            //Arrange
            var name = "Test";
            //Act
            moduleRepository.AddModule(new ModuleInfoRequest()
            {
                Name = name,
                TestTasks = new List<Aim>()
                {
                    new Aim { Content = new Content() { Text = name } }
                }
            });
            moduleRepository.DeleteModule(name);
        }
        [Fact]
        public void DeleteLinkOnUser()
        {
            //Arrange
            userRepository.Create(new UserInfoRequest()
            {
                Name = "Test",
                Email = "Test@gmail.com"
            });

            var user = userRepository.Get("Test@gmail.com");
            moduleRepository.AddLinkOnUser(new ModuleInfoRequest()
            {
                Name = "Test",
            }, user!.Id);
            //Act
            moduleRepository.DeleteOnUser(new ModuleInfoRequest()
            {
                Name = "Test",
            }, user.Id);
        }
        [Fact]
        public void GetModule()
        {
            string name = "Test";
            //Arrange
            moduleRepository.AddModule(new ModuleInfoRequest()
            {
                Name = name,
                TestTasks = new List<Aim>()
                {
                    new Aim { Content = new Content() { Text = name } }
                }
            });
            //Act
            var module = moduleRepository.GetModules(x => x.Name == name);
            //Asserts
            Assert.NotNull(module);
        }
    }
}
