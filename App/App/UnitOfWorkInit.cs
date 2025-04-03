using BuisnesLogic.Service.Clients;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic;
using BuisnessLogic.Models.Request;
using BuisnessLogic.Services;
using Data;
using Data.ConstStorages;
using Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public static class UnitOfWorkInit
    {
        private static AppDbContext DbContext
        {
            get
            {
                if(Buffer_DB is null) Buffer_DB = CreateAppDbContext();
                return Buffer_DB;
            }
        }

        private static IYandexClient YandexClient = CreateYandexClient();

        private static UnitOfWork UnitOfWork 
        { 
            get
            {
                if (Buffer_U is null) Buffer_U = CreateUnitOfWork(DbContext, YandexClient);
                return Buffer_U;
            }
        }
        private static UnitOfWork? Buffer_U;
        private static AppDbContext? Buffer_DB;
        private static AppDbContext CreateAppDbContext()
        {

            using (var manager = new PasswordManager(new PasswordSaltOptions() { Password = "Admin" }))
            {
                var passworinfo = manager.Salt(8);

                var dbcontext = new AppDbContext(AppConstStorage.ConnectionDb, passworinfo.Hash, passworinfo.Salt);

                return dbcontext;
            }
        }
        private static IYandexClient CreateYandexClient()
        {
            using (var file = new StreamReader(AppConstStorage.ConfigPath))
            {
                var json = file.ReadToEnd();

                var config = JsonSerializer.Deserialize<YandexCloudConfig>(json) ?? throw new NullReferenceException();

                IYandexClient yandexclient = new YandexCloudClient(config.Id, config.Key, config.BucketName);

                return yandexclient;
            }
        }
        private static UnitOfWork CreateUnitOfWork(AppDbContext dbContext, IYandexClient client)
        {
            return new UnitOfWork(dbContext, client);
        }
        public static UnitOfWork GetUnitOfWork()
        {
            return UnitOfWork;
        }
    }
}
