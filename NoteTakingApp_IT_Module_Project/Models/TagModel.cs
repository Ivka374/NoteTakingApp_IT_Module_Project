using System;

namespace NoteTakingApp_IT_Module_Project.Models
{
    public class TagModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TagModel()
        {

        }
        public TagModel(int id, string name)
        {
            ID = id;
            Name = name;
            Colour = colour;
        }
    }
}
