using System.Linq;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using LunarBase.Library;

namespace LunarBase.SL
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            //this.webLunarMap.ScriptNotify += webLunarMap_ScriptNotify;
            this.radExpander.Expanded += radExpander_Expanded;
            this.radExpander.Collapsed += radExpander_Collapsed;
            ResizeSilverlightOnject(25);
        }

        void radExpander_Collapsed(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ResizeSilverlightOnject(25);
        }

        void radExpander_Expanded(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ResizeSilverlightOnject(pnlCity.Height);
        }

        //void webLunarMap_ScriptNotify(object sender, NotifyEventArgs e)
        //{
        //}

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            AppCache.ApplicationViewModel.IsBusyPool.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(IsBusyDict_CollectionChanged);
        }

        private void ResizeSilverlightOnject(double height)
        {
            HtmlPage.Window.Invoke("ResizeObject", new object[] { height });
        }

        void IsBusyDict_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (AppCache.ApplicationViewModel.IsBusyPool.Count == 0)
                AppCache.ApplicationViewModel.IsBusy = false;
            else
            {
                AppCache.ApplicationViewModel.IsBusyMessage = AppCache.ApplicationViewModel.IsBusyPool.First();
                AppCache.ApplicationViewModel.IsBusy = true;
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            pnlAdmin.Visibility = Visibility.Visible;
            pnlChooseRase.Visibility = System.Windows.Visibility.Collapsed;
            pnlCityView.Visibility = Visibility.Collapsed;
        }
    }
}