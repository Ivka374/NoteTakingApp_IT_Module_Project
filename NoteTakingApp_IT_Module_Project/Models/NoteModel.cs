using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.Models
{
    public class NoteModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public NoteContentModel Content { get; set; }
        public List<TagModel> NoteTags { get; set; }
        public bool IsFavourite { get; set; }
        public string ThemeName { get; set; }
        public NoteModel()
        {

        }
        public NoteModel(int id, string title, string content, bool isFav, string themeName)
        {
            ID = id;
            Title = title;
            Content.TextContent = content;
            IsFavourite = isFav;
            ThemeName = themeName;
        }
    }
}
