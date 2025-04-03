using Data.Entities;
using Data.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRepositry<in T> : IGetUser, ICreateUser<T>, IDeleteUser, IUpdateUser<T> 
    {
    }
}
