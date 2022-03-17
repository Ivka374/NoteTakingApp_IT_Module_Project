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
            CloseWithSave.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(CloseWithSave_Click)); //save button now has onclick event
            CloseWithoutSave.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(CloseWithoutSave_Click)); //not save button now has onclick event
        }
        private void CloseWithSave_Click(object sender, RoutedEventArgs e)
        {
            NoteModel note = new NoteModel();
            NoteContentModel noteContents = new NoteContentModel();
            noteContents.TextContent = AddAndEditNoteView.thisInstance.noteTextBox.ToString();
            //noteContents.MusicContent = ???;
            //note.Title = ???;
            //note.ThemeName = ???;
            //note.NoteTags = ???;
            note.Content = noteContents;
            if (AddAndEditNoteView.thisInstance.favoriteButton.IsChecked == true)
            {
                note.IsFavourite = true;
            }
            else
            {
                note.IsFavourite = false;
            }
            //how to add this to the HomePageViewModel list var? shit man this aint nothing like unity ;-;
            this.Close();

        }
        private void CloseWithoutSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddAndEditNoteView.thisInstance.Close();
        }
    }
}
