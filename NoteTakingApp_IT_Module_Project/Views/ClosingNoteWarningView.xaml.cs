using NoteTakingApp_IT_Module_Project.Data;
using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteTakingApp_IT_Module_Project.Views
{
    /// <summary>
    /// Interaction logic for ClosingNoteWarning.xaml
    /// </summary>
    public partial class ClosingNoteWarningView : Window
    {
        public ClosingNoteWarningView()
        {
            InitializeComponent();
            CloseWithSave.AddHandler(Button.ClickEvent, new RoutedEventHandler(CloseWithSave_Click)); //save button now has onclick event
            CloseWithoutSave.AddHandler(Button.ClickEvent, new RoutedEventHandler(CloseWithoutSave_Click)); //not save button now has onclick event
            CancelClose.AddHandler(Button.ClickEvent, new RoutedEventHandler(CancelClose_Click)); //cancel button now has onclick event
            Mouse.AddMouseDownHandler(this, Window_MouseDown); //window now has mouseDown event check
        }
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
            if (AddAndEditNoteView.thisInstance.favoriteButton.IsChecked == true)
            {
                note.IsFavourite = true;
            }
            else
            {
                note.IsFavourite = false;
            }
            if(HomePageView.editing == true)
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
            AddAndEditNoteViewModel.EditingDataContext = null;
            this.Close();
            AddAndEditNoteView.thisInstance.Close();
        }
        private void CloseWithoutSave_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext = null;
            this.Close();
            AddAndEditNoteView.thisInstance.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CancelClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
