using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteTakingApp_IT_Module_Project.Views
{
    /// <summary>
    /// Interaction logic for FavouritesView.xaml
    /// </summary>
    public partial class FavouritesPageView : UserControl
    {
        public FavouritesPageView()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //also opens note that was clicked on (maybe the 2 views should be merged if I can figure out how)
        }
    }
}
