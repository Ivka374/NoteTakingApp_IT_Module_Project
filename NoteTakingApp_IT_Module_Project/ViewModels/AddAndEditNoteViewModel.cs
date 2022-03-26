using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Screen
    {
        private static NoteModel editingDataContext;
        public static NoteModel EditingDataContext // this is the var for the note that was open to be edited
        {
            set { editingDataContext = value; }
            get { return editingDataContext; }
        }

        public AddAndEditNoteViewModel()
        {

        }
    }
}
