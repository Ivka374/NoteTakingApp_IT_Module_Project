﻿using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Screen
    {

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        private static NoteModel editingDataContext;

        public static NoteModel EditingDataContext // this is the var for the note that was open to be edited
        {
            get { return editingDataContext; }
            set 
            { 
                editingDataContext = value;
                NotifyStaticPropertyChanged(nameof(EditingDataContext.ThemeName));
            }
        }

        public AddAndEditNoteViewModel()
        {

        }
        
        public void AddTagToNote()
        {
            //should be reassigned after the menu
        }

    }
}
