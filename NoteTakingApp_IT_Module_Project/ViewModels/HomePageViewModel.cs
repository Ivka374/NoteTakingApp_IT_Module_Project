using Caliburn.Micro;

using NoteTakingApp_IT_Module_Project.Data;
using NoteTakingApp_IT_Module_Project.Models;
using System.Collections.Generic;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class HomePageViewModel : Screen
    {
        private List<NoteModel> _allNotes;
        private NoteData _noteData;
        public HomePageViewModel()
        {
            _allNotes = new List<NoteModel>();
             _noteData = new NoteData();

        #region Testing data

        _allNotes.Add(new NoteModel()
            {
                Title = "ExperimentView1",
                IsFavourite = false,
                Content = new NoteContentModel() { TextContent = "Does this display properly?" },
                ThemeName = 1
            });
            _allNotes.Add(new NoteModel()
            {
                Title = "ExperimentView2",
                IsFavourite = true,
                Content = new NoteContentModel() { TextContent = "Does this display properly or no?" },
                ThemeName = 2,
                NoteTags = new List<TagModel>() { new TagModel() { Name = "Cool" }, new TagModel() { Name = "Funny" } }
            });
            _allNotes.Add(new NoteModel()
            {
                Title = "ExperimentView3",
                IsFavourite = false,
                Content = new NoteContentModel() { TextContent = "Does this display properly at last?" },
                ThemeName = 3
            });
            _allNotes.Add(new NoteModel()
            {
                Title = "ExperimentView4",
                IsFavourite = false,
                Content = new NoteContentModel() { TextContent = "Does this display properly at last?" },
                ThemeName = 4
            });
            _allNotes.Add(new NoteModel()
            {
                Title = "ExperimentView5",
                IsFavourite = false,
                Content = new NoteContentModel() { TextContent = "Does this display properly at last?" }
            });
            _allNotes.Add(new NoteModel()
            {
                Title = "ExperimentView6",
                IsFavourite = false,
                Content = new NoteContentModel() { TextContent = "Does this display properly at last?" },
                ThemeName = 5
            });
            #endregion        
        }

        /// <summary>
        /// Meant to hook into database to get all the notes
        /// </summary>
        public List<NoteModel> AllNotes 
        { 
            get { return _noteData.GetAllNotes(); }
            set { _allNotes = value; }
        }
     
    }
}
