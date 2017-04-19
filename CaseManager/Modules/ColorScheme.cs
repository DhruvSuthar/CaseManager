using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CaseManager.Modules
{
    public class ColorScheme
    {
        public Brush ForegroundColorPrimary { get; set; }
        public Brush BackgroundColor { get; set; }
        public Brush ForegroundColorSecondary { get; set; }

        public static ColorScheme GetDarkTheme()
        {
            ColorScheme cs = new ColorScheme();
            cs.ForegroundColorPrimary = Brushes.White;
            cs.ForegroundColorSecondary = Brushes.Gray;
            cs.BackgroundColor = Brushes.Black;
            return cs;
        }

        public static ColorScheme GetLightTheme()
        {
            ColorScheme cs = new ColorScheme();
            cs.ForegroundColorPrimary = Brushes.DarkBlue;
            cs.ForegroundColorSecondary = Brushes.White;
            cs.BackgroundColor = Brushes.DimGray;
            return cs;
        }
    }
}
