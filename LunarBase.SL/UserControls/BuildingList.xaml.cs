using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LunarBase.Library.GameService;

namespace LunarBase.SL.UserControls
{
    public partial class BuildingList : UserControl
    {
        public string Title { get; set; }
        public event SelectionChangedEventHandler SelectionChanged;

        public BuildingList()
        {
            InitializeComponent();
            this.Loaded += BuildingList_Loaded;
        }

        void BuildingList_Loaded(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = this.Title;
        }

        private void pnlBuildings_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(sender, e);
            }
        }

        private void pnlBuildings_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //if (e.NewValue is BuildingInCity)
            //{
            //    pnl
            //    (sender as ListBox).ItemsSource = (e.NewValue as BuildingInCity).Building
            //}
        }
    }

}
