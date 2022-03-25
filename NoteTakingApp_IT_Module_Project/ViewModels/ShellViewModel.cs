using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
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

        private static TagModel selectedTag;

        public static TagModel SelectedTag
        {
            get { return selectedTag; }
            set 
            { 
                selectedTag = value;
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

        public void CreateNote() 
        {
            NoteModel newNote = new NoteModel();
            AddAndEditNoteViewModel.EditingDataContext = newNote;
            _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel()); 
        }
        
    }
}