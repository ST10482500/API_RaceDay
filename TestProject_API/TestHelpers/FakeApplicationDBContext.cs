using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_RaceDay.Controllers;
using API_RaceDay.Models;
using Microsoft.EntityFrameworkCore;

 namespace TestProject_API.TestHelpers
{
    public class FakeApplicationDBContext : DbContext // Fix: Inherit from DbContext
    {
        public FakeApplicationDBContext(DbContextOptions<FakeApplicationDBContext> options) : base(options)
        {
        }

        // Fix: Add DbSet<Organiser> property
        public DbSet<Organiser> Organisers { get; set; }

        // Fix: Add DbSet<Participant> property
        public DbSet<Participant> Participants { get; set; }

        // Fix: Add DbSet<Event> property
        public DbSet<Event> Events { get; set; }

        // Fix: Add DbSet<Category> property
        public DbSet<Category> Categories { get; set; }

        public static FakeApplicationDBContext GetApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<FakeApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new FakeApplicationDBContext(options);
            // Seed the in-memory database with test data if needed
            context.Organisers.Add(new Organiser { OrganiserID = 1, Name = "Comrades Org", Email = "comrades@race.com", ContactNumber = "0123456789" });
            context.Participants.Add(new Participant { ParticipantID = 1, Name = "Wayrren", Email = "wayrren@mail.com", Age = 20, Gender = "M" });
            context.Events.Add(new Event { EventID = 1, Title = "Comrades Marathon", Date = new DateTime(2024, 6, 15), Location = "Durban", OrganiserID = 1 });
            context.Categories.Add(new Category { CategoryID = 1, EventID = 1, Name = "42Km Run", Distance = "42" });
            context.SaveChanges(); // Ensure changes are saved
            return context;
        }
    }
}
