using Microsoft.AspNetCore.Mvc;
using Event.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingToDoController : ControllerBase
    {
        private readonly IThingToDoService _service;

        public ThingToDoController(IThingToDoService service)
        {
            _service = service;
        }


        // GET: api/<CoursesController>
        [HttpGet]
        public ActionResult Get()
        {
            var courses = _service.GetThingToDos();
            return Ok(courses);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var course = _service.GetThingToDoById(id);
            if(course == null) return NotFound("There is no course with an ID of " + id);
            return Ok(course);
        }

        // GetStudentsForCourseId
        //[HttpGet("studentlist/{id}")]
        //public ActionResult GetStudentsList(int id)
        //{
        //    var csl = _service.GetUsersForThingToDoId(id);
        //    if(csl == null) return NotFound("There is no course with an ID of " + id);
        //    return Ok(csl);
        //}

        // POST api/<CoursesController>
        [HttpPost("name/{eventName}/price/{price}/location/{location}/date/{time}")]
        public ActionResult Post(string eventName, double price, string location, DateTime time)
        {
            return Ok(_service.CreateThingToDo(eventName, price, location, time));
        }
    }
}
