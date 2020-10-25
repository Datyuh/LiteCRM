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
            foreach (var items in new DbClientRequest().NamberConToGrid())
            {
                ContractClientsOverdue.Add(new ContractClientsOverdues { NamberContracts = items });
            }
            foreach (var items in dbClients.Clients.Select(p => p.DateEndContract))
            {
                TimeSpan dayOverdues = thisMonth - items;
                ContractClientsOverdue.Add(new ContractClientsOverdues { DayOverdue = dayOverdues.Days });
            }

            #region Добавление в грид

            ContractClientsInWork = new ObservableCollection<Client>(dbClients.Clients.Where(p => p.StatusContract == "В работе").AsParallel());

            ClientsOverdue = new ObservableCollection<object>(dbClients.Clients.Join
            (ContractClientsOverdue, p => p.NamberContract, t => t.NamberContracts, (p, t) => new
            {
                NamberContracts = p.NamberContract,
                NamaeOrgsnization = p.NameOrg,
                TypeWorks = p.TypeWork,
                DateEndContracts = p.DateEndContract,
                StatysContract = p.StatusContract,
                DayOverdues = t.DayOverdue
            }));




            //foreach (var items in new DbClientRequest().NameOrgToGrid())
            //{
            //    ContractClientsOverdue.Add(new ContractClientsOverdues { NamaeOrgsnization = items });
            //}

            //foreach (var items in new DbClientRequest().TypeWorkToGrid())
            //{
            //    ContractClientsOverdue.Add(new ContractClientsOverdues { TypeWorks = items });
            //}

            //foreach (var items in new DbClientRequest().DateEndConToGrid())
            //{
            //    ContractClientsOverdue.Add(new ContractClientsOverdues { DateEndContracts = items });
            //}

            //foreach (var items in new DbClientRequest().StatusConontract())
            //{
            //    ContractClientsOverdue.Add(new ContractClientsOverdues { StatysContract = items });
            //}

            //ContractClientsOverdue = new ObservableCollection<ContractClientsOverdues>
            //{

            //    new ContractClientsOverdues { NamberContracts = NamberContract,  NamaeOrgsnization = NameOrgToGrid, TypeWorks = TypeWorksGrid,
            //        DateEndContracts = DateEndContract, StatysContract = StatusConontracts,  DayOverdue = DayOverdueGrid}
            //};

            #endregion
        }
    }
}
