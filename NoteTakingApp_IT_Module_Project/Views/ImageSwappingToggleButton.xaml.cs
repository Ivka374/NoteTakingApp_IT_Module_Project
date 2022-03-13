using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteTakingApp_IT_Module_Project.Views
{
    public partial class ImageSwappingToggleButton : UserControl
    {
        public ImageSwappingToggleButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty EnabledUncheckedProperty =
            DependencyProperty.Register("EnabledUnchecked",
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

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
            "IsChecked",
            typeof(Boolean),
            typeof(ImageSwappingToggleButton),
            new PropertyMetadata(onCheckedChangedCallback));

        public Boolean IsChecked
        {
            get { return (Boolean)GetValue(IsCheckedProperty); }
            set { if (value != IsChecked) SetValue(IsCheckedProperty, value); }
        }

        static void onCheckedChangedCallback(
            DependencyObject dobj,
            DependencyPropertyChangedEventArgs args)
        {

        }

    }
}
