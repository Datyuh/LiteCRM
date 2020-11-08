using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using LiteCRM.Data;
using LiteCRM.Data.Context;
using LiteCRM.Data.Model;
using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;
using LiteCRM.Views.WindowPages;

namespace LiteCRM.ViewModels
{
    class DescktopViewsModel : BaseViewModel
    {
        ApplicationContext dbClients = new ApplicationContext();

        #region Вставка в DataGrid данных

        private ObservableCollection<Client> _contractClientsInWork;
        public ObservableCollection<Client> ContractClientsInWork { get => _contractClientsInWork; set => SetRef(ref _contractClientsInWork, value); }

        private ObservableCollection<ContractClientsOverdues> _contractClientsOverdue = new ObservableCollection<ContractClientsOverdues>();
        public ObservableCollection<ContractClientsOverdues> ContractClientsOverdue { get => _contractClientsOverdue; set => SetRef(ref _contractClientsOverdue, value); }

        #endregion

        #region Команды

        public ICommand OpenAddUserInBaseCommand { get; }
        private bool CanOpenAddUserInBaseCommandExecute(object p) => true;

        private void OnOpenAddUserInBaseCommandExecuted(object p)
        {
            AddUserInBase addUserInBase = new AddUserInBase();
            addUserInBase.ShowDialog();
        }

        #endregion

        public DescktopViewsModel()
        {
            OpenAddUserInBaseCommand = new LambdaCommand(OnOpenAddUserInBaseCommandExecuted, CanOpenAddUserInBaseCommandExecute);

            #region Добавление в грид

            ContractClientsInWork = new ObservableCollection<Client>(dbClients.Clients.Select(p => p).Where(p => p.StatusContract == "В работе").AsParallel());
            ContractClientsOverdue = new ObservableCollection<ContractClientsOverdues>(dbClients.Clients.ToList().Select(x => new ContractClientsOverdues(x)).Where(x => x.DayOverdue >= 0));
            
            #endregion
        }
    }
}
