using NoteTakingApp_UI.Models;
using NoteTakingApp_UI.ViewModels;
using System.Windows;
using System.Diagnostics;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;

namespace NoteTakingApp_UI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        WindowManager windowManager;
        bool isMaximized = false;
        public ShellView()
        {
            InitializeComponent();
            Close.AddHandler(Button.ClickEvent, new RoutedEventHandler(Close_Click)); //this has to be here for some reason, just leave it be
            CreateNote.AddHandler(Button.ClickEvent, new RoutedEventHandler(CreateNote_Click)); //this has to be here for some reason, just leave it be
            //continuing music example
        }

        private void AddNote()
        {
            NoteModel note = new NoteModel(); 
            
            //needs more tweaks for the input
            //will add the note to the database of notes
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            this.DragMove();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximized == false)
            {
                MainWindow.WindowState = WindowState.Maximized;
                isMaximized = true;
            }
            else
            {
                MainWindow.WindowState = WindowState.Normal;
                isMaximized = false;
            }
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.WindowState = WindowState.Minimized;
        }
        private void CreateNote_Click(object sender, RoutedEventArgs e)
        {
            windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
        }
    }
}