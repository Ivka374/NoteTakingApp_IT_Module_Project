using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Data;
using NoteTakingApp_IT_Module_Project.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class HomePageViewModel : Screen, INotifyPropertyChanged
    {
        private List<NoteModel> _allNotes;
        private NoteData _noteData;
        #region Property change handler
        public override event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
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
            set { _allNotes = value; NotifyPropertyChanged(); }
        }
     
    }
}
