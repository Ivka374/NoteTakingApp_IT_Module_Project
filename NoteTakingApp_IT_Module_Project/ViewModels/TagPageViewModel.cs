using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class TagPageViewModel : Screen
    {
        private BindableCollection<NoteModel> selectedTagCollection;

        public string SelectedTagName
        {
            get
            {
                return ShellViewModel.homeWindow.SelectedTag.Name; //if this isnt what u wanted then just msg me on discord
            }
        }
        public BindableCollection<NoteModel> SelectedTagCollection
        {
            get { return selectedTagCollection; }
            set { selectedTagCollection = value; }
        }
    }
}
