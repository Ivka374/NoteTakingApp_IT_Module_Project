using Caliburn.Micro;

using NoteTakingApp_IT_Module_Project.Data;
using NoteTakingApp_IT_Module_Project.Models;

using System.Collections.Generic;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class TagPageViewModel : Screen
    {
        private static List<NoteModel> selectedTagCollection;
        /// <summary>
        /// The name of the tag, the notes of which are displayed
        /// </summary>
        public static int SelectedTagNameID
        {
            get
            {
                return ShellViewModel.SelectedTag.ID;
            }
        }
        /// <summary>
        /// Meant to hook into database and get all notes of tag with name corresponding to property above
        /// </summary>
        public static List<NoteModel> SelectedTagCollection
        {
            get
            {
                NoteData noteData = new NoteData();
                return noteData.GetNotesForTag(SelectedTagNameID);
            }
            set 
            { 
                selectedTagCollection = value; 
            }
        }
    }
}
