using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace NoteTakingApp_IT_Module_Project.Views
{
    public partial class ShellView : Window
    {
        bool isMaximized = false;
        public ShellView()
        {
            InitializeComponent();

            //handles closing
            Close.AddHandler(Button.ClickEvent, new RoutedEventHandler(Close_Click));

            //makes window draggable
            Mouse.AddMouseDownHandler(this, Window_MouseDown);
        }

        //handles dragging
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) 
            this.DragMove();
        }

        #region Closing, minimizing and maximizing

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximized == false)
            {
                MainWindow.WindowState = WindowState.Maximized;
                isMaximized = true;
            }
            else
            {
                MainWindow.WindowState = WindowState.Normal;
                isMaximized = false;
            }
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion
    }
}