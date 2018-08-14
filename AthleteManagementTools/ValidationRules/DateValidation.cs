using System;
using System.Globalization;
using System.Windows.Controls;

namespace AthleteManagementTools.ValidationRules
{
    public class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            DateTime time;
            if (value != null && DateTime.TryParseExact(value.ToString(), "mm:ss.f", cultureInfo, DateTimeStyles.None, out time))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Please enter a valid string value.");
        }
    }
}