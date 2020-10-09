using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace LiteCRM.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Команды
        public  ICommand ButtonClickGetInCommand { get; }
        private bool CanButtonClickGetInCommandExecute(object p) => true;

        private void OnButtonClickGetInCommandExecuted(object p) => new MainWindow().Show(); 

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion
        public LoginViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ButtonClickGetInCommand = new LambdaCommand(OnButtonClickGetInCommandExecuted, CanButtonClickGetInCommandExecute);
        }
    }
}