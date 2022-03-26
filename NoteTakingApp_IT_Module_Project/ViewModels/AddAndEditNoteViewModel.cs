using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using System;
using System.ComponentModel;
namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Screen
    {

        private static NoteModel editingDataContext;

        // this is the property for the note that was open to be edited
        public static NoteModel EditingDataContext 
        {
            get { return editingDataContext; }
            set 
            { 
                editingDataContext = value;
            }
        }
    }
}
