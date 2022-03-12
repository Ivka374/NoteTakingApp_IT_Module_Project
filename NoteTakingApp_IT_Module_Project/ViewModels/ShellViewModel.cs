using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.ViewModels
{
    public class Tag
    {
        public Tag(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class ListOfTags
    {
        public ListOfTags(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public List<Tag> TagsList { get; set; } = new List<Tag>();

        public void AddTag(Tag tag)
        {
            TagsList.Add(tag);
        }
    }
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ListOfTags listOfTags = new ListOfTags("Tags");
            Tag personal = new Tag("Personal");
            Tag work = new Tag("Work");
        }
    }
}