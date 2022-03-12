using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string _firstName = "Tim";

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

    }
}
