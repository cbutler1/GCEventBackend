using Microsoft.AspNetCore.Mvc;
using School.Data.TableModels;
using School.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult Get()
        {
            var students = _service.GetStudents();
            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var student = _service.GetStudentById(id);
            if(student == null) return NotFound("There is no student with an id of " + id);
            return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult Post(string name)
        {
            return Ok(_service.CreateStudent(name));
        }

        // post random student using http client
        [HttpPost("random")]
        public async Task<ActionResult> Post()
        {
            var student = await _service.CreateRandomStudent();
            if(student == null)
            {
                return StatusCode(500, "Something went wrong");
            }
            return Ok(student);
        }


        // update student name
        [HttpPut("{id}")]
        public ActionResult Put(int id, string name)
        {
            var student = _service.UpdateStudentName(id, name);
            if(student == null) return NotFound("There is no student with an id of " + id);
            return Ok(student);
        }

        //delete student
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var student = _service.DeleteStudent(id);
            if(student == false) return NotFound("There is no student with an id of " + id);
            return Ok("Student with id " + id + " was deleted");
        }
    }
}
