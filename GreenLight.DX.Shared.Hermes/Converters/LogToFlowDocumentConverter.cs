using GreenLight.DX.Shared.Hermes.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using UiPath.Studio.Api.Theme;

namespace GreenLight.DX.Shared.Hermes.Converters
{
    public class LogToFlowDocumentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2 || !(values[0] is ListCollectionView logs) || !(values[1] is int theme))
                return DependencyProperty.UnsetValue;

            var flowDocument = new FlowDocument(); // Create FlowDocument

            foreach (var item in logs)
            {
                if (!(item is LogMessage log)) continue;

                var paragraph = new Paragraph();
                var run = new Run(log.ToString())
                {
                    Foreground = GetColorForLevel(log.Level, theme)
                };
                paragraph.Inlines.Add(run);
                flowDocument.Blocks.Add(paragraph); // Add Paragraph to FlowDocument
            }
            return flowDocument; // Return the FlowDocument
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Brush GetColorForLevel(LogLevel level, int theme) => level switch
        {
            LogLevel.Debug => theme == (int)ThemeType.Light ? Brushes.Blue : Brushes.DodgerBlue,
            LogLevel.Info => theme == (int)ThemeType.Light ? Brushes.Black : Brushes.White,
            LogLevel.Warning => Brushes.Orange,
            LogLevel.Error => Brushes.Red,
            _ => Brushes.Black,
        };
    }
}
