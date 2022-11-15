using Microsoft.AspNetCore.Mvc;
using Event.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipationController : ControllerBase
    {
        private readonly IParticipationService _service;

        public ParticipationController(IParticipationService service)
        {
            _service = service;
        }


        // GET: api/<EnrollmentsController>
        [HttpGet]
        public ActionResult Get()
        {
            var participation = _service.GetParticipation();
            return Ok(participation);
        }

        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var participation = _service.GetParticipationById(id);
            if (participation == null) return NotFound("There is no participation with an ID of " + id);
            return Ok(participation);
        }

        // GET api/Enrollments/student/5
        [HttpGet("{userId}")]
        public ActionResult GetByUser(int userId)
        {
            var participation = _service.GetParticipationsByUserId(userId);
            if (participation == null) return NotFound("There are no participations for a user with an ID of " + userId);
            return Ok(participation);
        }

        // POST api/<ParticipationController>
        [HttpPost]
        public ActionResult Post(int thingToDoId, int participationId)
        {
            return Ok(_service.CreateParticipation(thingToDoId, participationId));
        }

        // delete participation
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var enrollment = _service.DeleteParticipation(id);
            if (enrollment == null) return NotFound("There is no participation with an ID of " + id);
            return Ok(enrollment);
        }

        // get all teachers
        [HttpGet("attendees")]
        public ActionResult GetNumberOfAttendees(int eventId)
        {
            var numberOfAttendees = _service.GetNumberOfAttendees(eventId);
            return Ok(numberOfAttendees);
        }

    }
}
