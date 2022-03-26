using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        WindowManager _windowManager;

        #region Tag management

        private static BindableCollection<TagModel> tags;

        /// <summary>
        /// A collection of all available tags; meant to hook into database
        /// </summary>
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

        /// <summary>
        /// Refers to the selected tag within the comboBox in the left-side menu
        /// </summary>
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

        /// <summary>
        /// Loads HomePageView user control
        /// </summary>
        public void LoadHomePage()
        {
            ActivateItemAsync(new HomePageViewModel());
        }

        /// <summary>
        /// Loads FavouritesPageView user control
        /// </summary>
        public void LoadFavouritesPage()
        {
            ActivateItemAsync(new FavouritesPageViewModel());
        }

        /// <summary>
        /// Loads TagPageView user control
        /// </summary>
        public void LoadTagPage()
        {
            ActivateItemAsync(new TagPageViewModel());
        }
        #endregion

        /// <summary>
        /// Opens a blank/default note
        /// </summary>
        public void CreateNote() 
        {
            NoteModel newNote = new NoteModel();
            AddAndEditNoteViewModel.EditingDataContext = newNote;

            _windowManager.ShowDialogAsync(new AddAndEditNoteViewModel());
        }
        
    }
}