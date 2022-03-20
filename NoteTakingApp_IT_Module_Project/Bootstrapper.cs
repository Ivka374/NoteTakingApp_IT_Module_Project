using Caliburn.Micro;
using NoteTakingApp_IT_Module_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NoteTakingApp_IT_Module_Project
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
