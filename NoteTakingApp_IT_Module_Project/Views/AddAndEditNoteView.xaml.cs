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
using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;
using NoteTakingApp_IT_Module_Project.Views;
using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;
using Manufaktura.Controls.Model;
using NoteTakingApp_UI.Data;

namespace NoteTakingApp_IT_Module_Project.Views
{
    /// <summary>
    /// Interaction logic for AddAndEditNoteView.xaml
    /// </summary>
    public partial class AddAndEditNoteView : Window
    {
        WindowManager _windowManager;
        public static AddAndEditNoteView thisInstance;

        public AddAndEditNoteView()
        {
            InitializeComponent();
            deleteMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(deleteMenuItem_Click)); //delete button now has onclick event
            changeColourMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(changeColourMenuItem_Click)); //change color now has onclick event
            addStaffMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(addStaffeMenuItem_Click)); //add score now has onclick event
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
            if(HomePageView.editing == true)
            {
            NoteData noteData = new NoteData();
            //noteData.DeleteNote(editingDataContext.ID);       deletes current opened note on the databse
            HomePageView.editing = false;
            }
            AddAndEditNoteViewModel.
            this.Close();
        }
        private void changeColourMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //waiting on window
        }
        private void addStaffeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Score score = new Score();  //seriously i have no idea what to do
        }
        private void AddAndEditNoteView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                thisInstance = this;
                _windowManager.ShowDialogAsync(new ClosingNoteWarningViewModel());
            }
        }
    }
}
