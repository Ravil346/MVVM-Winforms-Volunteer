using BuisnesLogic.Service.Clients;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services.Repositories;
using Data;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class UnitOfWork 
    {
        public AppDbContext DataBase { get; set; }
        public IYandexClient YandexClient { get; set; }
       
        private IUserRepositry<UserInfoRequest>? _userRepository;

        private IEventsRepository<IncidentInfoRequest>? _incidentRepository;

        private IModuleRepository<ModuleInfoRequest>? _modulesRepository;
        public UnitOfWork(AppDbContext dbContext, IYandexClient yandexClient)
        {
            DataBase = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            YandexClient = yandexClient ?? throw new ArgumentNullException(nameof(yandexClient));
        }
      

        public IUserRepositry<UserInfoRequest> Users
        {
            get
            {
                if (_userRepository is null)
                    _userRepository = new UserRepository(this);
                return _userRepository;
            }
        }
        public IEventsRepository<IncidentInfoRequest> Incidents
        {
            get
            {
                if (_incidentRepository is null)
                    _incidentRepository = new IncidentRepository(this);
                return _incidentRepository;
            }
        }
        public IModuleRepository<ModuleInfoRequest> Modules
        {
            get
            {
                if (_modulesRepository is null)
                    _modulesRepository = new ModulesRepository(this);
                return _modulesRepository;
            }
        }
    }
}
