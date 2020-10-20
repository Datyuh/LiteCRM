using LiteCRM.Data.Context;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LiteCRM.ViewModels;
using LiteCRM.Views.WindowPages;

namespace LiteCRM.Data
{
    class DbUsersRequest
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> LogInUsers()
        {
            var logInUsers = new ObservableCollection<string>(db.Users.Select(p => p.Login).AsParallel());
            return logInUsers;
        }

        public ObservableCollection<string> PassUsers(string loginUserInput)
        {
            var passInUsers = new ObservableCollection<string>(db.Users.Where(p => p.Login == loginUserInput).Select(p => p.Pass).AsParallel());
            return passInUsers;
        }
        public ObservableCollection<string> UserRightGetIn(string ulog, string upass)
        {
            var userRight = new ObservableCollection<string>(db.Users.Where(p => p.Pass == upass && p.Login == ulog).Select(p => p.UserRight).AsParallel());
            return userRight;
        }

        public List<string> UserRight()
        {
            var userRight = db.Users.Select(p => p.UserRight).ToList();
            return userRight;
        }

        public List<string> Fio()
        {
            var fio = db.Users.Select(p => p.FIO).ToList();
            return fio;
        }
        public List<string> Posotion()
        {
            var posotion = db.Users.Select(p => p.Position).ToList();
            return posotion;
        }

        public List<string> Phone()
        {
            var phone = db.Users.Select(p => p.Phone).ToList();
            return phone;
        }
        public List<string> Status()
        {
            var status = db.Users.Select(p => p.Status).ToList();
            return status;
        }
    }
}
