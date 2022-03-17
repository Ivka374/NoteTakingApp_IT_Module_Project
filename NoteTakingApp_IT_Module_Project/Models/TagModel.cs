using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls; //is this the right kind?

namespace NoteTakingApp_UI.Models
{
    public class TagModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ConsoleColor Colour { get; set; } //is this the right type?
        public TagModel()
        {

        }
        public TagModel(int id, string name, ConsoleColor colour)
        {
            ID = id;
            Name = name;
            Colour = colour;
        }
    }
}
