using BuisnesLogic.Service.Clients;
using BuisnesLogic.ServicesInterface;
using BuisnessLogic.Models;
using BuisnessLogic.Models.Request;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace UnitTests
{
    public class TestYCloud
    {
        private IYandexClient _Client { get; set; }
        public TestYCloud()
        {
            //Arrange
            string? path = Environment.CurrentDirectory + "\\appconfig.json";
            using(var file = new StreamReader(path))
            {
               var json = file.ReadToEnd();
               var config = JsonSerializer.Deserialize<YandexCloudConfig>(json) ?? throw new NullReferenceException();
               _Client = new YandexCloudClient(config.Id, config.Key, config.BucketName);
            }
            
        }
        [Fact]
        public async void AddTest()
        {
            
            using (var stream = new FileStream(@"D:\загрузки\Снимок экрана 2025-02-04 220643.png", FileMode.Open))
            {
                var res = await _Client.AddModel(stream, @"D:\загрузки", "Снимок экрана 2025-02-04 220643.png");
                Assert.True(res.isCorrect);
            }
        }
        [Fact]
        public async void UpdateTest()
        {
            using (var stream = new FileStream(@"D:\загрузки\Снимок экрана 2025-02-04 220643.png", FileMode.Open))
            {
                await _Client.AddModel(stream, @"D:\загрузки", "Снимок экрана 2025-02-04 220644.png");
                using (var streamnew = new FileStream(@"D:\загрузки\Снимок экрана 2025-02-04 220721.png", FileMode.Open))
                {
                    var res = await _Client.UpdateModel(streamnew, @"D:\загрузки", "Снимок экрана 2025-02-04 220644.png");
                    Assert.True(res.isCorrect);
                }
             
            }
        }
        [Fact]
        public async void DeleteTest()
        {
            using (var stream = new FileStream(@"D:\загрузки\Снимок экрана 2025-02-04 220643.png", FileMode.Open))
            {
                await _Client.AddModel(stream, @"D:\загрузки", "Снимок экрана 2025-02-04 220645.png");
            }
            var res = await _Client.DeleteModel(@"D:\загрузки", "Снимок экрана 2025-02-04 220645.png");
            Assert.True(res);

        }
    }
}