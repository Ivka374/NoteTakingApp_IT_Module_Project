using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Screen
    {
        private static NoteModel editingDataContext;

        // this is the property for the note that was open to be edited
        public static NoteModel EditingDataContext 
        {
            get { return editingDataContext; }
            set 
            { 
                editingDataContext = value;
            }
        }

        /// <summary>
        /// A list of tags with checkable values
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
        //A list of the tags of the open note
        List<TagModel> assignedTags = new List<TagModel>();

        public CheckBoxTag()
        {
            assignedTags = AddAndEditNoteViewModel.EditingDataContext.NoteTags.ToList();
        }

        public CheckBoxTag(string name, int id)
        {
            Name = name;
            ID = id;
            assignedTags = AddAndEditNoteViewModel.EditingDataContext.NoteTags.ToList();
        }

        public bool IsChecked
        {
            get
            {
                //checks if the note contains the current tag
                return assignedTags.Any(t => t.Name == this.Name);
            }
        }
    }
}
