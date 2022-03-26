using System.Collections.Generic;

namespace NoteTakingApp_IT_Module_Project.Models
{
    public class NoteModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public NoteContentModel Content { get; set; }
        public List<TagModel> NoteTags { get; set; }
        public bool IsFavourite { get; set; }
        public int ThemeName { get; set; }
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
