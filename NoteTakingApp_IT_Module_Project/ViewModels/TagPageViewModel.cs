using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.Models;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class TagPageViewModel : Screen
    {
        private BindableCollection<NoteModel> selectedTagCollection;

        public string SelectedTagName
        {
            get
            {
                return ShellViewModel.SelectedTag.Name;
            }
        }
        public BindableCollection<NoteModel> SelectedTagCollection
        {
            get { return selectedTagCollection; }
            set { selectedTagCollection = value; }
        }
    }
}
