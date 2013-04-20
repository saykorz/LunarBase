using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LunarBase.Library.Converters
{
    public class ValueToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = Visibility.Collapsed;
            if (parameter == null)
            {
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    result = Visibility.Visible;
            }
            else if (parameter.ToString() == "Inverse")
            {
                if (value == null)
                    result = Visibility.Visible;
                else
                {
                    if(string.IsNullOrEmpty(value.ToString()))
                        result = Visibility.Visible;
                }
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
