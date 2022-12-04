using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Link.WPF.Toolkit.Validation
{
    /// <summary>
    /// also means NotEmpty Rule
    /// </summary>
    public class RequiredValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Should Not Be Null.");

            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "String Value Can Not Be Empty String.");

            //return ValidationResult.ValidResult;
            return new ValidationResult(true, null);
        }
    }
}
