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
    /// <summary>
    /// Класс AppDbContext представляет контекст базы данных для работы с сущностями приложения.
    /// Он наследует DbContext и предоставляет доступ к таблицам базы данных через свойства DbSet.
    /// </summary>
    public class AppDbContext : DbContext
    {
        // Строка подключения к базе данных.
        private string _connectionString;

        // Хэш пароля для администратора. Используется для безопасного хранения учетных данных администратора.
        private string _HashForAdmin;

        // Соль для хэширования пароля администратора. Используется для повышения безопасности хэширования.
        private string _SaltForAdmin;

        /// Таблица для хранения бинарных данных (например, изображений или файлов).
        public DbSet<BinaryData> BinaryDatas => Set<BinaryData>();

        /// Таблица для хранения запутанных или сложных ответов.
        public DbSet<ConfusingAnswers> ConfusingAnswers => Set<ConfusingAnswers>();

        /// Таблица для хранения контента (например, вопросов или теоретических материалов).
        public DbSet<Content> Contents => Set<Content>();

        /// Таблица для хранения инцидентов.
        public DbSet<Incident> Incidents => Set<Incident>();

        /// Таблица для хранения модулей (теоретических или тестовых).
        public DbSet<Module> Module => Set<Module>();

        /// Таблица для хранения целей (например, задач или заданий).
        public DbSet<Aim> Tasks => Set<Aim>();

        /// Таблица для хранения пользователей системы.
        public DbSet<User> Users => Set<User>();

        /// <summary>
        /// Конструктор класса AppDbContext.
        /// </summary>
        /// <param name="connectionstr">Строка подключения к базе данных.</param>
        /// <param name="hashforadmin">Хэш пароля администратора.</param>
        /// <param name="saltforadmin">Соль для хэширования пароля администратора.</param>
        public AppDbContext(string connectionstr, string hashforadmin, string saltforadmin)
        {
            _connectionString = connectionstr; // Сохраняет строку подключения.
            _HashForAdmin = hashforadmin; // Сохраняет хэш пароля администратора.
            _SaltForAdmin = saltforadmin; // Сохраняет соль для хэширования.

            // Создает базу данных, если она еще не существует.
            Database.EnsureCreated();
        }

        /// <summary>
        /// Настройка параметров подключения к базе данных.
        /// </summary>
        /// <param name="optionsBuilder">Объект для настройки параметров контекста базы данных.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Использует SQLite в качестве провайдера базы данных.
            optionsBuilder.UseSqlite(_connectionString);

            // Включает поддержку расширяемых запросов через UseProjectables.
            optionsBuilder.UseProjectables();
        }

        /// <summary>
        /// Настройка модели базы данных (связи между таблицами, внешние ключи и т.д.).
        /// </summary>
        /// <param name="modelBuilder">Объект для настройки модели базы данных.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи "многие ко многим" между пользователями и тестовыми модулями.
            modelBuilder.Entity<User>()
                .HasMany(x => x.TestModules)
                .WithMany(x => x.UsersTest)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTest);

            // Настройка связи "многие ко многим" между пользователями и теоретическими модулями.
            modelBuilder.Entity<User>()
                .HasMany(x => x.TheoreticalModules)
                .WithMany(x => x.UsersTheoretical)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTheor);

            // Настройка связи "один к одному" между пользователем и его фото.
            modelBuilder.Entity<User>()
                .HasOne(x => x.Photo)
                .WithOne(x => x.User)
                .HasForeignKey<BinaryData>(x => x.UserId);

            // Настройка связи "многие ко многим" между пользователями и инцидентами.
            modelBuilder.Entity<User>()
                .HasMany(x => x.Incidents)
                .WithMany(x => x.Users)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndIncident);

            // Настройка связи "многие ко многим" между инцидентами и пользователями.
            modelBuilder.Entity<Incident>()
                .HasMany(x => x.Users)
                .WithMany(x => x.Incidents)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndIncident);

            // Настройка связи "один к одному" между инцидентом и его бинарными данными.
            modelBuilder.Entity<Incident>()
                .HasOne(x => x.BinaryData)
                .WithOne(x => x.Incident)
                .HasForeignKey<BinaryData>(x => x.IncidentId);

            // Настройка связи "один ко многим" между модулем и его тестовыми задачами.
            modelBuilder.Entity<Module>()
                .HasMany(x => x.TasksTest)
                .WithOne(x => x.TestModel)
                .HasForeignKey(x => x.TestModuleId);

            // Настройка связи "один ко многим" между модулем и его теоретическими задачами.
            modelBuilder.Entity<Module>()
                .HasMany(x => x.TasksTheoretical)
                .WithOne(x => x.TheoreticalModel)
                .HasForeignKey(x => x.TheoretiesModuleId);

            // Настройка связи "многие ко многим" между модулями и пользователями (тестовые модули).
            modelBuilder.Entity<Module>()
                .HasMany(x => x.UsersTest)
                .WithMany(x => x.TestModules)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTest);

            // Настройка связи "многие ко многим" между модулями и пользователями (теоретические модули).
            modelBuilder.Entity<Module>()
                .HasMany(x => x.UsersTheoretical)
                .WithMany(x => x.TheoreticalModules)
                .UsingEntity(AppConstStorage.NameOfIntervalTableBetweenUserAndTheor);

            // Настройка связи "один к одному" между целью и её контентом.
            modelBuilder.Entity<Aim>()
                .HasOne(x => x.Content)
                .WithOne(x => x.Task)
                .HasForeignKey<Content>(x => x.TaskId);

            // Настройка связи "один ко многим" между целью и её тестовым модулем.
            modelBuilder.Entity<Aim>()
                .HasOne(x => x.TestModel)
                .WithMany(x => x.TasksTest);

            // Настройка связи "один ко многим" между целью и её теоретическим модулем.
            modelBuilder.Entity<Aim>()
                .HasOne(x => x.TheoreticalModel)
                .WithMany(x => x.TasksTheoretical);

            // Настройка связи "один ко многим" между контентом и его запутанными ответами.
            modelBuilder.Entity<Content>()
                .HasMany(x => x.ConfusingAnswers)
                .WithOne(x => x.Content)
                .HasForeignKey(x => x.ContentId);

            // Настройка связи "один ко многим" между контентом и его бинарными данными.
            modelBuilder.Entity<Content>()
                .HasMany(x => x.BinaryDatas)
                .WithOne(x => x.Content)
                .HasForeignKey(x => x.ContentId);

            // Настройка связи "один к одному" между контентом и его целью.
            modelBuilder.Entity<Content>()
                .HasOne(x => x.Task)
                .WithOne(x => x.Content);

            // Настройка связи "один ко многим" между бинарными данными и их контентом.
            modelBuilder.Entity<BinaryData>()
                .HasOne(x => x.Content)
                .WithMany(x => x.BinaryDatas);

            // Настройка связи "один к одному" между бинарными данными и инцидентом.
            modelBuilder.Entity<BinaryData>()
                .HasOne(x => x.Incident)
                .WithOne(x => x.BinaryData);

            // Настройка связи "один ко многим" между запутанными ответами и их контентом.
            modelBuilder.Entity<ConfusingAnswers>()
                .HasOne(x => x.Content)
                .WithMany(x => x.ConfusingAnswers);

            // Добавление уникального индекса для имени инцидента.
            modelBuilder.Entity<Incident>()
                .HasIndex(x => new { x.Name }).IsUnique();

            // Добавление начальных данных: создание пользователя-администратора.
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Email = "Admin",
                IsAdmin = true,
                Name = "Admin",
                PasswordHash = _HashForAdmin,
                Salt = _SaltForAdmin
            });
        }
    }
}
