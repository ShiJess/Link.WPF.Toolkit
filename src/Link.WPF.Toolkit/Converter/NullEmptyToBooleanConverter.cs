using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Link.WPF.Toolkit.Converter
{
    /// <summary>
    /// Common Type Null/Empty To Boolean
    /// Null,EmptyList,EmptyString,ZeroNumber To Boolean/Visibility
    /// </summary>
    public class NullEmptyToBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null
                || (value is string s_value && (string.IsNullOrWhiteSpace(s_value) || s_value == "0" || s_value == "0.0"))
                || (value is char c_value && (c_value == ' ' || c_value == '0'))
                || (value is ICollection collection && collection.Count <= 0)
                || (value is Int32 intvalue && intvalue == 0)
                || (value is double d_value && d_value == 0.0)
                )
            {
                if (targetType == typeof(Visibility))
                {
                    if (parameter is Visibility)
                        return (Visibility)parameter;
                    return Visibility.Collapsed;
                }
                else
                {
                    if (parameter is Boolean)
                        return (bool)parameter;
                    return false;
                }
            }
            else
            {
                if (targetType == typeof(Visibility))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return true;
                }
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }
}
