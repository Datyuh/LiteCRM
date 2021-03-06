﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LiteCRM.Views.WindowPages
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        //List<string> pass = new List<string>(new DbUsersRequest().PassUsers().AsParallel());
        //List<string> logIn = new List<string>(new DbUsersRequest().LogInUsers().AsParallel());
        public LogIn()
        {
            InitializeComponent();
        }


        private void Drop_LogIn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            Exit_LogIn.Foreground = Brushes.White;
            Exit_LogIn.Background = new SolidColorBrush(Color.FromRgb(232, 17, 35));
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            Exit_LogIn.Background = new SolidColorBrush(Color.FromRgb(31, 31, 31));
            Exit_LogIn.Foreground = new SolidColorBrush(Color.FromRgb(153, 157, 159));
        }

        private void Drop_MouseEnter(object sender, MouseEventArgs e)
        {
            Drop_LogIn.Foreground = Brushes.White;
            Drop_LogIn.Background = new SolidColorBrush(Color.FromRgb(51, 59, 64));
        }

        private void Drop_MouseLeave(object sender, MouseEventArgs e)
        {
            Drop_LogIn.Background = new SolidColorBrush(Color.FromRgb(31, 31, 31));
            Drop_LogIn.Foreground = new SolidColorBrush(Color.FromRgb(153, 157, 159));
        }
    }
}
