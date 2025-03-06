using GreenLight.DX.Shared.Hermes.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using UiPath.Studio.Api.Theme;

namespace GreenLight.DX.Shared.Hermes.Converters
{
    public class LogLevelToBrushConverter : IValueConverter
    {
        private int _theme; // Add theme field

        public LogLevelToBrushConverter() : this(0) { } // Default constructor

        public LogLevelToBrushConverter(int theme)
        {
            _theme = theme; // Initialize theme
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LogLevel level)
            {
                return GetColorForLevel(level);
            }
            return Brushes.Black; // Default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Brush GetColorForLevel(LogLevel level) => level switch
        {
            LogLevel.Debug => _theme == (int)ThemeType.Light ? Brushes.Blue : Brushes.DodgerBlue,
            LogLevel.Info => _theme == (int)ThemeType.Light ? Brushes.Black : Brushes.White,
            LogLevel.Warning => Brushes.Orange,
            LogLevel.Error => Brushes.Red,
            _ => Brushes.Black,
        };
    }
}
