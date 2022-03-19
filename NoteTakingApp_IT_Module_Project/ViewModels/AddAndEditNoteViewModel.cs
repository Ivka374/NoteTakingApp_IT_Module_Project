using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Window
    {
        private NoteModel openNote;

        public NoteModel OpenNote
        {
            get { return openNote; }
            set { openNote = value; }
        }


        public void AddTagToNote()
        {
            //shoukd be reassigned after the menu
        }


    }
}
