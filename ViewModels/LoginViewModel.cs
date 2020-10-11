using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LiteCRM.Infrastucture.Commands;
using LiteCRM.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LiteCRM.Data;
using LiteCRM.Data.Context;
using LiteCRM.Data.Model;
using LiteCRM.Views.WindowPages;

namespace LiteCRM.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Переменные для базы данных

        private List<string> LoginWithoutBase;
        private List<string> PassWithoutBase;

        #endregion

        #region Логирование

        private string _passUserInputWithoutWindow;
        private string _loginUserInputWithoutWindow;

        public string PassUserInputWithoutWindow { get => _passUserInputWithoutWindow; set => Set(ref _passUserInputWithoutWindow, value); }
        public string LoginUserInputWithoutWindow { get => _loginUserInputWithoutWindow; set => Set(ref _loginUserInputWithoutWindow, value); }

        #endregion


        #region Команды

        public  ICommand ButtonClickGetInCommand { get; }

        private bool CanButtonClickGetInCommandExecute(object p) => true;

        private void OnButtonClickGetInCommandExecuted(object p) => LogInUsers(LoginUserInputWithoutWindow, PassUserInputWithoutWindow);

        public void LogInUsers(object l, object p)
        {
            if (LoginWithoutBase.Contains(l) && PassWithoutBase.Contains(p))
            {
                var passwordBox = new PasswordBox();
                var password = passwordBox.Password;
                PassUserInputWithoutWindow = password;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
               
            else
            {
                MessageBox.Show("Нет пользователя с таким Логином и Паролем", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p) { Application.Current.Shutdown(); }

        #endregion
        public LoginViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ButtonClickGetInCommand = new LambdaCommand(OnButtonClickGetInCommandExecuted, CanButtonClickGetInCommandExecute);

            LoginWithoutBase = new DbUsersRequest().LogInUsers().AsParallel().ToList();
            PassWithoutBase = new DbUsersRequest().PassUsers().AsParallel().ToList();

        }
    }
}