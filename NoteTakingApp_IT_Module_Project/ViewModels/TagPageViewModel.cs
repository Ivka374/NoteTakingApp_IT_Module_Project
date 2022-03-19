using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    class TagPageViewModel
    {
        private BindableCollection<NoteModel> selectedTagCollection;
        public string SelectedTagName { get; set; }

        public BindableCollection<NoteModel> SelectedTagCollection
        {
            get { return selectedTagCollection; }
            set { selectedTagCollection = value; }
        }

        public TagPageViewModel()
        {

        }
        public TagPageViewModel(string name)
        {
            SelectedTagName = name;
        }

    }
}
