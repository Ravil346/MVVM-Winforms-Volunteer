using Data.ConstStorages;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aim = Data.Entities.Aim;

namespace Data
{
    public class AppDbContext : DbContext
    {
        private string _connectionString;
        public DbSet<BinaryData> BinaryDatas => Set<BinaryData>();
        public DbSet<ConfusingAnswers> ConfusingAnswers => Set<ConfusingAnswers>();
        public DbSet<Content> Contents => Set<Content>();
        public DbSet<Incident> Incidents => Set<Incident>();
        public DbSet<Module> Module => Set<Module>();
        public DbSet<Aim> Tasks => Set<Aim>();
        public DbSet<User> Users => Set<User>();

        private string _HashForAdmin;

        private string _SaltForAdmin;
        public AppDbContext(string connectionstr, string hashforadmin, string saltforadmin)
        {
            _connectionString = connectionstr;

            _HashForAdmin = hashforadmin;

            _SaltForAdmin = saltforadmin;

            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.UseProjectables();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.TestModules)
                .WithMany(x => x.UsersTest)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTest);
            modelBuilder.Entity<User>()
                .HasMany(x => x.TheoreticalModules)
                .WithMany(x => x.UsersTheoretical)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTheor);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Photo)
                .WithOne(x => x.User)
                .HasForeignKey<BinaryData>(x => x.UserId);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Incidents)
                .WithMany(x => x.Users)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndIncident);
            modelBuilder.Entity<Incident>()
                .HasMany(x => x.Users)
                .WithMany(x => x.Incidents)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndIncident);
            modelBuilder.Entity<Incident>()
                .HasOne(x => x.BinaryData)
                .WithOne(x => x.Incident)
                .HasForeignKey<BinaryData>(x => x.IncidentId);
            modelBuilder.Entity<Module>()
                .HasMany(x => x.TasksTest)
                .WithOne(x => x.TestModel)
                .HasForeignKey(x => x.TestModuleId);
            modelBuilder.Entity<Module>()
                .HasMany(x => x.TasksTheoretical)
                .WithOne(x => x.TheoreticalModel)
                .HasForeignKey(x => x.TheoretiesModuleId);
            modelBuilder.Entity<Module>()
                .HasMany(x => x.UsersTest)
                .WithMany(x => x.TestModules)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTest);
            modelBuilder.Entity<Module>()
                .HasMany(x => x.UsersTheoretical)
                .WithMany(x => x.TheoreticalModules)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTheor);
            modelBuilder.Entity<Aim>()
                .HasOne(x => x.Content)
                .WithOne(x => x.Task)
                .HasForeignKey<Content>(x => x.TaskId);
            modelBuilder.Entity<Aim>()
                .HasOne(x => x.TestModel)
                .WithMany(x => x.TasksTest);
            modelBuilder.Entity<Aim>()
                .HasOne(x => x.TheoreticalModel)
                .WithMany(x => x.TasksTheoretical);
            modelBuilder.Entity<Content>()
                .HasMany(x => x.ConfusingAnswers)
                .WithOne(x => x.Content)
                .HasForeignKey(x => x.ContentId);
            modelBuilder.Entity<Content>()
                .HasMany(x => x.BinaryDatas)
                .WithOne(x => x.Content)
                .HasForeignKey(x => x.ContentId);
            modelBuilder.Entity<Content>()
                .HasOne(x => x.Task)
                .WithOne(x => x.Content);
            modelBuilder.Entity<BinaryData>()
                .HasOne(x => x.Content)
                .WithMany(x => x.BinaryDatas);
            modelBuilder.Entity<BinaryData>()
                .HasOne(x => x.Incident)
                .WithOne(x => x.BinaryData);
            modelBuilder.Entity<ConfusingAnswers>()
                .HasOne(x => x.Content)
                .WithMany(x => x.ConfusingAnswers);
            modelBuilder.Entity<Incident>()
                .HasIndex(x => new {x.Name}).IsUnique();
            
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Email = "Admin", IsAdmin = true, Name = "Admin", PasswordHash = _HashForAdmin, Salt = _SaltForAdmin });
        }

    }
}
