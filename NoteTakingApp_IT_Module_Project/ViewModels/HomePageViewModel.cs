using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.ViewModels
{
    public class HomePageViewModel : Conductor<object>
    {
        private List<NoteModel> _allNotes = new List<NoteModel>();
        public List<NoteModel> AllNotes 
        { 
            get { return _allNotes; }
            set { _allNotes = value; }
        }
        //maybe connect to full notes database here?
    }
}
