using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GreenLight.DX.Config.Studio.Converters
{
    public class MathOperationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double value1 && values[1] is double value2 && parameter is string operation)
            {
                return operation switch
                {
                    "Add" => value1 + value2,
                    "Subtract" => value1 - value2,
                    "Multiply" => value1 * value2,
                    "Divide" => value1 / value2,
                    _ => Binding.DoNothing,
                };
            }
            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
