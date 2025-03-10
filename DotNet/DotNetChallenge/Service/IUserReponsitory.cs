using DotNetChallenge.Domains.Entities;

namespace DotNetChallenge.Service
{
    public interface IUserReponsitory
    {
        Task<List<Users>> GetAll();
        Task<Users> GetById(int id);
        Task Add(Users users);
        Task Update(Users users);
        Task Delete(int id);
    }
}
