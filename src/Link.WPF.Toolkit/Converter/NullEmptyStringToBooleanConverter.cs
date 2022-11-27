using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Link.WPF.Toolkit.Converter
{
    /// <summary>
    /// Empty,WhiteSpace or Null String to Boolean or Visibility Converter
    /// </summary>
    [ValueConversion(typeof(string), typeof(bool), ParameterType = typeof(bool))]
    [ValueConversion(typeof(string), typeof(Visibility), ParameterType = typeof(Visibility))]
    public class NullEmptyStringToBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
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
            throw new NotSupportedException("Not Support Convert Back To String");
        }

    }
}
