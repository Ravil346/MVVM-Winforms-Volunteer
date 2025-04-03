using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ConstStorages
{
    public class AppConstStorage
    {
        // Название таблицы, которая связывает пользователей и тесты в базе данных.
        public static string NameOfIntervalTableBetweenUserAndTest = "UserTestBinder";

        // Название таблицы, которая связывает пользователей и теоретические материалы в базе данных.
        public static string NameOfIntervalTableBetweenUserAndTheor = "UserTheorBinder";

        // Название таблицы, которая связывает пользователей и инциденты в базе данных.
        public static string NameOfIntervalTableBetweenUserAndIncident = "UserIncidentBinder";

        // Строка подключения к базе данных SQLite. База данных находится в текущей директории приложения, в файле dbmain.db.
        public static string ConnectionDb => $"Data source={Environment.CurrentDirectory}\\dbmain.db;";

        // Путь к файлу конфигурации приложения (appconfig.json), который расположен в текущей директории приложения.
        public static string ConfigPath => $"{Environment.CurrentDirectory}\\appconfig.json";

        // Путь к изображению кнопки выхода (exit.png). Путь корректируется для учета разницы между рабочей директорией приложения
        // и расположением ресурсов в папке Assets.
        public static string FileButtonExitPath = Environment.CurrentDirectory.Replace("\\bin\\Debug\\net8.0-windows", "\\Assets\\exit.png");
    }
}
