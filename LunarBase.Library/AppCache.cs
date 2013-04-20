using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LunarBase.Library
{
    public static class AppCache
    {
        private static string _applicationDomain = string.Empty;
        public static string ApplicationDomain
        {
            get { return _applicationDomain; }
            set
            {
                if(string.IsNullOrEmpty(_applicationDomain))
                    _applicationDomain = value;
            }
        }

        public static ApplicationViewModel ApplicationViewModel { get; set; }

        static AppCache()
        {
            ApplicationViewModel = new ApplicationViewModel();
        }
    }
}
