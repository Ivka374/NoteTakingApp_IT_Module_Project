using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NoteTakingApp_IT_Module_Project.Views
{
    public partial class ImageSwappingToggleButton : UserControl, INotifyPropertyChanged
    {
        #region Property change handler
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        public ImageSwappingToggleButton()
        {
            InitializeComponent();
        }

        #region EnabledUncheckedProperty
        public static readonly DependencyProperty EnabledUncheckedProperty =
           DependencyProperty.Register(
               "EnabledUnchecked",
               typeof(ImageSource),
               typeof(ImageSwappingToggleButton),
               new PropertyMetadata(onEnabledUncheckedChangedCallback));

        public ImageSource EnabledUnckecked
        {
            get { return (ImageSource)GetValue(EnabledUncheckedProperty); }
            set { SetValue(EnabledUncheckedProperty, value); }
        }

        static void onEnabledUncheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {

        }
        #endregion

        #region DisabledUncheckedProperty
        public static readonly DependencyProperty DisabledUncheckedProperty =
            DependencyProperty.Register(
            "DisabledUnchecked",
            typeof(ImageSource),
            typeof(ImageSwappingToggleButton),
            new PropertyMetadata(onDisabledUncheckedChangedCallback));

        public ImageSource DisabledUnchecked
        {
            get { return (ImageSource)GetValue(DisabledUncheckedProperty); }
            set { SetValue(DisabledUncheckedProperty, value); }
        }

        static void onDisabledUncheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {

        }
        #endregion

        #region EnabledCheckedProperty
        public static readonly DependencyProperty EnabledCheckedProperty =
            DependencyProperty.Register(
            "EnabledChecked",
            typeof(ImageSource),
            typeof(ImageSwappingToggleButton),
            new PropertyMetadata(onEnabledCheckedChangedCallback));

        public ImageSource EnabledChecked
        {
            get { return (ImageSource)GetValue(EnabledCheckedProperty); }
            set { SetValue(EnabledCheckedProperty, value); }
        }

        static void onEnabledCheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {

        }
        #endregion

        #region IsCheckedProperty
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
            "IsChecked",
            typeof(bool),
            typeof(ImageSwappingToggleButton),
            new PropertyMetadata(onCheckedChangedCallback));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty);}
            set { if (value != IsChecked) SetValue(IsCheckedProperty, value); }
        }

        static void onCheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {

        } 
        #endregion

    }
}
