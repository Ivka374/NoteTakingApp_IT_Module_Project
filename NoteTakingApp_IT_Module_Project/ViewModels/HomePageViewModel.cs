using Caliburn.Micro;
using NoteTakingApp_UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApp_UI.ViewModels
{
    public class HomePageViewModel : Screen
    {
        List<NoteModel> AllNotes = new List<NoteModel>(); 
        //maybe connect to full notes database here?
    }
}
