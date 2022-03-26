using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class TagPageViewModel : Screen
    {
        private static BindableCollection<NoteModel> selectedTagCollection;


        /// <summary>
        /// The name of the tag, the notes of which are displayed
        /// </summary>
        public string SelectedTagName
        {
            get
            {
                return ShellViewModel.SelectedTag.Name;
            }
        }

        /// <summary>
        /// Meant to hook into database and get all notes of tag with name corresponding to property above
        /// </summary>
        public static BindableCollection<NoteModel> SelectedTagCollection
        {
            get
            { 
                return selectedTagCollection;
            }
            set 
            { 

                selectedTagCollection = value; 
            }
        }
    }
}
