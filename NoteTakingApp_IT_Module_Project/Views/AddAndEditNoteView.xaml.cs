using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NoteTakingApp_IT_Module_Project.ViewModels;
using Caliburn.Micro;
using Manufaktura.Controls.Model;
using NoteTakingApp_IT_Module_Project.Data;
using System.Text.RegularExpressions;
using NoteTakingApp_IT_Module_Project.Models;
using System.Linq;
using System.Collections;

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

        /// <summary>
        /// Handles window dragging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        #endregion

        #region Context menu events

        /// <summary>
        /// Deletes opened note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Will add a music score to the note content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addScoreeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //this will open a seperate window that is linked to the MusicContent property of the current note
        }

        /// <summary>
        /// Opens window to confirm exit and data change actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Sets purple theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color0_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 0;
        }

        /// <summary>
        /// Sets blue theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color1_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 1;
        }

        /// <summary>
        /// Sets yellow theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color2_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 2;
        }

        /// <summary>
        /// Sets dawn theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color3_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 3;
        }

        /// <summary>
        /// Sets aurora borealis theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color4_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 4;
        }

        /// <summary>
        /// Sets pink and blue theme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color5_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditNoteViewModel.EditingDataContext.ThemeName = 5;
        }


        /// <summary>
        /// Handles all the colour changes
        /// </summary>
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

        /// <summary>
        /// Attempts to add a tag to a note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                TagModel newTag = new TagModel() { Name = tagTextBox.Text };
                if (ShellViewModel.Tags.Any(p => p.Name == tagTextBox.Text))
                {
                    MessageBox.Show("You already have a tag with this name.", "Cannot create tag!", MessageBoxButton.OK, MessageBoxImage.Error);
                    tagTextBox.Text = "Create New Tag";
                }
                else
                {
                    ShellViewModel.Tags.Add(newTag);
                    NoteData noteData = new NoteData();
                    noteData.AddTag(newTag);
                    newTag = noteData.GetTagByName(newTag.Name);
                    noteData.AddTagToNote(newTag, AddAndEditNoteViewModel.EditingDataContext);
                    AddAndEditNoteViewModel.EditingDataContext.NoteTags.Add(newTag);
                }
            }
        }
        #endregion
    }
}
