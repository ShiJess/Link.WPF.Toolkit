using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Link.WPF.Toolkit.Converter
{
    /// <summary>
    /// Greater than judgment
    /// </summary>
    //[ValueConversion(typeof(int), typeof(bool), ParameterType = typeof(int))]
    //[ValueConversion(typeof(double), typeof(bool), ParameterType = typeof(double))]
    public class IsGreaterThanAndEqualToConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            double num_value;
            double num_param;

            if (Double.TryParse(value.ToString(), out num_value)) { }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Double.TryParse(parameter.ToString(), out num_param)) { }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return num_value >= num_param;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
