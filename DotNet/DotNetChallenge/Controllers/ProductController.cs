using DotNetChallenge.Repositories;
using DotNetChallenge.Domains.Entities;
using DotNetChallenge.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductReponsitory _productReponsitory;

        public ProductController(IProductReponsitory productReponsitory) 
        {
            _productReponsitory = productReponsitory;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var product = _productReponsitory.GetAll();
            return Ok(product);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var Productid = _productReponsitory.GetById(id);
            if (Productid == null)
            {
                return NotFound();
            }
            return Ok(Productid);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Products product)
        {
            if (product == null) 
                return BadRequest();
            var products = new Products
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
            var add = _productReponsitory.Add(products);
            return Ok(add);
        }
        [HttpPut]
        public IActionResult Update([FromBody] Products product, int id)
        {
            var Productid = _productReponsitory.GetById(id);
            if (Productid  == null)
                return NotFound();
            product.Id = id;
            var up = _productReponsitory.Update(product);
            return Ok(up);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var Productid = _productReponsitory.GetById(id);
            if (Productid == null)
                return NotFound();
            var de = _productReponsitory.Delete(id);
            return Ok(de);
        }

    }
}
