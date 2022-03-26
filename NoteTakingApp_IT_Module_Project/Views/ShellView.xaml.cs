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

        /// <summary>
        /// Handles dragging of window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) 
            this.DragMove();
        }

        #region Closing, minimizing and maximizing

        /// <summary>
        /// Closes window through custom button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Maximizes window through custom button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Minimizes window through custom button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion
    }
}