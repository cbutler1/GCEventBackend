using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Event.Dataa.TableModels
{
    public class ThingToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        public DateTime Time { get; set; }

        public double Price { get; set; }

        public string Location { get; set; }

        public ICollection<Participation> Participations { get; set; }
    }
}
