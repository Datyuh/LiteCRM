using System.Windows;
using System.Windows.Input;
using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;

namespace LiteCRM.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Команда на закрытие программы
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuded(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecuded(object p) => true;
        #endregion

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuded, CanCloseApplicationCommandExecuded);
        }
    }
}
