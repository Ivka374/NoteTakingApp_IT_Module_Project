using Caliburn.Micro;
using NoteTakingApp_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NoteTakingApp_UI
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
