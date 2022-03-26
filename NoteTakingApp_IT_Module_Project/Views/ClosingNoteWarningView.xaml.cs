using NoteTakingApp_IT_Module_Project.Data;
using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.Views
{
    public partial class ClosingNoteWarningView : Window
    {
        public ClosingNoteWarningView()
        {
            InitializeComponent();

            //handles the buttons
            CloseWithSave.AddHandler(Button.ClickEvent, new RoutedEventHandler(CloseWithSave_Click));
            CloseWithoutSave.AddHandler(Button.ClickEvent, new RoutedEventHandler(CloseWithoutSave_Click));
            CancelClose.AddHandler(Button.ClickEvent, new RoutedEventHandler(CancelClose_Click));

            //makes window draggable
            Mouse.AddMouseDownHandler(this, Window_MouseDown);
        }

        #region Button handlers

        //hadles saving changes
        private void CloseWithSave_Click(object sender, RoutedEventArgs e)
        {
            NoteModel note = AddAndEditNoteViewModel.EditingDataContext;

            NoteContentModel noteContents = new NoteContentModel();
            noteContents.TextContent = AddAndEditNoteView.thisInstance.noteTextBox.Text;
            //noteContents.MusicContent = ???;     

            note.Title = AddAndEditNoteView.thisInstance.titleTextBox.Text;
            note.ThemeName = AddAndEditNoteViewModel.EditingDataContext.ThemeName;
            note.NoteTags = AddAndEditNoteViewModel.EditingDataContext.NoteTags;

            note.Content = noteContents;

            //check if note is set as favourite
            if (AddAndEditNoteView.thisInstance.favoriteButton.IsChecked == true)
            {
                note.IsFavourite = true;
            }
            else
            {
                note.IsFavourite = false;
            }

            //checks if note has been edited
            if (HomePageView.editing == true)
            {
                NoteData noteData = new NoteData();
                noteData.UpdateNote(note);
                HomePageView.editing = false;
            }
            else
            {
                NoteData noteData = new NoteData();
                noteData.AddNote(note);
            }

            //clears the data context for the view
            AddAndEditNoteViewModel.EditingDataContext.Content = null;
            AddAndEditNoteViewModel.EditingDataContext.NoteTags = null;
            AddAndEditNoteViewModel.EditingDataContext = null;
            this.Close();
            AddAndEditNoteView.thisInstance.Close();
        }

        //handles cancelation of escape
        private void CancelClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //handles closes without saving
        private void CloseWithoutSave_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.Content = null;
            AddAndEditNoteViewModel.EditingDataContext.NoteTags = null;
            AddAndEditNoteViewModel.EditingDataContext = null;
            this.Close();
            AddAndEditNoteView.thisInstance.Close();
        }
        #endregion

        //handles dragging
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
       
    }
}
