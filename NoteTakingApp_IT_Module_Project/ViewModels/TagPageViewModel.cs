using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using NoteTakingApp_UI.ViewModels;
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
                return "Tag";
                //return new ShellViewModel().SelectedTag.Name; - this is garbage but it gets my idea across
            }
        }


        public BindableCollection<NoteModel> SelectedTagCollection
        {
            get { return selectedTagCollection; }
            set { selectedTagCollection = value; }
        }
    }
}
