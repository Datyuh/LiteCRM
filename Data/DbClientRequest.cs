using LiteCRM.BaseWork.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteCRM.BaseWork
{
    class DbClientRequest
    {
        ApplicationContext dbClients = new ApplicationContext();

        int dt = DateTime.Now.Month;
        public List<int> IdToGrid()
        {
            var idToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.id).ToList();
            return idToGrid;
        }
        public List<string> NamberConToGrid()
        {
            var namberConToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.NamberContract).ToList();
            return namberConToGrid;
        }
        public List<string> FIOToGrid()
        {
            var fioToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.FIOClient).ToList();
            return fioToGrid;
        }
        public List<string> NameOrgToGrid()
        {
            var nameOrgToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.NameOrg).ToList();
            return nameOrgToGrid;
        }
        public List<string> TypeWorkToGrid()
        {
            var typeWorkToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.TypeWork).ToList();
            return typeWorkToGrid;
        }
        public List<string> EmailToGrid()
        {
            var emailToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.Email).ToList();
            return emailToGrid;
        }
        public List<string> PhoneToGrid()
        {
            var phoneToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.Phone).ToList();
            return phoneToGrid;
        }
        public List<string> MobilPhoneToGrid()
        {
            var mobilPhoneToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.MobilePhone).ToList();
            return mobilPhoneToGrid;
        }
        public List<DateTime?> DateStartConToGrid()
        {
            var dateStartConToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.DateStartContract).ToList();
            return dateStartConToGrid;
        }
        public List<DateTime?> DateEndConToGrid()
        {
            var dateEndConToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.DateEndContract).ToList();
            return dateEndConToGrid;
        }
        public List<float?> SymmaConToGrid()
        {
            var symmaConToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.SymmaContract).ToList();
            return symmaConToGrid;
        }
        public List<string> StatusConToGrid()
        {
            var statusConToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.StatusContract).ToList();
            return statusConToGrid;
        }
        public List<DateTime> RegisterConToGrid()
        {
            var registerConToGrid = dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.RegistrDate);
            return (List<DateTime>)registerConToGrid;
        }

    }
}
