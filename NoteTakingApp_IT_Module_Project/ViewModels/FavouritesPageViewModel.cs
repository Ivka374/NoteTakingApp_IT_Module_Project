using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.ViewModels
{
    public class FavouritesPageViewModel : Conductor<object>
    {
        private List<NoteModel> _favouriteNotes = new List<NoteModel>();
        public List<NoteModel> FavouriteNotes
        {
            get { return _favouriteNotes; }
            set { _favouriteNotes = value; }
        }
    }
}
