using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Window
    {
        public static NoteModel EditingDataContext { get; set; }          // this is the var for the note that was open to be edited

        public AddAndEditNoteViewModel()
        {

        }
        
        public void AddTagToNote()
        {
            //should be reassigned after the menu
        }

    }
}
