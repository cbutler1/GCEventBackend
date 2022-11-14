using Microsoft.AspNetCore.Mvc;
using School.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }


        // GET: api/<EnrollmentsController>
        [HttpGet]
        public ActionResult Get()
        {
            var enrollments = _service.GetEnrollments();
            return Ok(enrollments);
        }

        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var enrollment = _service.GetEnrollmentById(id);
            if(enrollment == null) return NotFound("There is no enrollment with an ID of " + id);
            return Ok(enrollment);
        }

        // GET api/Enrollments/student/5
        [HttpGet("{studentID}")]
        public ActionResult GetByStudent(int studentID)
        {
            var enrollments = _service.GetEnrollmentsByStudentId(studentID);
            if(enrollments == null) return NotFound("There are no enrollments for a student with an ID of " + studentID);
            return Ok(enrollments);
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public ActionResult Post(int courseId, int enrollmentId)
        {
            return Ok(_service.CreateEnrollment(courseId, enrollmentId));
        }

        // delete enrolment
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var enrollment = _service.DeleteEnrollment(id);
            if(enrollment == null) return NotFound("There is no enrollment with an ID of " + id);
            return Ok(enrollment);
        }

        // get all teachers
        [HttpGet("teachers")]
        public ActionResult GetTeachers()
        {
            var teachers = _service.GetTeachers();
            return Ok(teachers);
        }

    }
}
