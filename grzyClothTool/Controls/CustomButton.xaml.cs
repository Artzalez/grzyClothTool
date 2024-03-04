﻿using System.Windows;
using System.Windows.Controls;

namespace grzyClothTool.Controls
{
    /// <summary>
    /// Interaction logic for Button.xaml
    /// </summary>
    public partial class CustomButton : UserControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty
        .Register("Label",
                typeof(string),
                typeof(CustomButton),
                new FrameworkPropertyMetadata("Label"));

        public static readonly DependencyProperty DropdownEnabledProperty = DependencyProperty
        .Register("DropdownEnabled",
                typeof(bool),
                typeof(CustomButton),
                new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty
        .Register("CornerRadius",
                typeof(CornerRadius),
                typeof(CustomButton),
                new FrameworkPropertyMetadata(new CornerRadius(0)));

        public static readonly RoutedEvent BtnClickEvent = EventManager.RegisterRoutedEvent(
            "BtnClickEvent",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(CustomButton)
        );

        public event RoutedEventHandler MyBtnClickEvent
        {
            add { AddHandler(BtnClickEvent, value); }
            remove { RemoveHandler(BtnClickEvent, value); }
        }

        public object DropdownContent
        {
            get { return DropdownContentPresenter.Content; }
            set { DropdownContentPresenter.Content = value; }
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public bool DropdownEnabled
        {
            get { return (bool)GetValue(DropdownEnabledProperty); }
            set { SetValue(DropdownEnabledProperty, value); }
        }

        public CustomButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedBtn = sender as Button;

            BtnClickEventArgs args = new(BtnClickEvent);
            RaiseEvent(args);
        }

        public class BtnClickEventArgs(RoutedEvent routedEvent) : RoutedEventArgs(routedEvent)
        {
        }
    }
}
