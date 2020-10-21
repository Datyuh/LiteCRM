using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiteCRM.Data.Context;
using LiteCRM.Data.Model;

namespace LiteCRM.Views.WindowPages.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClientsView : Page
    {
        public AddClientsView()
        {
            InitializeComponent();
            var typeWorkInCombo = new List<string> {"ООС", "ПНОЛР", "ПДВ"};
            TypeWork_Combo.ItemsSource = typeWorkInCombo;
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            SymmaContract_text.Text = 0.ToString();
            SymmaContract_text.Foreground = Brushes.Gray;

        }

        private void SymmaContract_text_GotFocus(object sender, RoutedEventArgs e)
        {
            SymmaContract_text.Foreground = Brushes.Black;
            if (SymmaContract_text.Text == 0.ToString())
                SymmaContract_text.Text = "";
        }

        private void SymmaContract_text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SymmaContract_text.Text == "")
            {
                SymmaContract_text.Text = 0.ToString();
                SymmaContract_text.Foreground = Brushes.Gray;
            }

        }
    }
}
