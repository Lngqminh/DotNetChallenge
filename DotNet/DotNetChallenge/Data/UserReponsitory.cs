using DotNetChallenge.Domains.Entities;
using DotNetChallenge.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;

namespace DotNetChallenge.Data
{
    public class UserReponsitory:IUserReponsitory
    {
        private static List<Users> _user = new List<Users>
        {
            new Users {Id = 1, Name = "Quang Minh", Email = "qminh@gmail.com"},
            new Users {Id = 2, Name = "Thảo Nguyên", Email = "tnguyn@gmail.com"}
        };

        public async Task Add(Users users)
        {
            users.Id = _user.Count > 0 ? _user.Max(u => u.Id) + 1 : 1;
            _user.Add(users);
            await Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            var userID = _user.FirstOrDefault(u => u.Id == id);
            if (userID != null)
            {
                _user.Remove(userID);
            }
            await Task.CompletedTask; 
        }

        public async Task<List<Users>> GetAll()
        {
            return await Task.FromResult( _user.ToList());
        }

        public async Task<Users> GetById(int id)
        {
            var user = _user.SingleOrDefault(x => x.Id == id);
            return await Task.FromResult( user );
        }

        public async Task Update(Users users)
        {
            var exited = _user.FirstOrDefault(u => u.Id == users.Id);
            if( exited != null )
            {
                exited.Name = users.Name;
                exited.Email = users.Email;
            }    
            await Task.CompletedTask;
        }
    }
}
