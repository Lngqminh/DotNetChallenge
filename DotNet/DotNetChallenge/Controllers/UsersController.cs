using DotNetChallenge.Repositories;
using DotNetChallenge.Domains.Entities;
using DotNetChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userReponsitory;

        public UsersController(IUserServices userReponsitory)
        {
            _userReponsitory = userReponsitory;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var _user = _userReponsitory.GetAll();
            return Ok(_user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var _user = _userReponsitory.GetById(id);
            if (_user == null)
                return NotFound();
            return Ok(_user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Users user)
        {
            if (user == null)
                return BadRequest();
            var users = new Users
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
            _userReponsitory.Add(users);
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Users user, int id )
        {
            var exited = _userReponsitory.GetById(id);
            if (exited == null)
                return NotFound();
            user.Id = id;
            _userReponsitory.Update(user);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id) 
        {
            var exited = _userReponsitory.GetById(id);
            if (exited == null)
                return NotFound();
            _userReponsitory.Delete(id);
            return Ok();
        }
    }
}
