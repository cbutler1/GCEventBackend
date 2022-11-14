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
        ICollection<Participation> GetParticipationsByUserId(int id);
        Participation DeleteParticipation(int id);
        //ICollection<string> GetUsers();
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

        public ICollection<Participation> GetParticipationsByUserId(int id)
        {
            
            var e = _context.Participations.Include(e => e.ThingToDo)
                .Where(e => e.UserId == id)
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

        //ICollection<string> IParticipationService.GetUsers()
        //{
        //    return _context.ThingToDos.Select(c => c.User).Distinct().ToList();
        //}
       
    }
}

