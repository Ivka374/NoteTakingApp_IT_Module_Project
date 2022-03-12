using Caliburn.Micro;
using NoteTakingApp_UI.Models;


namespace NoteTakingApp_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private BindableCollection<TagModel> _tags = new BindableCollection<TagModel>();

        public BindableCollection<TagModel> Tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
            }
        }

        public ShellViewModel()
        {
            //simulating content of tags - probablu make them default
            Tags.Add(new TagModel { Name = "Personal" });
            Tags.Add(new TagModel { Name = "Work" });
        }

        public void LoadHomePage()
        {
            ActivateItemAsync(new HomePageViewModel());
        }
        public void LoadFavouritesPage()
        {
            ActivateItemAsync(new FavouritesPageViewModel());
        }
    }
}