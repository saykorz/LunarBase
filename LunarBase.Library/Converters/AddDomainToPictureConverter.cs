using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LunarBase.Library.Converters
{
    public class AddDomainToPictureConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = string.Empty;
            if (value != null)
            {
                if (!value.ToString().StartsWith("http"))
                {
                    return AppCache.ApplicationDomain + value;
                }
                return value;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            if (parameter == null)
            {
                if (value != null && (Visibility)value == Visibility.Visible)
                    result = true;
            }
            else if (parameter.ToString() == "Inverse")
            {
                if (value != null && (Visibility)value == Visibility.Visible)
                    result = false;
            }
            return result;
        }

        #endregion
    }
}
