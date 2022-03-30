using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Model;

namespace TestAPI.Service
{
    public interface IUserService : IDisposable
    {
        Task<List<User>> GetAllUser();
        Task<List<User>> GetInactiveFemaleUser();
        Task<User> SearchUserByEmail(SearchUserDto dto);
    }
}
