using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Link.WPF.Toolkit.Converter
{
    /// <summary>
    /// Number Zero or Null To Boolean/Visibility Converter
    /// </summary>
    public class NullZeroNumberToBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null

                || (value is Int32 intvalue && intvalue == 0)
                || (value is UInt32 uintvalue && uintvalue == 0)

                || (value is long longvalue && longvalue == 0)
                || (value is ulong ulongvalue && ulongvalue == 0)

                || (value is short shortvalue && shortvalue == 0)
                || (value is ushort ushortvalue && ushortvalue == 0)

                || (value is double d_value && d_value == 0.0)
                || (value is decimal de_value && de_value == decimal.Zero)
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
            throw new NotSupportedException("Not Support Convert Back To Number");
        }

    }
}
