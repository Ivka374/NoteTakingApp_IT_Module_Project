using Caliburn.Micro;

using NoteTakingApp_IT_Module_Project.ViewModels;

using NoteTakingApp_UI.Models;

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

namespace NoteTakingApp_UI.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomePageView : UserControl
    {
        WindowManager _windowManager = new WindowManager();
        public HomePageView()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //need help :/ idk how to transfer note content over to addandeditnoteview
        }
    }
}
