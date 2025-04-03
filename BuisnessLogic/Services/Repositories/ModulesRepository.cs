using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Validators;
using Data;
using Data.Entities;
using Data.Interfaces;
using Data.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Module = Data.Entities.Module;

namespace BuisnessLogic.Services.Repositories
{
    public class ModulesRepository : IModuleRepository<ModuleInfoRequest>
    {
        private AppDbContext _DataBase;
        private ModuleValidator? _Validator;
        private IGetUser _GetUser;
        private IUpdateUser<UserInfoRequest> _UpdateUser;
        public ModulesRepository(UnitOfWork unitOfWork)
        {
            _DataBase = unitOfWork.DataBase ?? throw new ArgumentNullException(nameof(unitOfWork.DataBase));
            _GetUser = unitOfWork.Users ?? throw new ArgumentNullException(nameof(unitOfWork.Users));
            _UpdateUser = unitOfWork.Users ?? throw new ArgumentNullException(nameof (unitOfWork.Users));
        }
        #region Get
        public IQueryable<Module> GetModules() => _DataBase.Module;
        public Module? GetModule(string name)
        {
            var module = GetModules(x => x.Name == name).SingleOrDefault();

            if (module is null) return null;

            if (module.Type is TypeModule.Test) module.TasksTest = GetTasksModule(module);

            if (module.Type is TypeModule.Theoretical) module.TasksTheoretical = GetTasksModule(module);

            return module;
        }
        private List<Aim>? GetTasksModule(Module model)
        {
            List<Aim>? tasks = null;
            if (model.Type is TypeModule.Test)
            {
                tasks = _DataBase.Tasks.Where(x => x.TestModuleId == model.Id).ToList();
            }
            if (model.Type is TypeModule.Theoretical)
            {
                tasks = _DataBase.Tasks.Where(x => x.TheoretiesModuleId == model.Id).ToList();
            }
            if (tasks is null) return tasks;
            foreach (var task in tasks)
            {
                var content = _DataBase.Contents.Where(x => x.TaskId == task.Id).FirstOrDefault();
                if (content is not null)
                {
                    content.BinaryDatas = GetLinksOnBinaryData(content);
                    content.ConfusingAnswers = GetConfusingAnswers(content);
                    task.Content = content;
                }
            }
            return tasks;

        }
        private List<BinaryData> GetLinksOnBinaryData(Content content)
        {
            var datas = _DataBase.BinaryDatas.Where(c => c.ContentId == content.Id).ToList();
            return datas;
        }
        private List<ConfusingAnswers> GetConfusingAnswers(Content content)
        {
            var confs = _DataBase.ConfusingAnswers.Where(c => c.ContentId == content.Id).ToList();
            return confs;
        }
        public IEnumerable<Module> GetModules(Func<Module, bool> func) => GetModules().Where(func);
        public IEnumerable<Module> GetTheoreticalModules(Func<Module, bool> func) => GetModules(x => x.Type == TypeModule.Theoretical).Where(func);
        public IEnumerable<Module> GetTestModules(Func<Module, bool> func) => GetModules(x => x.Type == TypeModule.Test).Where(func);
        #endregion
        #region Add
        public void AddModule(ModuleInfoRequest request)
        {
            if(request.TypeModule is TypeModule.Test) _Validator = new ModuleValidator(tasktestIsNotNull: true);
            if (request.TypeModule is TypeModule.Theoretical) _Validator = new ModuleValidator(tasktherIsNotNull: true);
            Validate(request);

            var model = GetModules(x => x.Exists == null & x.Name == request.Name).SingleOrDefault();

            if (model is not null) throw new Exception($"{model} isn`t null");

            _DataBase.Module.Add(request);
            _DataBase.SaveChanges();
        }
        public void AddLinkOnUser(ModuleInfoRequest request, int userid)
        {
            var user = _GetUser.Get(userid);

            if (user is null) throw new NullReferenceException(nameof(user));

            AddLinkOnUser(request, user);
        }
        public void AddLinkOnUser(ModuleInfoRequest request, string email)
        {
            var user = _GetUser.Get(email);

            if (user is null) throw new NullReferenceException(nameof(user));

            AddLinkOnUser(request, user);
        }
        private void AddLinkOnUser(ModuleInfoRequest request, User user)
        {
            _Validator = new ModuleValidator(request.TypeModule);

            Validate(request);

            var module = GetModules(x => x.Name == request.Name).LastOrDefault();

            if (module is null) throw new NullReferenceException(nameof(module));

            if (request.TypeModule is TypeModule.Theoretical)
            {
                user.TheoreticalModules!.Add(module);

                module.UsersTheoretical!.Add(user);
            }
            if (request.TypeModule is TypeModule.Test)
            {
                user.TestModules!.Add(module);

                module.UsersTest!.Add(user);

                module.Exists = 1;
            }
            _UpdateUser.Update(user.Id, user);

            UpdateModule(module.Id, module);

            _DataBase.SaveChanges();
        }
        #endregion
        #region Update
        public void UpdateModule(int id, Module newmodule)
        {
            var model = GetModules(x => x.Id == id).SingleOrDefault();

            if (model is null) throw new NullReferenceException(nameof(model));

            _DataBase.Module.Entry(model).CurrentValues.SetValues(newmodule);

            _DataBase.Module.Update(model);
        }
        #endregion
        #region Delete
        public void DeleteModule(string name)
        {
            var module = GetModules(x => x.Name == name).SingleOrDefault();

            if (module is null) throw new NullReferenceException(nameof(module));

            //if(module.Exists != null)
            //{
            //    var type = (TypeModule)module.Type!;

            //    var user = type is TypeModule.Test ? module.UsersTest!.LastOrDefault() : module.UsersTheoretical!.LastOrDefault();

            //    if (user is null) throw new NullReferenceException(nameof(user));

            //    DeleteOnUser(new ModuleInfoRequest() { Name = module.Name!, TypeModule = type}, user.Id);

            //    return;
            //}

            _DataBase.Module.Remove(module);

            _DataBase.SaveChanges();
        }
        public void DeleteOnUser(ModuleInfoRequest request, int userid)
        {
            var user = _GetUser.Get(userid);

            if(user is null) throw new NullReferenceException(nameof(user));

            if(request.TypeModule == TypeModule.Test) user.TestModules!.RemoveAll(x => x.Name == request.Name);

            if (request.TypeModule == TypeModule.Theoretical) user.TheoreticalModules!.RemoveAll(x => x.Name == request.Name);

            _DataBase.SaveChanges();
        }
        public void DeleteOnUser(ModuleInfoRequest request, string email)
        {
            var user = _GetUser.Get(email);

            if (user is null) throw new NullReferenceException(nameof(user));

            if (request.TypeModule == TypeModule.Test) user.TestModules!.RemoveAll(x => x.Name == request.Name);

            if (request.TypeModule == TypeModule.Theoretical) user.TheoreticalModules!.RemoveAll(x => x.Name == request.Name);

            _DataBase.SaveChanges();
        }
        #endregion
        #region Other
        private void Validate(ModuleInfoRequest request)
        {
            var validres = _Validator!.Validate(request);

            if (!validres.IsValid) throw new Exception(string.Join(Environment.NewLine, validres.Errors.Select(x => x.ErrorMessage)));
        }

        public void ChangeModuleOnUser(string userEmail, string nameModule, TypeModule typeModule, Module newModule)
        {
            var user = _GetUser.Get(userEmail);

            if(user is null) throw new NullReferenceException(nameof(user));

            IEnumerable<Module>? modules = null;

            if (typeModule is TypeModule.Test) modules = user.TestModules!.Where(x => x.Name == nameModule);

            if(typeModule is TypeModule.Theoretical) modules = user.TheoreticalModules!.Where(x => x.Name == nameModule);

            if (modules is null) throw new NullReferenceException(nameof(modules));
                 
            foreach(var module in modules)
            {
                UpdateModule(module.Id, newModule);
            }
            _DataBase.SaveChanges();
        }

        
        #endregion
    }
}
