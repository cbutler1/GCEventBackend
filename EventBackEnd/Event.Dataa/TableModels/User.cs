using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event.Dataa.TableModels
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Password { get; set; } = "Password";

        public ICollection<Participation> Participations { get; set; }
    }
}
