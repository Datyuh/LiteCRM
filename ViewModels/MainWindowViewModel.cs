using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;
using LiteCRM.Views.WindowPages.Pages;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LiteCRM.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
       // public ObservableCollection<string> GetRightUsersCollection = new ObservableCollection<string>();
        #region Добовление в главное окно разных страниц

        private readonly Page _addClientsView;
        private readonly Page _descktopAdminView;
        private readonly Page _searchContactsView;

        private Page _currentPage;
        public Page CurrentPage { get => _currentPage; set => SetRef(ref _currentPage, value); }

        private double _frameOpacity;
        public double FrameOpacity { get => _frameOpacity; set => SetRef(ref _frameOpacity, value); }

        private bool _addClientDependingUserLoginIsEnable = true;
        public bool AddClientDependingUserLoginIsEnable { get => _addClientDependingUserLoginIsEnable; set => Set(_addClientDependingUserLoginIsEnable, value); }

        private bool _workBaseDependingUserLoginIsEnable = true;
        public bool WorkBaseDependingUserLoginIsEnable { get => _workBaseDependingUserLoginIsEnable; set => SetRef(ref _workBaseDependingUserLoginIsEnable, value); }
        
        #endregion

        #region Команды

        //Смена окна на добавление клиентов
        public ICommand CurrentPageAddClientsCommand { get; }
        private bool CanCurrentPageAddClientsCommandExecute(object p) => true;

        private void OnCurrentPageAddClientsCommandExecuted(object p)
        {
            //AddClientDependingUserLoginIsEnable = !GetRightUsersCollection.Contains("User");
            SlowOpaciry(_addClientsView);
        }

        //Смена окна на Рабочий стол
        public ICommand CurrentPageDescktopAdminCommand { get; }
        private bool CanCurrentPageDescktopAdminCommandExecute(object p) => true;
        private void OnCurrentPageDescktopAdminCommandExecuted(object p) => SlowOpaciry(_descktopAdminView);

        //Смена окна на Поиск клиентов
        public ICommand CurrentPageSearchContactsCommand { get; }
        private bool CanCurrentPageSearchContactsCommandExecute(object p) => true;
        private void OnCurrentPageSearchContactsCommandExecuted(object p) => SlowOpaciry(_searchContactsView);

        // Закрытие Окна
        public ICommand CloseApplicationMainCommand { get; }
        private bool CanCloseApplicationMainCommandExecute(object p) => true;
        private void OnCloseApplicationMainCommandExecuted(object p) { Application.Current.Shutdown(); }

        #endregion

        #region Плавная смена окон

        private async void SlowOpaciry(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(millisecondsTimeout: 50);
                }

                CurrentPage = page;
                for (double i = 0.0; i < 1.0; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(millisecondsTimeout: 50);
                }
            });
        }

        #endregion



        public MainWindowViewModel()
        {
            #region Использование команд

            // Команда на закрытие окон
            CloseApplicationMainCommand = new LambdaCommand(OnCloseApplicationMainCommandExecuted,
                CanCloseApplicationMainCommandExecute);
            // Команда на смену окна Добавления клиентов
            CurrentPageAddClientsCommand = new LambdaCommand(OnCurrentPageAddClientsCommandExecuted,
                CanCurrentPageAddClientsCommandExecute);
            // Команда на смену окна Добавления Рабочего стола
            CurrentPageDescktopAdminCommand = new LambdaCommand(OnCurrentPageDescktopAdminCommandExecuted,
                CanCurrentPageDescktopAdminCommandExecute);
            // Команда на смену окна для Поиска по базе
            CurrentPageSearchContactsCommand = new LambdaCommand(OnCurrentPageSearchContactsCommandExecuted,
                CanCurrentPageSearchContactsCommandExecute);

            #endregion

            #region Объявление экземпляров окон для добавления в основное окно

            _addClientsView = new AddClientsView();
            _descktopAdminView = new DescktopAdminView();
            _searchContactsView = new SearchContactsView();

            FrameOpacity = 1;

            CurrentPage = _descktopAdminView;

            #endregion
        }

        #region Проверка на права пользователя

        //public bool GetInUserRight(string log, string pass)
        //{
        //    var passWithoutBase = new DbUsersRequest().PassUsers(log).AsParallel();
        //    if (passWithoutBase.Contains(pass))
        //    {
        //        var getLoginUsersSettings = new ObservableCollection<string>(new DbUsersRequest().UserRightGetIn(log, pass));
        //        return AddClientDependingUserLoginIsEnable = !getLoginUsersSettings.Contains("User");
        //    }

        //    else
        //    {
        //        MessageBox.Show("Нет пользователя с таким Логином и Паролем", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //        return AddClientDependingUserLoginIsEnable = false;
        //    }
        //}

        #endregion
        //void FundsForSubdivisionsShow()
        //{
        //    LoginViewModel vm = new LoginViewModel();
        //    LogIn wnd = new LogIn();
        //    wnd.DataContext = vm;
        //    wnd.ShowDialog();

        //}
    }
}

