using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class FormConstStorage
    {
        public static Color PlanesBackColor = Color.Lavender;
        public static FontFamily BaseFontFamily = new FontFamily("Georgia");
        public static Font BaseTitleFont = new Font(BaseFontFamily, 16, FontStyle.Bold);
        public static Font BaseFont = new Font(BaseFontFamily, 14, FontStyle.Bold);
        public static Color BaseTextColor = Color.Black;
        public static Color BaseBackColorForButton = Color.Gray;
        public static Color BaseForeColorForButton = Color.Black;
        public static Color BaseColorForDataGridView = Color.Gray;
        public static Color BaseColorForBackDataGrid = Color.Thistle;
        public static Color BackColorForIncident = Color.White;
        public static Color BaseBackColorForIncidentPanel = Color.White;
    }
}
