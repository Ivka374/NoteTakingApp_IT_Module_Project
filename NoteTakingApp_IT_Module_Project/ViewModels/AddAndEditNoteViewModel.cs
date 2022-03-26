using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Screen
    {
        private static NoteModel editingDataContext;

        /// <summary>
        /// The data context for the note that was opened
        /// </summary>
        public static NoteModel EditingDataContext 
        {
            get { return editingDataContext; }
            set 
            { 
                editingDataContext = value;
            }
        }

        /// <summary>
        /// A list of tags suited for checkBox use
        /// </summary>
        public List<CheckBoxTag> CheckBoxTags
        {
            get
            {
                return ShellViewModel.Tags.Select(parent => new CheckBoxTag(parent.Name, parent.ID)).ToList();
            }
        }
    }

    /// <summary>
    /// A class meant to enable checking wether a tag from the overall collection belongs to that of the current note
    /// </summary>
    public class CheckBoxTag : TagModel
    {
        #region Constructors
        public CheckBoxTag()
        {
        }

        public CheckBoxTag(string name, int id)
        {
            Name = name;
            ID = id;
        }
        #endregion

        public bool IsChecked
        {
            get
            {
                //checks if the note contains the current tag
                return AddAndEditNoteViewModel.EditingDataContext.NoteTags.Any(t => t.Name == this.Name);
            }

            set
            {
                if (value)
                {
                    AddAndEditNoteViewModel.EditingDataContext.NoteTags.Add(ShellViewModel.Tags.First(t => t.Name == this.Name));
                } else
                {
                    var tag = AddAndEditNoteViewModel.EditingDataContext.NoteTags.First(t => t.Name == this.Name);
                    AddAndEditNoteViewModel.EditingDataContext.NoteTags.Remove(tag);
                }
                
            }
        }
    }
}
