using LiteCRM.BaseWork.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LiteCRM.BaseWork
{
    class DbUsersRequest
    {
        ApplicationContext db = new ApplicationContext();

        public List<string> LogInUsers()
        {           
            var logInUsers = db.Users.Select(p => p.Login).ToList();
            return logInUsers;
        }

        public List<string> PassUsers()
        {
            var passInUsers = db.Users.Select(p => p.Pass).ToList();
            return passInUsers;
        }
        public List<string> UserRightGetIn(string up, string ul)
        {
            var userRight = db.Users.Where(p => p.Pass == up && p.Login == ul).Select(p => p.UserRight).ToList();
            return userRight;
        }

        public List<string> UserRight()
        {
            var userRight = db.Users.Select(p => p.UserRight).ToList();
            return userRight;
        }

        public List<string> FIO()
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
