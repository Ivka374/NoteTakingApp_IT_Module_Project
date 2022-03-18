using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.ViewModels
{
    public class FavouritesPageViewModel : Conductor<object>
    {
        private BindableCollection<NoteModel> _favouriteNotes;

        public FavouritesPageViewModel()
        {
            _favouriteNotes = new BindableCollection<NoteModel>();

            _favouriteNotes.Add(new NoteModel()
            {
                Title = "FavouriteExperimentView1",
                IsFavourite = true,
                Content = new NoteContentModel() { TextContent = "Does this display properly?" },
                ThemeName = "2"
            });
            _favouriteNotes.Add(new NoteModel()
            {
                Title = "FavouriteExperimentView2",
                IsFavourite = true,
                Content = new NoteContentModel() { TextContent = "Does this display properly or no?" },
                ThemeName = "2"
            });
            _favouriteNotes.Add(new NoteModel()
            {
                Title = "FavouriteExperimentView3",
                IsFavourite = true,
                Content = new NoteContentModel() { TextContent = "Does this display properly at last or are the edges a bit off again?" },
                ThemeName = "2"
            });
        }

        public BindableCollection<NoteModel> FavouriteNotes
        {
            get { return _favouriteNotes; }
            set { _favouriteNotes = value; }
        }
    }
}
