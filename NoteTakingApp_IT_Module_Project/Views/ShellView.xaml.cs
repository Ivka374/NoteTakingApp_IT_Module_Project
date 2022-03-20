﻿using NoteTakingApp_IT_Module_Project.Models;
using NoteTakingApp_IT_Module_Project.ViewModels;
using System.Windows;
using System.Diagnostics;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;

namespace NoteTakingApp_IT_Module_Project.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        bool isMaximized = false;
        public ShellView()
        {
            InitializeComponent();
            Close.AddHandler(Button.ClickEvent, new RoutedEventHandler(Close_Click)); //this has to be here for some reason, just leave it be
            Mouse.AddMouseDownHandler(this, Window_MouseDown); //window now has mouseDown event check
        }
        private void AddNote()
        {
            NoteModel note = new NoteModel(); 
            
            //needs more tweaks for the input
            //will add the note to the database of notes

            //is this method still needed here? id say delete it
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) 
            this.DragMove();
        }
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

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine();
        }
                
    }
}