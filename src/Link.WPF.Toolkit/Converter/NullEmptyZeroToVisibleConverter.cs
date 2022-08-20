using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Link.WPF.Toolkit.Converter
{
    /// <summary>
    /// null/空/0 值 转换Visible
    /// </summary>
    public class NullEmptyZeroToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null
                || string.IsNullOrWhiteSpace(value.ToString())
                || value.ToString() == "0"
                || value.ToString() == "0.0")
            {
                if (parameter is Visibility
                    && (Visibility)parameter == Visibility.Collapsed)
                    return Visibility.Collapsed;

                return Visibility.Hidden;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
