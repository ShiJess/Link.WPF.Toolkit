using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Link.WPF.Toolkit.Converter
{
    /// <summary>
    /// Empty or Null List to Boolean or Visibility Converter
    /// </summary>
    public class NullEmptyListToBooleanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
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

            if (value is ICollection collection)
            {
                if (collection.Count <= 0)
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

            if (targetType == typeof(Visibility))
            {
                return Visibility.Visible;
            }
            else
            {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Not Support Convert Back To List");
        }

    }
}
