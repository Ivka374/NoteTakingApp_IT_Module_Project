using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;
using NoteTakingApp_UI.Models;
using System.Windows;
using System.Windows.Input;

namespace NoteTakingApp_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        WindowManager _windowManager;
        public BindableCollection<TagModel> Tags { get; set; }

        public ShellViewModel()
        {
            //simulating content of tags - probably make them default
            Tags = new BindableCollection<TagModel>();
            Tags.Add(new TagModel { Name = "Personal" });
            Tags.Add(new TagModel { Name = "Work" });

            _windowManager = new WindowManager();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
                
        }
        private void Close()
        {
            
        }

        public void LoadHomePage()
        {
            ActivateItemAsync(new HomePageViewModel());
        }
        public void LoadFavouritesPage()
        {
            ActivateItemAsync(new FavouritesPageViewModel());
        }
        public void CreateNote() => _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
    }
}