using LiteCRM.Data.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LiteCRM.Data
{
    class DbClientRequest
    {
        ApplicationContext dbClients = new ApplicationContext();

        int dt = DateTime.Now.Month;
       
        public ObservableCollection<int> IdToGrid()
        {
            var idToGrid = new ObservableCollection<int>(dbClients.Clients.Select(p => p.id).AsParallel());
            return idToGrid;
        }
       
        public ObservableCollection<string> NamberConToGrid()
        {
            var namberConToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.NamberContract).AsParallel());
            return namberConToGrid;
        }
       
        public ObservableCollection<string> FIOToGrid()
        {
            var fioToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.FIOClient).AsParallel());
            return fioToGrid;
        }
       
        public ObservableCollection<string> NameOrgToGrid()
        {
            var nameOrgToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.NameOrg).AsParallel());
            return nameOrgToGrid;
        }
       
        public ObservableCollection<string> TypeWorkToGrid()
        {
            var typeWorkToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.TypeWork).AsParallel());
            return typeWorkToGrid;
        }
       
        public ObservableCollection<string> EmailToGrid()
        {
            var emailToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.Email).AsParallel());
            return emailToGrid;
        }
       
        public ObservableCollection<string> PhoneToGrid()
        {
            var phoneToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.Phone).AsParallel());
            return phoneToGrid;
        }
       
        public ObservableCollection<string> MobilPhoneToGrid()
        {
            var mobilPhoneToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.MobilePhone).AsParallel());
            return mobilPhoneToGrid;
        }
        
        public ObservableCollection<DateTime?> DateStartConToGrid()
        {
            var dateStartConToGrid = new ObservableCollection<DateTime?>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.DateStartContract).AsParallel());
            return dateStartConToGrid;
        }
        
        public ObservableCollection<DateTime?> DateEndConToGrid()
        {
            var dateEndConToGrid = new ObservableCollection<DateTime?>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.DateEndContract).AsParallel());
            return dateEndConToGrid;
        }

        public ObservableCollection<double> SymmaConToGrid()
        {
            var symmaConToGrid = new ObservableCollection<double>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.SymmaContract).AsParallel());
            return symmaConToGrid;
        }

        public ObservableCollection<string> StatusConToGrid()
        {
            var statusConToGrid = new ObservableCollection<string>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.StatusContract).AsParallel());
            return statusConToGrid;
        }

        public ObservableCollection<DateTime> RegisterConToGrid()
        {
            var registerConToGrid = new ObservableCollection<DateTime>(dbClients.Clients.Where(p => p.RegistrDate.Month > dt).Select(p => p.RegistrDate).AsParallel());
            return registerConToGrid;
        }

    }
}
