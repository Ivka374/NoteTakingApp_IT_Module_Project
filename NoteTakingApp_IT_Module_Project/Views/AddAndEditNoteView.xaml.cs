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

    }
}
