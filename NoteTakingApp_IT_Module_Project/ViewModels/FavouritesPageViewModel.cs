using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class FavouritesPageViewModel : Screen
    {
        private BindableCollection<NoteModel> _favouriteNotes;

        public FavouritesPageViewModel()
        {
            _favouriteNotes = new BindableCollection<NoteModel>();

            #region Test data
            _favouriteNotes.Add(new NoteModel()
            {
                Title = "FavouriteExperimentView1",
                IsFavourite = true,
                Content = new NoteContentModel() { TextContent = "Does this display properly?" },
                ThemeName = 1
            });
            _favouriteNotes.Add(new NoteModel()
            {
                Title = "FavouriteExperimentView2",
                IsFavourite = true,
                Content = new NoteContentModel() { TextContent = "Does this display properly or no?" },
                ThemeName = 2
            });
            _favouriteNotes.Add(new NoteModel()
            {
                Title = "FavouriteExperimentView321",
                IsFavourite = true,
                Content = new NoteContentModel() { TextContent = "Does this display properly at last or are the edges a bit off again? Well, yes sweetie but do these expand like they should or are they just going to remain bland and uniform throughot the page? Hmmm?" },
                ThemeName = 3,
                NoteTags = new List<TagModel>() { new TagModel() { Name = "Cool"}, new TagModel() { Name = "Cute"}, new TagModel() { Name = "Funny"} }
            });
            #endregion
        }

        /// <summary>
        /// Meant to hook into databsae by getting only the notes marked as favourite
        /// </summary>
        public BindableCollection<NoteModel> FavouriteNotes
        {
            get { return _favouriteNotes; }
            set { _favouriteNotes = value; }
        }
    }
}
