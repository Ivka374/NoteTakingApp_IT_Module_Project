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
using NoteTakingApp_UI.Views;
using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;
using Manufaktura.Controls.Model;

namespace NoteTakingApp_IT_Module_Project.Views
{
    /// <summary>
    /// Interaction logic for AddAndEditNoteView.xaml
    /// </summary>
    public partial class AddAndEditNoteView : Window
    {
        WindowManager _windowManager;
        public static AddAndEditNoteView thisInstance;    //i have no idea if this is right or wrong, if ur concerned
                                                          //about it please check references and correct
        public AddAndEditNoteView()
        {
            InitializeComponent();
            deleteMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(deleteMenuItem_Click)); //delete button now has onclick event
            changeColourMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(changeColourMenuItem_Click)); //change color now has onclick event
            addScoreMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(addScoreMenuItem_Click)); //add score now has onclick event
            Mouse.AddMouseDownHandler(this, Window_MouseDown); //window now has mouseDown event check
            this.PreviewKeyDown += new KeyEventHandler(AddAndEditNoteView_PreviewKeyDown); // window now detects mouseDown event
            _windowManager = new WindowManager();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
        private void changeColourMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //waiting on window
        }
        private void addScoreMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Score score = new Score();  //seriously i have no idea what to do
        }
        private void AddAndEditNoteView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                thisInstance = this;
                _windowManager.ShowDialogAsync(new ClosingNoteWarningViewModel()); // no longer gives error big yay!
            }
        }
    }
}
