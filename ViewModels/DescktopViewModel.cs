using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using LiteCRM.Data;
using LiteCRM.Data.Context;
using LiteCRM.Data.Model;
using LiteCRM.ViewModels.Base;

namespace LiteCRM.ViewModels
{
    class DescktopViewsModel : BaseViewModel
    {
        ApplicationContext dbClients = new ApplicationContext();
        private readonly DateTime thisMonth = DateTime.Now;
      
        #region Вставка в DataGrid данных

        private ObservableCollection<Client> _contractClientsInWork;
        public ObservableCollection<Client> ContractClientsInWork { get => _contractClientsInWork; set => SetRef(ref _contractClientsInWork, value); }

        private ObservableCollection<ContractClientsOverdues> _contractClientsOverdue = new ObservableCollection<ContractClientsOverdues>();
        public ObservableCollection<ContractClientsOverdues> ContractClientsOverdue { get => _contractClientsOverdue; set => SetRef(ref _contractClientsOverdue, value); }

        private ObservableCollection<object> _clientsOverdue;
        public ObservableCollection<object> ClientsOverdue { get => _clientsOverdue; set => SetRef(ref _clientsOverdue, value); }

        #endregion


        public DescktopViewsModel()
        {
            #region Добавление в грид

            ContractClientsInWork = new ObservableCollection<Client>(dbClients.Clients.Select(p => p).Where(p=>p.StatusContract == "В работе").AsParallel());


            foreach (var items in dbClients.Clients.Select(p => p.DateEndContract))
            {
                TimeSpan dayOverdues = thisMonth - items;
                ContractClientsOverdue = new ObservableCollection<ContractClientsOverdues>();

                //ContractClientsOverdue.Add(new ContractClientsOverdues
                //{
                //   DayOverdue = dayOverdues.Days,
                //});
            }

            #endregion
        }
    }
}
