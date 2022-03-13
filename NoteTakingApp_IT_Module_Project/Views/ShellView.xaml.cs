using NoteTakingApp_UI.Models;
using System.Windows;

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
        }

        private void AddNote()
        {
            NoteModel note = new NoteModel(); //needs more tweaks for the input
            //will add the note to the database of notes
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}