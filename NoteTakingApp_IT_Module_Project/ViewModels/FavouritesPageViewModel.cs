using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.ViewModels
{
    public class FavouritesPageViewModel : Conductor<object>
    {
        List<NoteModel> FavouriteNotes = new List<NoteModel>();

    }
}
