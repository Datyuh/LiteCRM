using System.Threading;
using System.Threading.Tasks;
using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LiteCRM.Views.WindowPages.Pages;

namespace LiteCRM.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Создания экземпляра окон
        
        private Page addClientsView;
        private Page descktopAdminView;
        private Page searchContactsView;

        private Page _currentPage;
        private Page CurrentPage;

        private double _frameOpacity;
        public double FrameOpacity;

        #endregion

        #region Команды

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        private async void SlowOpaciry(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }

                CurrentPage = page;
                for (double i = 0.0; i < 1.0; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }

        public MainWindowViewModel()
        {
            #region Использование команд

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

            #region Вставка окон в основное окно

            addClientsView = new AddClientsView();
            descktopAdminView = new DescktopAdminView();
            searchContactsView = new SearchContactsView();

            CurrentPage = descktopAdminView;

            #endregion
        }

    }
}

