using NoteTakingApp_IT_Module_Project.Data;
using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.Views
{
    public partial class ClosingNoteWarningView : Window
    {
        public List<TagModel> tagStoring;
        public ClosingNoteWarningView()
        {
            InitializeComponent();

            //handles the buttons
            CloseWithSave.AddHandler(Button.ClickEvent, new RoutedEventHandler(CloseWithSave_Click));
            CloseWithoutSave.AddHandler(Button.ClickEvent, new RoutedEventHandler(CloseWithoutSave_Click));
            CancelClose.AddHandler(Button.ClickEvent, new RoutedEventHandler(CancelClose_Click));

            //makes window draggable
            Mouse.AddMouseDownHandler(this, Window_MouseDown);
            NoteData noteData = new NoteData();


            //this only updates each app reset
            foreach (TagModel tagModel in noteData.GetAllTags())
            {
                List<NoteModel> listForCheck = null;
                listForCheck = noteData.GetNotesForTag(tagModel.ID);
                if (listForCheck.Count == 0)
                {
                    noteData.DeleteTag(tagModel.ID);
                }
            }
        }
        #region Button handlers

        /// <summary>
        /// Handles saving changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWithSave_Click(object sender, RoutedEventArgs e)
        {
            NoteModel note = AddAndEditNoteViewModel.EditingDataContext;

            NoteContentModel noteContents = new NoteContentModel();
            noteContents.TextContent = AddAndEditNoteView.thisInstance.noteTextBox.Text;
            //noteContents.MusicContent = to be added in the future     

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
            AddAndEditNoteViewModel.EditingDataContext = null;
            this.Close();
            AddAndEditNoteView.thisInstance.Close();
        }

        /// <summary>
        /// Handled cancelation of closing the opened note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes note without saving changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWithoutSave_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext = null;
            this.Close();
            AddAndEditNoteView.thisInstance.Close();
        }
        #endregion

        /// <summary>
        /// Handles dragging of window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
       
    }
}
