using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class TagPageViewModel : Screen
    {
        private static BindableCollection<NoteModel> selectedTagCollection;

        public string SelectedTagName
        {
            get
            {
                return ShellViewModel.SelectedTag.Name;
            }
        }
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
