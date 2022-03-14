using NoteTakingApp_UI.Models;
using NoteTakingApp_UI.ViewModels;
using System.Windows;

namespace NoteTakingApp_UI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        bool isMaximized = false;
        public ShellView()
        {
            InitializeComponent();
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
            //this.Close() wont work for the life of me this needs research
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
    }
}