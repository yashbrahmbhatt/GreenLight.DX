using GreenLight.DX.Hermes.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GreenLight.DX.Hermes.Converters
{
    public class LogMessageFormatter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 4)
                return DependencyProperty.UnsetValue;

            DateTime timestamp = (DateTime)values[0];
            LogLevel level = (LogLevel)values[1];
            string context = (string)values[2];
            string message = (string)values[3];

            context = context.Length > 15 ? context.Substring(0, 15) + "..." : context;

            return $"[{timestamp:HH:mm:ss}] [{level,-8}] [{context,-20}]: {message}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
