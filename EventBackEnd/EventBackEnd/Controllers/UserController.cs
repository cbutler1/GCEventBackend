using Microsoft.AspNetCore.Mvc;
using Event.Data.TableModels;
using Event.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            var users = _service.GetUsers();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _service.GetUserById(id);
            if(user == null) return NotFound("There is no user with an id of " + id);
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost("{name}")]
        public ActionResult Post(string name)
        {
            return Ok(_service.CreateUser(name));
        }

        // Delete User
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _service.DeleteUser(id);
            if(user == false) return NotFound("There is no user with an id of " + id);
            return Ok("User with id " + id + " was deleted");
        }

        //update user
        [HttpPut("{id}/{name}")]
        public ActionResult Put(int id, string name)
        {
            var user = _service.GetUserById(id);
            if(user == null) return NotFound("There is no user with an id of " + id);
            return Ok(_service.UpdateUser(user, name));
        }
    }
}
