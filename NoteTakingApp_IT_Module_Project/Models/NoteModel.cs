using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteTakingApp_IT_Module_Project.Models
{
    public class NoteModel : INotifyPropertyChanged
    {
        
        public int ID { get; set; }
        public string Title { get; set; }
        public NoteContentModel Content { get; set; }
        public List<TagModel> NoteTags { get; set; }
        public bool IsFavourite { get; set; }
        private int themeName;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int ThemeName
        {
            get { return themeName; }
            set { themeName = value; NotifyPropertyChanged(); }
        }
        public NoteModel()
        {
            NoteTags = new List<TagModel>();
        }
        public NoteModel(int id, string title, string content, bool isFav, int themeName)
        {
            NoteTags = new List<TagModel>();
            ID = id;
            Title = title;
            Content.TextContent = content;
            IsFavourite = isFav;
            ThemeName = themeName;
        }
      
    }
}
