using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        WindowManager _windowManager;

        #region Tag management

        private static BindableCollection<TagModel> tags;
        public static BindableCollection<TagModel> Tags
        {
            get
            {
                return tags;
            }
            set
            {
                tags = value;
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
        #endregion


        public ShellViewModel()
        {
            //simulating content of tags
            Tags = new BindableCollection<TagModel>();
            Tags.Add(new TagModel { Name = "Personal" });
            Tags.Add(new TagModel { Name = "Work" });
            Tags.Add(new TagModel { Name = "Cool" });
            Tags.Add(new TagModel { Name = "Cute" });

            LoadHomePage();

            _windowManager = new WindowManager();
        }

        #region Manageing displayed notes

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
        #endregion

        public void CreateNote() 
        {
            NoteModel newNote = new NoteModel();
            AddAndEditNoteViewModel.EditingDataContext = newNote;

            _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
        }
        
    }
}