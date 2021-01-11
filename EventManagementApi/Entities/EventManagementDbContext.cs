using EventManagementApi.Services.Entity.Impl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class EventManagementDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Sponsor> Sponsors { get; set; }

        public DbSet<Timeslot> Timeslots { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventOffering> EventOfferings { get; set; }

        public DbSet<CourseOffering> CourseOfferings { get; set; }

        public DbSet<CourseOfferingRegistration> CourseOfferingRegistrations { get; set; }

        public DbSet<EventOfferingRegistration> EventOfferingRegistrations { get; set; }

        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // EF Entity code-first configuration
            // Location
            modelBuilder.Entity<Location>(location =>
            {
                location.Property(l => l.Id).ValueGeneratedOnAdd();
            });

            // Room
            modelBuilder.Entity<Room>(room =>
            {
                room.Property(r => r.Id).ValueGeneratedOnAdd();
            });

            // Event
            modelBuilder.Entity<Event>(@event =>
            {
                @event.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            // Course
            modelBuilder.Entity<Course>(course =>
            {
                course.Property(c => c.Id).ValueGeneratedOnAdd();
            });

            // Timeslot
            modelBuilder.Entity<Timeslot>(timeslot =>
            {
                timeslot.Property(t => t.Id).ValueGeneratedOnAdd();
            });

            // Instructor
            modelBuilder.Entity<Instructor>(instructor =>
            {
                instructor.Property(i => i.Id).ValueGeneratedOnAdd();
            });

            // Sponsor
            modelBuilder.Entity<Sponsor>(sponsor =>
            {
                sponsor.Property(s => s.Id).ValueGeneratedOnAdd();
            });

            // Course Offering
            modelBuilder.Entity<CourseOffering>(co =>
            {
                co.Property(c => c.Id).ValueGeneratedOnAdd();
            });

            // Event Offering
            modelBuilder.Entity<EventOffering>(eo =>
            {
                eo.Property(eo => eo.Id).ValueGeneratedOnAdd();
            });

            // CourseOfferingRegistration
            modelBuilder.Entity<CourseOfferingRegistration>(cor =>
            {
                cor.Property(co => co.Id).ValueGeneratedOnAdd();
            });

            // EventOfferingRegistration
            modelBuilder.Entity<EventOfferingRegistration>(eor =>
            {
                eor.Property(eo => eo.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
