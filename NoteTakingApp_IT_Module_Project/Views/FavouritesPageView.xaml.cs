using Caliburn.Micro;

using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;

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
        public static bool editing;

        WindowManager _windowManager = new WindowManager();
        public FavouritesPageView()
        {
            InitializeComponent();
        }

        private void Note_Click(object sender, RoutedEventArgs e)
        {
            Button clickedNote = sender as Button;
            var dataObject = clickedNote.DataContext as NoteModel;
            editing = true;
            AddAndEditNoteViewModel.EditingDataContext = dataObject;
            _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
        }
    }
}
