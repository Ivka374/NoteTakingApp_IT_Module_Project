using NoteTakingApp_UI.Models;
using NoteTakingApp_UI.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace NoteTakingApp_UI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            //continuing music example
        }

        private void AddNote()
        {
            NoteModel note = new NoteModel(); //needs more tweaks for the input
            //will add the note to the database of notes
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}