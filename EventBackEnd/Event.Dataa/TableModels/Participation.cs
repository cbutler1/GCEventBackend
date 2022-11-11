using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event.Data.TableModels
{
    public class Participation
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(ThingToDo))]
        public int EventId { get; set; }
        public ThingToDo Event { get; set; }
    }
}