using Microsoft.EntityFrameworkCore;
using Event.Data.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data
{
    public class EventDbContext : DbContext
    {


        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }
        public DbSet<ThingToDo> ThingToDos { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participation>()
                .HasOne(e => e.User)
                .WithMany(s => s.Participations)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Participation>()
                .HasOne(e => e.ThingToDo)
                .WithMany(c => c.Participations)
                .HasForeignKey(e => e.ThingToDoId);
        }

    }
}