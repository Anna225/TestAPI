using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestAPI.Model;

namespace TestAPI.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService()
        {
            _client = new HttpClient();
        }
        public void Dispose()
        {
            
        }

        public async Task<List<User>> GetAllUser()
        {
            var streamUsers = await _client.GetStreamAsync("https://gorest.co.in/public/v2/users");
            var users = await JsonSerializer.DeserializeAsync<List<User>>(streamUsers);
            return users;
        }
        public async Task<List<User>> GetInactiveFemaleUser()
        {
            var streamUsers = await _client.GetStreamAsync("https://gorest.co.in/public/v2/users");
            List<User> users = await JsonSerializer.DeserializeAsync<List<User>>(streamUsers);
            return users.Where(x => x.gender == "female" && x.status == "inactive").ToList();
        }
        public async Task<User> SearchUserByEmail(SearchUserDto dto)
        {
            var streamUsers = await _client.GetStreamAsync("https://gorest.co.in/public/v2/users");
            List<User> users = await JsonSerializer.DeserializeAsync<List<User>>(streamUsers);
            var searchedUsers = users.Where(x => x.email == dto.email).ToList();
            if (searchedUsers.Count > 0)
            {
                return searchedUsers[0];
            }
            else
            {
                return null;
            }
        }
    }
}
