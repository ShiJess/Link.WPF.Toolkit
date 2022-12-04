using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Link.WPF.Toolkit.Validation
{
    public sealed class ValidationHelper
    {

        public ValidationResult Validate<T>(object value, CultureInfo cultureInfo) where T : ValidationRule
        {
            return Activator.CreateInstance<T>().Validate(value, cultureInfo);
        }

    }
}
