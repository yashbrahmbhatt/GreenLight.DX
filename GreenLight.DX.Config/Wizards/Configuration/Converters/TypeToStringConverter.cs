using GreenLight.DX.Config.Services.Configuration.Models;
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using GreenLight.DX.Config.Wizards.Configuration.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GreenLight.DX.Config.Wizards.Configuration.Converters
{
    public class TypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Type type)
            {
                return FormatTypeName(type);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string typeName && parameter is string rowType)
            {
                if (rowType == "Setting")
                {
                    return new SettingRowViewModel(null, new SettingItemModel(), 1).SupportedTypes.First(t => FormatTypeName(t) == value);
                }
                else if (rowType == "Asset")
                {
                    return new AssetRowViewModel(null, new AssetItemModel(), 1).SupportedTypes.First(t => FormatTypeName(t) == value);
                }
                else if (rowType == "Resource")
                {
                    return new ResourceRowViewModel(null, new ResourceItemModel(), 1).SupportedTypes.First(t => FormatTypeName(t) == value);
                }
            }
            return null;
        }

        private string FormatTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(type.Name.Substring(0, type.Name.IndexOf('`'))); // Name without arity
                sb.Append("<");
                var genericArguments = type.GetGenericArguments();
                for (int i = 0; i < genericArguments.Length; i++)
                {
                    sb.Append(FormatTypeName(genericArguments[i])); // Recursive call
                    if (i < genericArguments.Length - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append(">");
                return sb.ToString();
            }
            else
            {
                return type.FullName; // Or type.Name if you prefer
            }
        }
    }
}