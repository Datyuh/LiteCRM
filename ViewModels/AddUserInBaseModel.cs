using System.Collections.ObjectModel;
using System.Linq;
using LiteCRM.Data.Context;
using LiteCRM.Data.Model;
using LiteCRM.ViewModels.Base;

namespace LiteCRM.ViewModels
{
    public class AddUserInBaseModel : BaseViewModel
    {
        ApplicationContext dbUsers = new ApplicationContext();

        #region Права пользователя оключение

        private bool _addInBaseUserRightsIsInabled;
        public bool AddInBaseUserRightsIsInabled { get => _addInBaseUserRightsIsInabled; set => SetRef(ref _addInBaseUserRightsIsInabled, value); }

        #endregion

        #region Считывание с TextBox данных введеных для регистрации

        private string _addInBaseUserLogin;
        public string AddInBaseUserLogin { get => _addInBaseUserLogin; set => SetRef(ref _addInBaseUserLogin, value); }

        private string _addInBaseUserPassword;
        public string AddInBaseUserPassword { get => _addInBaseUserPassword; set => SetRef(ref _addInBaseUserPassword, value); }

        private string _addInBaseUserRightsText = "User";
        public string AddInBaseUserRightsText { get => _addInBaseUserRightsText; set => SetRef(ref _addInBaseUserRightsText, value); }

        private string _addInBaseUserFio;
        public string AddInBaseUserFio { get => _addInBaseUserFio; set => SetRef(ref _addInBaseUserFio, value); }

        private string _addInBaseUserPosition;
        public string AddInBaseUserPosition { get => _addInBaseUserPosition; set => SetRef(ref _addInBaseUserPosition, value); }

        private string _addInBaseUserPhone;
        public string AddInBaseUserPhone { get => _addInBaseUserPhone; set => SetRef(ref _addInBaseUserPhone, value); }

        #endregion

        #region Работа с обновление прав для пользователя

        private bool _updateUserRightsIsInabledComboBox = true;
        public bool UpdateUserRightsIsInabledComboBox { get => _updateUserRightsIsInabledComboBox; set => SetRef(ref _updateUserRightsIsInabledComboBox, value); }

        private bool _updateUserRightsIsInabledButton;
        public bool UpdateUserRightsIsInabledButton { get => _updateUserRightsIsInabledButton; set => SetRef(ref _updateUserRightsIsInabledButton, value); }

        #endregion

        #region Отметка включен ли чекбокс

        private bool _updateUserRaghtCheckBox;
        public bool UpdateUserRaghtCheckBox { get => _updateUserRaghtCheckBox; set => SetRef(ref _updateUserRaghtCheckBox, value); }

        #endregion

        #region Добавление в DataGrid пользователей

        private ObservableCollection<Users> _showUsersesInDataGrid;
        public ObservableCollection<Users> ShowUsersesInDataGrid { get => _showUsersesInDataGrid; set => SetRef(ref _showUsersesInDataGrid, value); }

        #endregion

        public AddUserInBaseModel()
        {
            ShowUsersesInDataGrid = new ObservableCollection<Users>(dbUsers.Users.Where(p => p.Status == "Работает").Select(p => p));
        }
    }
}