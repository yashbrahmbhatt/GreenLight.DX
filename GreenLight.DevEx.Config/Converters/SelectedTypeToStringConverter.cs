﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace GreenLight.DX.Converters
{
    public class SelectedTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

                return ((Type)value).FullName; // Or use another property of Type, like Name

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var supportedTypes = (IEnumerable<Type>)parameter;
            var typeName = (Type)value;

            return value;

        }
    }
}