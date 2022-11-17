using Microsoft.EntityFrameworkCore;
using Event.Data;
using Event.Data.TableModels;

namespace Event.Services.Services
{
    public interface IParticipationService
    {
        Participation CreateParticipation(int user, int thingToDo);
        ICollection<Participation> GetParticipation();
        Participation? GetParticipationById(int id);
        ICollection<ThingToDo> GetParticipationsByUserId(int id);
        Participation DeleteParticipation(int id);
        Participation DeleteParticipationUserIdThingToDoId(int thingToDoId, int userId);
        int GetNumberOfAttendees(int eventId);
    }


    public class ParticipationService : IParticipationService
    {
        private readonly EventDbContext _context;

        public ParticipationService(EventDbContext context)
        {
            _context = context;
        }

        public Participation CreateParticipation(int thingToDoId, int usertId)
        {
            Participation participation = new Participation()
            {
                ThingToDoId = thingToDoId,
                UserId = usertId
        };

            _context.Participations.Add(participation);
            _context.SaveChanges();

            return participation;
        }
        
        public ICollection<Participation> GetParticipation()
        {
            return _context.Participations.ToList();
        }

        public Participation? GetParticipationById(int id)
        {
            return _context.Participations.SingleOrDefault(e => e.Id == id);
        }

        public ICollection<ThingToDo> GetParticipationsByUserId(int id)
        {
            var e = _context.Participations.Include(x => x.ThingToDo)
                .Where(z => z.UserId == id)
                .Select(t => t.ThingToDo)
                .ToList();
            return e;
        }

        Participation IParticipationService.DeleteParticipation(int id)
        {
            Participation enrollment = _context.Participations.SingleOrDefault(e => e.Id == id);
            _context.Participations.Remove(enrollment);
            _context.SaveChanges();
            return enrollment;
        }

        public Participation DeleteParticipationUserIdThingToDoId(int userId, int thingToDoId )
        {
            Participation participation = _context.Participations.SingleOrDefault(e => e.ThingToDoId == thingToDoId && e.UserId == userId);
            if(participation == null)
                return null;
            Console.WriteLine(participation);
            _context.Participations.Remove(participation);
            _context.SaveChanges();
            return participation;
        }

        int IParticipationService.GetNumberOfAttendees(int eventId)
        {
            return _context.Participations.Where(x => x.Id == eventId).Count();
        }

    }
}

