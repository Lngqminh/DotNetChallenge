using DotNetChallenge.Domains.Entities;
using DotNetChallenge.Services;

namespace DotNetChallenge.Repositories
{
    public class ProductRepository : IProductService
    {
        private static List<Products> _products = new List<Products>
        {
            new Products{Id = 1, Name = "Bàn Phím", Price = 300},
            new Products{Id = 2, Name = "Chuột", Price = 500}
        };
        public Task Add(Products product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var exitedId = _products.FirstOrDefault(p => p.Id == id);
            if (exitedId != null)
                _products.Remove(exitedId);
            return Task.CompletedTask;
        }

        public Task<List<Products>> GetAll()
        {
            return Task.FromResult(_products.ToList());
        }

        public Task<Products> GetById(int id)
        {
            var products = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(products);

        }

        public Task Update(Products product)
        {
            var exitedId = _products.FirstOrDefault(p => p.Id == product.Id);
            if (exitedId != null)
            {
                exitedId.Name = product.Name;
                exitedId.Price = product.Price;
            }
            return Task.CompletedTask;
        }
    }
}
