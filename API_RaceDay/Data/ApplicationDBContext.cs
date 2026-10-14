using API_RaceDay.Models;
using Microsoft.EntityFrameworkCore;
namespace API_RaceDay.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            // TODO: add a DbSet<T> property here for each model,
            // once the model classes in /Models have real properties.
            // e.g. public DbSet<User> Users { get; set; }



            // Ensure the base class constructor is correctly called with the options parameter.
        }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrolment>().HasKey(e => e.EnrolmentID);
            modelBuilder.Entity<Result>().HasKey(r=> r.ResultID);

           //Seed Organisers
            modelBuilder.Entity<Organiser>().HasData(
             new Organiser { OrganiserID = 1, Name = "Comrades Org",  Email = "comrade@race.com", ContactNumber = "0123456789" },
             new Organiser { OrganiserID = 2, Name = "Cycle Tour Org",  Email = "cycle@race.com", ContactNumber = "0987654321" }

                );
            //Seed participant
            modelBuilder.Entity<Participant>().HasData(
            new Participant { ParticipantID = 1, Name = "Wayrren", Email = "wayrren@mail.com", Age = 20, Gender = "M" },
            new Participant { ParticipantID = 2, Name = "Scarface", Email = "scarface@gmail.com", Age = 30, Gender = "M" }
            );
            //Seed Event
            modelBuilder.Entity<Event>().HasData(
            new Event { EventID = 1, Title = "Comrades Marathon", Date = new DateTime(2024, 6, 15), Location = "Durban", OrganiserID = 1 },
            new Event { EventID = 2, Title = "Cape Town Cycle Tour", Date = new DateTime(2024, 3, 10), Location = "Cape Town", OrganiserID = 2 }
            );
            //Seed Category
            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryID = 1, EventID = 1, Name = "42Km Run", Distance = "42" },
            new Category { CategoryID = 2, EventID = 1, Name = "109Km Run", Distance = "109" }
            );
            //Seed Enrolment
            modelBuilder.Entity<Enrolment>().HasData(
            new Enrolment { EnrolmentID = 1, ParticipantID = 1, EventID = 1, CategoryID = 1, RegistrationDate = new DateTime(2024, 5, 1) },
            new Enrolment { EnrolmentID = 2, ParticipantID = 2, EventID = 1, CategoryID = 2, RegistrationDate = new DateTime(2024, 5, 2) }
            );
            //Seed Result
            modelBuilder.Entity<Result>().HasData(
            new Result { ResultID = 1, EnrolmentID = 1, DurationTime = new TimeSpan(3, 45, 0), Position = 1 },
            new Result { ResultID = 2, EnrolmentID = 2, DurationTime = new TimeSpan(4, 10, 0), Position = 2 }
            );

        }

    }
}


        
    
    

