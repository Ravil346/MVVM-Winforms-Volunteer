using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Extensions;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Validators;
using Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Data.Entities.Module;
using Task = System.Threading.Tasks.Task;

namespace BuisnessLogic.Services.Repositories
{
    public class UserRepository : IUserRepositry<UserInfoRequest>
    {
        private AppDbContext _Database;
        private UserValidator? _Validator;
        public UserRepository(UnitOfWork unitOfWork)
        {
            _Database = unitOfWork.DataBase ?? throw new ArgumentNullException(nameof(unitOfWork.DataBase));
        }
        #region Get
        public IQueryable<User> GetUsers(bool asNoTracking = false) => asNoTracking ? _Database.Users.AsNoTracking() : _Database.Users;
        
        public IEnumerable<User> GetUsers(Func<User,bool> exprfinding, bool asNoTracking = false) => asNoTracking ? _Database.Users.AsNoTracking().Where(exprfinding) : _Database.Users.Where(exprfinding);
        public User? Get(int id) => GetUsers(x => x.Id == id).SingleOrDefault();
        public User? Get(string email) => GetUsers(x => x.Email == email).SingleOrDefault();
        public IEnumerable<User> Get<T>(string propertyName, T propertyValue) where T : class => GetUsers().Where(x => GetPropValue<T>(x, propertyName) == propertyValue);
       
        
        #endregion
        #region Create
        public void Create(UserInfoRequest userinfo)
        {
            User? model = null;

            _Validator = new UserValidator(_Database, [nameof(model.Email), nameof(model.Id)]);

            var resValidation = _Validator.Validate(userinfo);

            if (!resValidation.IsValid) throw new Exception(string.Join(Environment.NewLine, resValidation.Errors.Select(x => x.ErrorMessage)));

            _Database.Users.Add(userinfo);
            _Database.SaveChanges();

        }
        #endregion
        #region Update
        public void Update(int id, User newModel)
        {
            var userInData = GetUsers(x => x.Id == id).SingleOrDefault();

            if (userInData is null) throw new NullReferenceException(nameof(userInData));

            CommonUpdate(userInData, newModel);
        }
        
        public void Update(string email, User newModel)
        {
            var userInData = GetUsers(x => x.Email == email).SingleOrDefault();

            if (userInData is null) throw new NullReferenceException(nameof(userInData));

            CommonUpdate(userInData, newModel);
        }
        #endregion
        #region Delete
        public void Delete(int id)
        {
            var user = Get(id);

            if(user is null) throw new NullReferenceException(nameof(user));

            _Database.Users.Remove(user);
            _Database.SaveChanges();

        }
        public void Delete(string email)
        {
            var user = Get(email);

            if(user is null) throw new NullReferenceException(nameof(user));

            _Database.Users.Remove(user);
            _Database.SaveChanges();

        }
        #endregion
        #region Helpers
        private T? GetPropValue<T>(User user, string name) where T : class => user.GetType().GetProperty(name) != null ? user.GetType().GetProperty(name)!.GetValue(user) as T : null;
        private void SetValue(User newuser, User olduser)
        {
            newuser.TheoreticalModules = olduser.TheoreticalModules;

            newuser.TestModules = olduser.TestModules;

            newuser.Incidents = olduser.Incidents;

            _Database.Entry(olduser).CurrentValues.SetValues(newuser);
        }
        private void CommonUpdate(User userInData, User newmodel)
        {
            var newuser = ExtensionsManagers.ExcludeEmptyModel(userInData, newmodel);

            SetValue(newuser, userInData);

            _Database.Users.Update(userInData);

            _Database.SaveChanges();
        }
        #endregion

    }
}
