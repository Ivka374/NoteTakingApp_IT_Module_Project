using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NoteTakingApp_UI.Models;
using NoteTakingApp_UI.ViewModels;

namespace NoteTakingApp_IT_Module_Project.Views
{
    /// <summary>
    /// Interaction logic for AddAndEditNoteView.xaml
    /// </summary>
    public partial class AddAndEditNoteView : Window
    {
        public AddAndEditNoteView()
        {
            InitializeComponent();
            deleteMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(deleteMenuItem_Click)); //delete button now has onclick event
            changeColourMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(changeColourMenuItem_Click)); //change color now has onclick event
            addScoreMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(addScoreMenuItem_Click)); //add score now has onclick event
            this.PreviewKeyDown += new KeyEventHandler(AddAndEditNoteView_PreviewKeyDown); // window now detects keyboard input
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //not necessary
        }
        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            noteTextBox.Text = ""; //deletes written note text
        }
        private void changeColourMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //should this be a different window or should it cycle through predermined colors on click?
        }
        private void addScoreMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //ill need help with this i have no idea what it would look like on screen lol
        }
        private void AddAndEditNoteView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //REMEMBER TO ADD A CHECK FOR TITLE AS WELL WHEN ITS IMPLEMENTED!!!
            //REMEMBER TO ADD A CHECK FOR TITLE AS WELL WHEN ITS IMPLEMENTED!!!
            //REMEMBER TO ADD A CHECK FOR TITLE AS WELL WHEN ITS IMPLEMENTED!!!
            if(noteTextBox.Text == "")
            {
                if (e.Key == Key.Escape)
                {
                    this.Close();
                }
            }
            //saves a new note
            else
            {
                if (e.Key == Key.Escape)
                {
                    
                    NoteModel note = new NoteModel();
                    NoteContentModel noteContents = new NoteContentModel();
                    noteContents.TextContent = noteTextBox.Text;
                    //noteContents.MusicContent = ???;
                    //note.Title = ???;
                    //note.ThemeName = ???;
                    //note.NoteTags = ???;
                    note.Content = noteContents;
                    if(favoriteButton.IsChecked == true)
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
            }
        }
    }
}
