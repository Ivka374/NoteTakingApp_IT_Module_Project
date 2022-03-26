using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace NoteTakingApp_IT_Module_Project.Views
{

    public partial class TagPageView : UserControl
    {
        WindowManager _windowManager = new WindowManager();

        public TagPageView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Meant to open selected note on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Note_Click(object sender, RoutedEventArgs e)
        {
            Button clickedNote = sender as Button;
            var dataObject = clickedNote.DataContext as NoteModel;
            AddAndEditNoteViewModel.EditingDataContext = dataObject;
            HomePageView.editing = true;
            _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
        }
    }
}
