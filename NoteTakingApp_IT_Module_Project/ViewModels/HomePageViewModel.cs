using Caliburn.Micro;

using NoteTakingApp_IT_Module_Project.Data;
using NoteTakingApp_IT_Module_Project.Models;
using System.Collections.Generic;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class HomePageViewModel : Screen
    {
        private List<NoteModel> _allNotes;
        private NoteData _noteData;
        public HomePageViewModel()
        {
             _noteData = new NoteData();
        }

        /// <summary>
        /// Meant to hook into database to get all the notes
        /// </summary>
        public List<NoteModel> AllNotes 
        { 
            get { return _noteData.GetAllNotes(); }
            set { _allNotes = value; }
        }
     
    }
}
