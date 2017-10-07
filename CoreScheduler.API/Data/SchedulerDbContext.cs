﻿using CoreScheduler.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreScheduler.API.Data
{
    public class SchedulerDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendee> Attendess { get; set; }
        public SchedulerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Schedule>()
                .ToTable("Schedule");

            modelBuilder.Entity<Schedule>()
                .Property(s => s.CreatorId)
                .IsRequired();

            modelBuilder.Entity<Schedule>()
                .Property(s => s.DateCreated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.DateUpdated)
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.Type)
                .HasDefaultValue(ScheduleType.Work);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.Status)
                .HasDefaultValue(ScheduleStatus.Valid);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Creator)
                .WithMany(c => c.SchedulesCreated);

            modelBuilder.Entity<User>()
              .ToTable("User");

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Attendee>()
              .ToTable("Attendee");

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.User)
                .WithMany(u => u.SchedulesAttended)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Schedule)
                .WithMany(s => s.Attendees)
                .HasForeignKey(a => a.ScheduleId);
        }
    }
}