using AutoMapper;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services;
using Data;
using Data.Entities;
using Data.Interfaces;
using Data.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BuisnessLogic.Extensions
{
    public static class ExtensionsManagers
    {

        public static User ExcludeEmptyModel(User oldUser, User newUser)
        {
            foreach(var prop in newUser.GetType().GetProperties())
            {
                if(prop.GetValue(newUser) is null)
                {
                    var oldprop = oldUser.GetType().GetProperty(prop.Name);
                    prop.SetValue(newUser,oldprop!.GetValue(oldUser));
                }
            }
            newUser.Email = string.IsNullOrWhiteSpace(newUser.Email) ? oldUser.Email : newUser.Email;
            newUser.Id = oldUser.Id;

            return newUser;
        }
        public static void DeleteIncident(this IEventsRepository<IncidentInfoRequest> eventsRepository, string name)
        {
            var events = eventsRepository.GetIncidents(x => x.Name == name).FirstOrDefault();

            if (events is null) throw new NullReferenceException(nameof(events));

            eventsRepository.DeleteIncident(events.Id);
        }
        public static IncidentInfoRequest CreateIncident(FileInfoRequest fileInfoRequest, string name) => new IncidentInfoRequest()
        {
            FileInfo = fileInfoRequest,
            Name = name,
        };
        public static string CutString(this string str, int length) => str.Length > length ? str.Substring(0, length) + "..." : str;
        public static (string path, string name) ConfiguratePath(string path)
        {
            string name = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
            string pathToFile = path.Substring(0, path.LastIndexOf("\\"));
            return (pathToFile, name);
        }
        public static void DeleteModule(this IModuleRepository<ModuleInfoRequest> repository, int id)
        {
            var module = repository.GetModules(x => x.Id == id).LastOrDefault();

            if (module is null) throw new NullReferenceException(nameof(module));

            repository.DeleteModule(module.Name!);
        }
        public static async Task SetImageProfile(this IUserRepositry<UserInfoRequest> userRepositry,IYandexClient client,FileInfoRequest fileInfo, string email)
        {

            var res = await client.AddModel(fileInfo.File!, fileInfo.Name!, fileInfo.Path ?? string.Empty);

            if (!res.isCorrect) throw new Exception($"{nameof(res)} was incorrect");

            var user = userRepositry.GetUsers(x => x.Email == email).SingleOrDefault();

            if (user is null) throw new NullReferenceException(nameof(user));

            user.Photo = new BinaryData()
            {
                LinkOnData = res.resultUrlFromModel,
            };
            userRepositry.Update(user.Id, user);
        }
        public static BinaryData GetImageProfile(this IUserRepositry<UserInfoRequest> userRepositry, string email)
        {
            var user = userRepositry.GetUsers(x => x.Email == email).SingleOrDefault();

            if (user is null) throw new ArgumentNullException(nameof(user));

            return user.Photo!;
        }
        public static IEnumerable<Module>? GetAllUserModule(this IUserRepositry<UserInfoRequest> repository, string name, string email, TypeModule typeModule)
        {
            var user = repository.Get(email);

            if (user is null) throw new NullReferenceException(nameof(user));

            if (typeModule is TypeModule.Test) return user.TestModules!.Where(x => x.Name == name);

            if (typeModule is TypeModule.Theoretical) return user.TheoreticalModules!.Where(x => x.Name == name);
           
            return null;
        }

        public static ModuleOnUserInfo CreateInfo(string nameModule, TypeModule typeModule ) => new ModuleOnUserInfo()
        {
            Name = nameModule,
            TypeModule = typeModule
        };
        public static bool GiveAnswer(this IGetUser repositry, UserAction action ,string email)
        {
            HandlerInput handlerInput = new HandlerInput();

            var user = repositry.Get(email);

            if (user is null) throw new NullReferenceException();

            return handlerInput.Initaction(action, user);
        }
        public static void ChangeVisible<T>(List<T> objIsVisible, List<T> objIsNotVisible)
        {
            foreach (T obj in objIsVisible)
            {
                obj!.GetType().GetProperty("Visible")!.SetValue(obj, true);
            }
            foreach (T obj in objIsNotVisible)
            {
                obj!.GetType().GetProperty("Visible")!.SetValue(obj, false);
            }
        }
        public static UserInfoRequest GetUserWithInfo(this User user)
        {
            UserInfoRequest? model = null;
            var map = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<User, UserInfoRequest>()
            .ForMember(nameof(model.Email), opt => opt.MapFrom(x => x.Email))
            .ForMember(nameof(model.Surname), opt => opt.MapFrom(x => x.Surname))
            .ForMember(nameof(model.Salt), opt => opt.MapFrom(x => x.Salt))
            .ForMember(nameof(model.IsAdmin), opt => opt.MapFrom(x => x.IsAdmin))
            .ForMember(nameof(model.Id), opt => opt.MapFrom(x => x.Id))
            .ForMember(nameof(model.Patronymic), opt => opt.MapFrom(x => x.Patronymic))
            .ForMember(nameof(model.PasswordHash), opt => opt.MapFrom(x => x.PasswordHash))
            ));
            model = map.Map<UserInfoRequest>(user);
            return model;
        }
        public static List<Aim> SetNewTasks()
        {
            var tasks = new List<Aim>()
            {
                new Aim()
                {
                    Content = new Content()
                    {
                        BinaryDatas = new List<BinaryData>(),
                    }
                }
            };
            return tasks;
        }
        public static Incident SetLinksTypeOnModel(this Incident? model)
        {
            if (model is null)
                model = new Incident()
                {
                    BinaryData = new BinaryData(),
                    Users = new List<User>()
                };
            else
            {
                if (model.BinaryData is not null)
                    model.BinaryData = new BinaryData();
                if (model.Users is not null)
                    model.Users = new List<User>();
            }
            return model;
        }
        public static BinaryData SetLinkOnBinaryData(ref Incident? incident, string? url)
        {
            if(incident is null) throw new ArgumentNullException(nameof(incident));
            var model = incident.BinaryData;
            if (model is null)
            {
                model = new BinaryData()
                {
                    Content = new Content(),
                    Incident = incident,
                    LinkOnData = url
                };
                incident.BinaryData = model;
            }
            else
            {
                model.Content = new Content();
                model.Incident = incident;
                model.LinkOnData = url;
            }
            return model;
        }
        public static BinaryData SetContentBinaryData(this BinaryData? model, ContentOptions options)
        {
            var content = new Content()
            {
                ConfusingAnswers = options.ConfusingAnswers,
                CorrectAnswer = options.CorrectAnswer,
                Text = options.Text,
                TypeInput = options.TypeInput,
                UserAnswer = options.UserAnswer,
            };
            model!.Content = content;
            return model;
        }
    }
}
