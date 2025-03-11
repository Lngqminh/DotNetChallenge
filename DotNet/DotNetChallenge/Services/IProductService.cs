using DotNetChallenge.Domains.Entities;

namespace DotNetChallenge.Services
{
    public interface IProductService
    {
        Task<List<Products>> GetAll();
        Task<Products> GetById(int id);
        Task Add(Products product);
        Task Update(Products product);
        Task Delete(int id);
    }
}
