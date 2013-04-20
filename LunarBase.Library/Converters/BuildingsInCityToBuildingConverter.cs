using System;
using System.Linq;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using LunarBase.Library.GameService;

namespace LunarBase.Library.Converters
{
    public class BuildingsInCityToBuildingConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Building)
                return value;

            var result = new Building();
            if (value != null && value is BuildingInCity)
            {
                result = (value as BuildingInCity).Building;
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
