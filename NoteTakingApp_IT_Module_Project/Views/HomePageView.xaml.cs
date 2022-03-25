using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;
using NoteTakingApp_IT_Module_Project.Models;
using System.Windows;
using System.Windows.Controls;

namespace NoteTakingApp_IT_Module_Project.Views
{
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
            AddAndEditNoteViewModel.EditingDataContext = dataObject;
                
            _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
        }
    }
}
