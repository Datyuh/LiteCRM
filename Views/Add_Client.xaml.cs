using LiteCRM.BaseWork.Context;
using LiteCRM.BaseWork.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LiteCRM.Views
{
    /// <summary>
    /// Логика взаимодействия для Add_Client_Maodel.xaml
    /// </summary>
    public partial class Add_Client : UserControl
    {
        public Add_Client()
        {
            InitializeComponent();
            var typeWorkInCombo = new List<string> { "ООС", "ПНОЛР", "ПДВ" };
            TypeWork_Combo.ItemsSource = typeWorkInCombo;
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            SymmaContract_text.Text = 0.ToString();
            SymmaContract_text.Foreground = Brushes.Gray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string namberContractClient = NomberContract_text.Text;
                string fioClient = FIO_text.Text;
                string nameOrgClient = NameORG_text.Text;
                string emailClient = Email_text.Text;
                string phoneClient = Phone_text.Text;
                string mobilPhoneClient = MobilPhone_text.Text;
                string typeWorkContract = TypeWork_Combo.Text;
                var dateStartContractClient = (DateTime?)DateStartContract_date.SelectedDate.Value.Date;
                var dateEndContractClient = (DateTime?)DateEndContract_date.SelectedDate.Value.Date;
                var symmaContractClient = Convert.ToDecimal(SymmaContract_text.Text);
                var statusContract = "В работе";

                using (ApplicationContext dbClient = new ApplicationContext())
                {
                    var clients = new Client()
                    {
                        NamberContract = namberContractClient,
                        FIOClient = fioClient,
                        NameOrg = nameOrgClient,
                        TypeWork = typeWorkContract,
                        Email = emailClient,
                        Phone = phoneClient,
                        MobilePhone = mobilPhoneClient,
                        DateStartContract = dateStartContractClient,
                        DateEndContract = dateEndContractClient,
                        SymmaContract = (float?)symmaContractClient,
                        StatusContract = statusContract,
                    };

                    dbClient.Clients.Add(clients);
                    dbClient.SaveChanges();
                    MessageBox.Show("Клиент добавлен в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не все данные были заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

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

        // Dictionary<string, object> keyValuePairs = new Dictionary<string, object>
        //{
        //     { "NamberContract", namberContractClient }, {"FIOClient", fioClient}, {"NameOrg", nameOrgClient}, { "TypeWork", typeWorkContract },
        //     { "Email",  emailClient}, {"Phone", phoneClient}, {"MobilePhone", mobilPhoneClient}, {"DateStartContract", dateStartContractClient},
        //     {"DateEndContract", dateEndContractClient}, {"SymmaContract", symmaContractClient}, {"StatusContract", statusContract}
        //};

        // new DbClientRequest().AddClientInBase(keyValuePairs);

    }
}
