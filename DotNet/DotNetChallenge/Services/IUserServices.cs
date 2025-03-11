using DotNetChallenge.Domains.Entities;

namespace DotNetChallenge.Services
{
    public interface IUserServices
    {
        Task<List<Users>> GetAll();
        Task<Users> GetById(int id);
        Task Add(Users users);
        Task Update(Users users);
        Task Delete(int id);
    }
}
