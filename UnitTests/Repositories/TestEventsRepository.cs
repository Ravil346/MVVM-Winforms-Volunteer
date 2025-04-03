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
using BuisnessLogic.Models.Request;
using Data.Interfaces;
using Moq;
using BuisnessLogic.Extensions;

namespace UnitTests.Repositories
{
    public class TestEventsRepository
    {
        private Mock<IYandexClient> MockYandexClient => new Mock<IYandexClient>();
        private UnitOfWork unitOfWork;
        private IEventsRepository<IncidentInfoRequest> eventsRepository;
        private IUserRepositry<UserInfoRequest> userRepository;
        public TestEventsRepository()
        {
            //Arrange
            MockYandexClient.Setup(x => x.AddModel(It.IsAny<Stream>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(new AwsActionResultModel() { resultUrlFromModel = "s", isCorrect = true }));

            var unitofwork = new UnitOfWork(new AppDbContext(AppConstStorage.ConnectionDb, "admin", "admin"), MockYandexClient.Object);
            unitOfWork = unitofwork;

            eventsRepository = new IncidentRepository(unitOfWork);

            userRepository = new UserRepository(unitOfWork);
        }
        [Fact]
        public void Create()
        {
            //Act
            eventsRepository.AddIncident(new IncidentInfoRequest()
            {
                FileInfo = new FileInfoRequest(),
                Name = "Test",
            });
        }
        [Fact]
        public void Delete()
        {
            //Arrrange
            var name = "Test";
            //Act
            eventsRepository.AddIncident(new IncidentInfoRequest()
            {
                FileInfo = new FileInfoRequest(),
                Name = name,
            });
            eventsRepository.DeleteIncident(name);

        }
    }
}
