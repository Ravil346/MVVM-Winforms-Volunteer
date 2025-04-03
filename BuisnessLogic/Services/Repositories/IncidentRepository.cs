using Amazon.S3.Model;
using AutoMapper;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Validators;
using Data;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using Data.Interfaces.UserInterfaces;
using BuisnessLogic.Extensions;

namespace BuisnessLogic.Services.Repositories
{
    public class IncidentRepository : IEventsRepository<IncidentInfoRequest>
    {
        private IGetUser _GeterUser;
        private IYandexClient _YandexClient;
        private IUpdateUser<UserInfoRequest> _UpdaterUser;
        private IncidentValidator? _Validator;
        private AppDbContext _DataBase;
        public IncidentRepository(UnitOfWork unitOfWork)
        {
            _DataBase = unitOfWork.DataBase ?? throw new ArgumentNullException(nameof(unitOfWork.DataBase));
            _UpdaterUser = unitOfWork.Users ?? throw new ArgumentNullException(nameof(unitOfWork.Users));
            _GeterUser = unitOfWork.Users ?? throw new ArgumentNullException(nameof(unitOfWork.Users));
            _YandexClient = unitOfWork.YandexClient ?? throw new ArgumentNullException(nameof(unitOfWork.YandexClient));
        }
        #region Get
        public IQueryable<Incident> GetIncidents()
        {
            var list = new List<Incident>();
            var allBinaryData = _DataBase.BinaryDatas;
            foreach(var data in allBinaryData)
            {
                if(data.Incident is not null & data.IncidentId is not null)
                {
                   var events = _DataBase.Incidents.Where(x => x.Id == data.IncidentId).SingleOrDefault();
                   if (events is null) continue;
                   events.BinaryData = data;
                   list.Add(events);
                }
            }
            if(list.Count is 0) return _DataBase.Incidents;
            return list.AsQueryable();
            
        }
        public IEnumerable<Incident> GetIncidents(Func<Incident, bool> expr) => GetIncidents().Where(expr);
       
        public IEnumerable<Incident>? GetUserIncidents(int id)
        {
            var user = _GeterUser.Get(id);

            if(user is null) throw new NullReferenceException(nameof(user));

            return user.Incidents;
        }
        public IEnumerable<Incident>? GetUserIncidents(string email)
        {
            var user = _GeterUser.Get(email);

            if (user is null) throw new NullReferenceException(nameof(user));

            return user.Incidents;
        }
        #endregion
        #region Add
        public async Task AddIncident(IncidentInfoRequest request)
        {
            _Validator = new IncidentValidator(_DataBase,false, true);

            var validRes = _Validator.Validate(request);

            if(!validRes.IsValid) throw new Exception(string.Join(Environment.NewLine, validRes.Errors.Select(x => x.ErrorMessage)));

            var model = await MapIntoRequest(request);


            _DataBase.Incidents.Add(model);

            _DataBase.SaveChanges();

        }
        public void AddLinkOnUser(IncidentInfoRequest request)
        {
            _Validator = new IncidentValidator(_DataBase, false, false);

            var validRes = _Validator.Validate(request);

            if (!validRes.IsValid) throw new Exception(string.Join(Environment.NewLine, validRes.Errors.Select(x => x.ErrorMessage)));

            var incident = GetIncidents(x => x.Name == request.Name).SingleOrDefault();

            if (incident is null) throw new NullReferenceException(nameof(incident));

            var user = _GeterUser.Get(request.User!.Email!);

            if (user is null) throw new NullReferenceException(nameof(user));

            incident.SetLinksTypeOnModel();

            incident.Users!.Add(user);

            user.Incidents!.Add(incident);

            _UpdaterUser.Update(user.Email!, user);

            UpdateIncident(incident.Id, incident);

            _DataBase.SaveChanges();
        }
        #endregion
        #region Delete
        public void DeleteIncident(int id)
        {
            var incident = GetIncidents(x => x.Id == id).SingleOrDefault();

            if(incident is null) throw new NullReferenceException(nameof(incident));

            _DataBase.Incidents.Remove(incident);

            _DataBase.SaveChanges();

        }
        public void DeleteLinkOnUser(int id, int userid)
        {
            var incident = GetIncidents(x => x.Id == id).SingleOrDefault();

            if (incident is null) throw new NullReferenceException(nameof(incident));

            var user = _GeterUser.Get(userid);

            if(user is null) throw new NullReferenceException(nameof(user));

            if(user.Incidents is not null & incident.Users is not null)
            {
                user.Incidents!.RemoveAll(x => x.Id == id);

                incident.Users!.RemoveAll(x => x.Id == userid);

                UpdateIncident(id,incident);

                _UpdaterUser.Update(userid, user);
            }

            _DataBase.SaveChanges();

        }
        #endregion
        #region Update
        public void UpdateIncident(int id, Incident newModel)
        {
            var oldmodel = GetIncidents(x => x.Id == id).SingleOrDefault();

            if(oldmodel is null) throw new NullReferenceException($"{nameof(oldmodel)} is null");

            _DataBase.Incidents.Entry(oldmodel).CurrentValues.SetValues(newModel);

            _DataBase.Incidents.Update(newModel);

            _DataBase.SaveChanges();
        }
        #endregion
        #region Map
        private async Task<Incident> MapIntoRequest(IncidentInfoRequest request)
        {
            Incident? model = null; 
            var map = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<IncidentInfoRequest, Incident>()
              .ForMember(nameof(model.Name), opt => opt.MapFrom(x => x.Name))
            ));
            model = map.Map<Incident>(request);
            
            var res = await _YandexClient.AddModel(request.FileInfo.File!, request.FileInfo.Path!, request.FileInfo.Name!);
            
            if(!res.isCorrect) throw new Exception($"{nameof(res)} isn`t correct.");

            model.SetLinksTypeOnModel();

            ExtensionsManagers.SetLinkOnBinaryData(ref model,res.resultUrlFromModel);

            return model;
        }
        private async Task<Incident> MapIntoRequest(IncidentInfoRequest request, User user)
        {
            var model = await MapIntoRequest(request);
            model.Users!.Add(user);
            return model;
        }
        #endregion
    }
}
