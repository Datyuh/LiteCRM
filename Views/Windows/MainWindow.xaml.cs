using LiteCRM.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace LiteCRM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();            

            DataContext = new DescktopViewsModel();

            Dasktop.Background = Brushes.White;
            Deskbord.Foreground = Brushes.Black;
            Tangle_Desktop.Fill = Brushes.Lime; 
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            new LogIn().Show();
        }

        public void GetInUserRight(List<string> ur)
        {
            if (ur.Contains("User"))
            {
                Add_cient.IsEnabled = false;
                Work_to_base.IsEnabled = false;
            }

            else
            {
                Add_cient.IsEnabled = true;
            }
        }

        private void Dasktop_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DescktopViewsModel();

            if (Dasktop.IsPressed == false)
            {
                Dasktop.Background = Brushes.White;
                Deskbord.Foreground = Brushes.Black;

                Contact_batton.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Contact_text.Foreground = Brushes.White;

                Add_cient.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Add_Cient_text.Foreground = Brushes.White;

                Work_to_base.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Work_to_base_text.Foreground = Brushes.White;

                Tangle_Desktop.Fill = Brushes.Lime;
                Tangle_add.Fill = Brushes.Orange;
                Tangle_work_base.Fill = Brushes.Orange;
                Tangle_contact.Fill = Brushes.Orange;
            }
        }

        private void Add_cient_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddClientViewsModel();

            if (Add_cient.IsPressed == false)
            {
                Add_cient.Background = Brushes.White;
                Add_Cient_text.Foreground = Brushes.Black;


                Contact_batton.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Contact_text.Foreground = Brushes.White;

                Dasktop.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Deskbord.Foreground = Brushes.White;

                Work_to_base.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Work_to_base_text.Foreground = Brushes.White;

                Tangle_add.Fill = Brushes.Lime;
                Tangle_Desktop.Fill = Brushes.Orange;
                Tangle_work_base.Fill = Brushes.Orange;
                Tangle_contact.Fill = Brushes.Orange;
            }
        }

        private void Work_to_base_Click(object sender, RoutedEventArgs e)
        {
            if (Add_cient.IsPressed == false)
            {
                Work_to_base.Background = Brushes.White;
                Work_to_base_text.Foreground = Brushes.Black;

                Contact_batton.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Contact_text.Foreground = Brushes.White;

                Dasktop.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Deskbord.Foreground = Brushes.White;

                Add_cient.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Add_Cient_text.Foreground = Brushes.White;

                Tangle_work_base.Fill = Brushes.Lime;
                Tangle_add.Fill = Brushes.Orange;
                Tangle_Desktop.Fill = Brushes.Orange;
                Tangle_contact.Fill = Brushes.Orange;
            }
        }
        private void Contact_batton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SearchContactsModel();

            if (Contact_batton.IsPressed == false)
            {
                Contact_batton.Background = Brushes.White;
                Contact_text.Foreground = Brushes.Black;

                Dasktop.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Deskbord.Foreground = Brushes.White;

                Add_cient.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Add_Cient_text.Foreground = Brushes.White;

                Work_to_base.Background = new SolidColorBrush(Color.FromRgb(37, 41, 42));
                Work_to_base_text.Foreground = Brushes.White;

                Tangle_contact.Fill = Brushes.Lime;
                Tangle_work_base.Fill = Brushes.Orange;
                Tangle_add.Fill = Brushes.Orange;
                Tangle_Desktop.Fill = Brushes.Orange;
            }
        }

        private void Dasktop_MouseEnter(object sender, MouseEventArgs e)
        {
            Info_button.Text = "Преход на робочий стол где расположенны основные графики и актуальня информация о договорах";
        }

        private void Dasktop_MouseLeave(object sender, MouseEventArgs e)
        {
            Info_button.Text = string.Empty;
        }

        private void Add_cient_MouseEnter(object sender, MouseEventArgs e)
        {
            Info_button.Text = "Добавление клиентов и просмотр последних добавленных за последный месяц";
        }

        private void Add_cient_MouseLeave(object sender, MouseEventArgs e)
        {
            Info_button.Text = string.Empty;
        }

        private void Work_to_base_MouseEnter(object sender, MouseEventArgs e)
        {
            Info_button.Text = "Работа с базой клиентов удаление, изменение состояния договоров и тд.";
        }

        private void Work_to_base_MouseLeave(object sender, MouseEventArgs e)
        {
            Info_button.Text = string.Empty;
        }

        private void RollUp_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            new LogIn().Show();
            Close();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            Exit.Foreground = Brushes.White;
            Exit.Background = new SolidColorBrush(Color.FromRgb(232, 17, 35));
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            Exit.Background = new SolidColorBrush(Color.FromRgb(31, 31, 31));
            Exit.Foreground = new SolidColorBrush(Color.FromRgb(153, 157, 159));
        }

        private void RollUp_MouseEnter(object sender, MouseEventArgs e)
        {
            RollUp.Foreground = Brushes.White;
            RollUp.Background = new SolidColorBrush(Color.FromRgb(51, 59, 64));
        }

        private void RollUp_MouseLeave(object sender, MouseEventArgs e)
        {
            RollUp.Background = new SolidColorBrush(Color.FromRgb(31, 31, 31));
            RollUp.Foreground = new SolidColorBrush(Color.FromRgb(153, 157, 159));
        }
    }
}
