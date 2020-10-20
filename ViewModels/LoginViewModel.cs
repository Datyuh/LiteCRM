using LiteCRM.Data;
using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;
using LiteCRM.Views.WindowPages;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LiteCRM.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        public MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        #region Переменные для базы данных

        private ObservableCollection<string> _loginWithoutBase;
        private ObservableCollection<string> _passWithoutBase;
        private ObservableCollection<string> _userRightGetIn;

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
            _loginWithoutBase = new DbUsersRequest().LogInUsers();
            _passWithoutBase = new DbUsersRequest().PassUsers(LoginUserInputWithoutWindow);
            if (_passWithoutBase.Contains(PassUserInputWithoutWindow) && _loginWithoutBase.Contains(LoginUserInputWithoutWindow))
            {
                MainWindow mainWindow = new MainWindow { DataContext = mainWindowViewModel };
                mainWindow.Show();
                _userRightGetIn = new DbUsersRequest().UserRightGetIn(LoginUserInputWithoutWindow, PassUserInputWithoutWindow);
                mainWindowViewModel.AddClientDependingUserLoginIsEnable = !_userRightGetIn.Contains("User");
                mainWindowViewModel.WorkBaseDependingUserLoginIsEnable = !_userRightGetIn.Contains("User");
            }
            else MessageBox.Show("Нет пользователя с таким Логином и Паролем", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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