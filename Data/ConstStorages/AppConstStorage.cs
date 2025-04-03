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
        public static string NameOfIntervalTableBetweenUserAndTest = "UserTestBinder";

        public static string NameOfIntervalTableBetweenUserAndTheor = "UserTheorBinder";

        public static string NameOfIntervalTableBetweenUserAndIncident = "UserIncidentBinder";

        public static string ConnectionDb => $"Data source={Environment.CurrentDirectory}\\dbmain.db;";

        public static string ConfigPath => $"{Environment.CurrentDirectory}\\appconfig.json";

        public static string FileButtonExitPath = Environment.CurrentDirectory.Replace("\\bin\\Debug\\net8.0-windows", "\\Assets\\exit.png");
    }
}
