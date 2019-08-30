using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Link.WPF.Toolkit.Converter
{
    /// <summary>
    /// Enum Convert to DisplayAttribute.Name
    /// </summary>
    /// <remarks>
    /// Use System.ComponentModel.DataAnnotations.DisplayAttribute
    /// Not System.ComponentModel.DisplayNameAttribute
    /// </remarks>
    public class EnumToDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            Type type = value.GetType();
            MemberInfo[] memInfo = type.GetMember(value.ToString()); if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((System.ComponentModel.DataAnnotations.DisplayAttribute)attrs[0]).Name;
            }
            //return value.ToString();
            
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return value;
        }
    }
}
