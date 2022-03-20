using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;
using NoteTakingApp_IT_Module_Project.Views;

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
        public static bool editing;

        WindowManager _windowManager = new WindowManager();
        public HomePageView()
        {
            InitializeComponent();
        }
        private void Note_Click(object sender, RoutedEventArgs e)
        {
            Button clickedNote = sender as Button;
            var dataObject = clickedNote.DataContext as NoteModel;
            editing = true;
            AddAndEditNoteView.editingDataContext = dataObject;
            _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
        }
    }
}
