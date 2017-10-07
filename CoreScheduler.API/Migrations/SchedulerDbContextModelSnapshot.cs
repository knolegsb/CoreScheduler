using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreScheduler.API.Data;

namespace CoreScheduler.API.Migrations
{
    [DbContext(typeof(SchedulerDbContext))]
    partial class SchedulerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreScheduler.API.Data.Entities.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ScheduleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Attendee");
                });

            modelBuilder.Entity("CoreScheduler.API.Data.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatorId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 10, 6, 18, 35, 42, 828, DateTimeKind.Local));

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2017, 10, 6, 18, 35, 42, 844, DateTimeKind.Local));

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<DateTime>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.Property<string>("Title");

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("CoreScheduler.API.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Profession");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CoreScheduler.API.Data.Entities.Attendee", b =>
                {
                    b.HasOne("CoreScheduler.API.Data.Entities.Schedule", "Schedule")
                        .WithMany("Attendees")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("CoreScheduler.API.Data.Entities.User", "User")
                        .WithMany("SchedulesAttended")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CoreScheduler.API.Data.Entities.Schedule", b =>
                {
                    b.HasOne("CoreScheduler.API.Data.Entities.User", "Creator")
                        .WithMany("SchedulesCreated")
                        .HasForeignKey("CreatorId");
                });
        }
    }
}
