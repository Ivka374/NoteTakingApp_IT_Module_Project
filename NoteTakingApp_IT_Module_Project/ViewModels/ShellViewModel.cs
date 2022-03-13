using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System.Windows;

namespace NoteTakingApp_UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        //private BindableCollection<TagModel> _tags = new BindableCollection<TagModel>();

        //public BindableCollection<TagModel> Tags
        //{
        //    get { return _tags; }
        //    set
        //    {
        //        _tags = value;
        //    }
        //}

        public BindableCollection<TagModel> Tags { get; set; }

        public ShellViewModel()
        {
            //simulating content of tags - probably make them default
            Tags = new BindableCollection<TagModel>();
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