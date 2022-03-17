using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.ViewModels
{
    public class AddAndEditNoteViewModel : Window
    {
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                //DialogResult result = MessageBox.Show("Would you like to save changes?",
                //    "Note Closing",
                //    MessageBoxButton.YesNoCancel);
                //if (result == DialogResult.Yes)
                //{
                //    //save parameters from note
                //}
                //if (result == DialogResult.No)
                //{
                //    this.Close();
                //}
                //if (result == DialogResult.Cancel)
                //{
                //    e.Cancel = true;
                //}
            }
        }
    }
}
