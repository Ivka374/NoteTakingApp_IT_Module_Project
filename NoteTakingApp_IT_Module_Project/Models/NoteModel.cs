﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NoteTakingApp_UI.Models
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

        }
        public NoteModel(int id, string title, string content, bool isFav, int themeName)
        {
            ID = id;
            Title = title;
            Content.TextContent = content;
            IsFavourite = isFav;
            ThemeName = themeName;
        }
      
    }
}
