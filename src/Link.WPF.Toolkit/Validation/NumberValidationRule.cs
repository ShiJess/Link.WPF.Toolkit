using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Link.WPF.Toolkit.Validation
{
    /// <summary>
    /// Is Number Validate
    /// </summary>
    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Number Should Not Be Null.");

            if (Double.TryParse(value.ToString(), out double num_value))
            {
                return new ValidationResult(true, null);
                //return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Value Is Not Number.");
            }
        }
    }
}
