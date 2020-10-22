using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using LiteCRM.Annotations;
using LiteCRM.Data;
using LiteCRM.Data.Context;
using LiteCRM.Data.Model;
using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;

namespace LiteCRM.ViewModels
{
    class AddClientViewsModel : BaseViewModel
    {
        ApplicationContext dbClients = new ApplicationContext();
        readonly int thisMonth = DateTime.Now.Month;

        #region Вставка в DataGrid данных

        public ObservableCollection<Client> _client;
        [CanBeNull] public ObservableCollection<Client> ClientFromBase { get => _client; set => SetRef(ref _client, value); }

       #endregion

        #region Получение данных с TextBox

        private string _namberContractClient;
        public string NamberContractClient { get => _namberContractClient; set => SetRef(ref _namberContractClient, value); }

        private string _fioClient;
        public string FioClient { get => _fioClient; set => SetRef(ref _fioClient, value); }

        private string _nameOrgClient;
        public string NameOrgClient { get => _nameOrgClient; set => SetRef(ref _nameOrgClient, value); }

        private string _emailClient;
        public string EmailClient { get => _emailClient; set => SetRef(ref _emailClient, value); }

        private string _phoneClient;
        public string PhoneClient { get => _phoneClient; set => SetRef(ref _phoneClient, value); }

        private string _mobilPhoneClient;
        public string MobilPhoneClient { get => _mobilPhoneClient; set => SetRef(ref _mobilPhoneClient, value); }

        private string _typeWorkContract;
        public string TypeWorkContract { get => _typeWorkContract; set => SetRef(ref _typeWorkContract, value); }

        private DateTime _dateStartContractClient = DateTime.Now;
        public DateTime DateStartContractClient { get => _dateStartContractClient; set => SetRef(ref _dateStartContractClient, value); }

        private DateTime _dateEndContractClient = DateTime.Now;
        public DateTime DateEndContractClient { get => _dateEndContractClient; set => SetRef(ref _dateEndContractClient, value); }

        private string _symmaContractClient;
        public string SymmaContractClient { get => _symmaContractClient; set => SetRef(ref _symmaContractClient, value); }

        private string _statusContract = "В работе";
        public string StatusContract { get => _statusContract; set => SetRef(ref _statusContract, value); }


        #endregion

        #region Команды

        public ICommand AddClientInBaseCommand { get; }
        private bool CanAddClientInBaseCommandExecute(object p) => true;
        private void OnAddClientInBaseCommandExecuted(object p) 
        {
            try
            {
                using ( ApplicationContext dbClient = new ApplicationContext())
                {
                    Client clients = new Client()
                    {
                        NamberContract = NamberContractClient,
                        FIOClient = FioClient,
                        NameOrg = NameOrgClient,
                        TypeWork = TypeWorkContract,
                        Email = EmailClient,
                        Phone = PhoneClient,
                        MobilePhone = MobilPhoneClient,
                        DateStartContract = DateStartContractClient,
                        DateEndContract = DateEndContractClient,
                        SymmaContract = Convert.ToDouble(SymmaContractClient),
                        StatusContract = StatusContract,
                        RegistrDate = DateTime.Now,
                    };
                    dbClient?.Clients.Add(clients);
                    dbClient?.SaveChanges();
                    MessageBox.Show("Клиент добавлен в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не все данные были заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

            ClientFromBase = new ObservableCollection<Client>(dbClients.Clients.Where(p => p.RegistrDate.Value.Month == thisMonth));
            NamberContractClient = null;
            FioClient = null;
            NameOrgClient = null;
            EmailClient = null;
            PhoneClient = null;
            MobilPhoneClient = null;
            SymmaContractClient = "0";
        }

        #endregion

        public AddClientViewsModel()
        {
            AddClientInBaseCommand = new LambdaCommand(OnAddClientInBaseCommandExecuted, CanAddClientInBaseCommandExecute);

            #region Добавление в грид

            ClientFromBase = new ObservableCollection<Client>(dbClients.Clients.Where(p => p.RegistrDate.Value.Month == thisMonth));

            #endregion
        }
    }
}
