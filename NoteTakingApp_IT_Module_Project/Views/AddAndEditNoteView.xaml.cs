using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NoteTakingApp_IT_Module_Project.ViewModels;
using Caliburn.Micro;
using Manufaktura.Controls.Model;
using NoteTakingApp_IT_Module_Project.Data;
using System.Text.RegularExpressions;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.Views
{
    public partial class AddAndEditNoteView : Window
    {
        #region Basics
        WindowManager _windowManager;
        public static AddAndEditNoteView thisInstance;

        public AddAndEditNoteView()
        {
            InitializeComponent();

            //handles context menu
            deleteMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(deleteMenuItem_Click));
            addScoreMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(addScoreeMenuItem_Click));
            tagCreateMenuItem.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(tagCreateMenuItem_Click));

            //makes window draggable
            Mouse.AddMouseDownHandler(this, Window_MouseDown);
            this.PreviewKeyDown += new KeyEventHandler(AddAndEditNoteView_PreviewKeyDown);

            //all colors now have onclick events
            AddingHandlersToColors();

            _windowManager = new WindowManager();
        }

        //handles window dragging
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        #endregion

        #region Context menu events

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (HomePageView.editing == true)
            {
                NoteData noteData = new NoteData();
                noteData.DeleteNote(AddAndEditNoteViewModel.EditingDataContext.ID);
                HomePageView.editing = false;
            }
            AddAndEditNoteViewModel.EditingDataContext = null;
            this.Close();
        }
        private void addScoreeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //this will open a seperate window that is linked to the MusicContent property of the current note
        }
        private void AddAndEditNoteView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                thisInstance = this;
                _windowManager.ShowDialogAsync(new ClosingNoteWarningViewModel());
            }
        }

        #endregion

        #region Changing note colour

        //will add a listener or sth

        private void Color0_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 0;
        }
        private void Color1_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 1;
        }
        private void Color2_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 2;
        }
        private void Color3_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 3;
        }
        private void Color4_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 4;
        }
        private void Color5_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 5;
        }

        private void AddingHandlersToColors()
        {
            color0.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Color0_Click));
            color1.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Color1_Click));
            color2.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Color2_Click));
            color3.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Color3_Click));
            color4.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Color4_Click));
            color5.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(Color5_Click));
        }

        #endregion

        #region Manageing tags

        //attempts to add a tag to a note
        private void tagCreateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(tagTextBox.Text))
            {
                MessageBox.Show("You may not use special characters in your tags.", "Cannot create tag!", MessageBoxButton.OK, MessageBoxImage.Error);
                tagTextBox.Text = "Create New Tag";
            }
            else
            {
                //gives error :/
                TagModel newTag = new TagModel() { Name = tagTextBox.Text };
                AddAndEditNoteViewModel.EditingDataContext.NoteTags.Add(newTag);
            }
        }
        #endregion
    }
}
