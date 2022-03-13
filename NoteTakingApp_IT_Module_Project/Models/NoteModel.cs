using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.Models
{
    public class NoteModel
    {
        public string Title { get; set; }
        public NoteContentModel Content { get; set; }
        public List<TagModel> NoteTags { get; set; }
        public bool IsFavourite { get; set; }
        public string ThemeName { get; set; }
    }
}
