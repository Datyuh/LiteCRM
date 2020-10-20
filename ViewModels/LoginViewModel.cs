using LiteCRM.Data;
using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;
using LiteCRM.Views.WindowPages;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace LiteCRM.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        public MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        #region Переменные для базы данных

        //private readonly List<string> _loginWithoutBase;
        //private List<string> _passWithoutBase;
        public ObservableCollection<string> UserRightGetIn;

        #endregion

        #region Логирование

        private string _passUserInputWithoutWindow;
        private string _loginUserInputWithoutWindow;

        public string LoginUserInputWithoutWindow { get => _loginUserInputWithoutWindow; set => SetRef(ref _loginUserInputWithoutWindow, value); }
        public string PassUserInputWithoutWindow { get => _passUserInputWithoutWindow; set => SetRef(ref _passUserInputWithoutWindow, value); }

        #endregion


        #region Команды

        public ICommand ButtonClickGetInCommand { get; }
        private bool CanButtonClickGetInCommandExecute(object p) => true; //new VerifyHashedPassword().VerifyHashedPasswords(, );
        private void OnButtonClickGetInCommandExecuted(object p)
        {
            MainWindow mainWindow = new MainWindow {DataContext = mainWindowViewModel};
            mainWindow.Show();
            UserRightGetIn = new DbUsersRequest().UserRightGetIn(LoginUserInputWithoutWindow, PassUserInputWithoutWindow);
            const bool a = false; //!UserRightGetIn.Contains("User");
            mainWindowViewModel.AddClientDependingUserLoginIsEnable = a;

        }

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p) { Application.Current.Shutdown(); }

        #endregion
        public LoginViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ButtonClickGetInCommand = new LambdaCommand(OnButtonClickGetInCommandExecuted, CanButtonClickGetInCommandExecute);
        }
    }
}