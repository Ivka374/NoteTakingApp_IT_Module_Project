using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;
using NoteTakingApp_IT_Module_Project.Models;
using System.Windows;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public static ShellViewModel homeWindow;
        WindowManager _windowManager;
        private BindableCollection<TagModel> tags;
        public BindableCollection<TagModel> Tags { 
            get 
            {
                return tags;
            }
            set 
            {
                this.tags = value;
            } 
        }

        private TagModel selectedTag;

        public TagModel SelectedTag
        {
            get { return selectedTag; }
            set 
            { 
                selectedTag = value;
                NotifyOfPropertyChange(() => SelectedTag);
            }
        }


        public ShellViewModel()
        {
            //simulating content of tags - probably make them default
            Tags = new BindableCollection<TagModel>();
            Tags.Add(new TagModel { Name = "Personal" });
            Tags.Add(new TagModel { Name = "Work" });

            LoadHomePage();

            _windowManager = new WindowManager();
            homeWindow = this;
        }
        public void LoadHomePage()
        {
            ActivateItemAsync(new HomePageViewModel());
        }
        public void LoadFavouritesPage()
        {
            ActivateItemAsync(new FavouritesPageViewModel());
        }
        public void LoadTagPage()
        {
            ActivateItemAsync(new TagPageViewModel());
        }

        public void CreateNote() => _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
    }
}