using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteTakingApp_IT_Module_Project.Models
{
    public class NoteModel : INotifyPropertyChanged
    {
        
        public int ID { get; set; }

        //for title
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }
        private NoteContentModel content;

        public NoteContentModel Content
        {
            get { return content; }
            set 
            { 
                content = value;
                NotifyPropertyChanged();
            }
        }
        private bool isFavourite;
        public bool IsFavourite
        {
            get { return isFavourite; }
            set
            {
                isFavourite = value;
                NotifyPropertyChanged();
            }
        }

        private List<TagModel> noteTags;
        public List<TagModel> NoteTags 
        {
            get { return noteTags; }
            set 
            {
                noteTags = value;
                NotifyPropertyChanged();
            }
        }

        private int themeName;
        public int ThemeName
        {
            get { return themeName; }
            set
            { 
                themeName = value; 
                NotifyPropertyChanged();
            }
        }

        public NoteModel()
        {
            NoteTags = new List<TagModel>();
            Content = new NoteContentModel();
        }

        #region Property change handler
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public NoteModel(int id, string title, string content, bool isFav, int themeName)
        {
            Content = new NoteContentModel();
            NoteTags = new List<TagModel>();
            ID = id;
            Title = title;
            Content.TextContent = content;
            IsFavourite = isFav;
            ThemeName = themeName;
        }
      
    }
}
