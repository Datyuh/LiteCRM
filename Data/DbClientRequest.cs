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

        public ObservableCollection<string> NamberConToGrid()
        {
            var namberConToGrid = new ObservableCollection<string>(dbClients.Clients.Select(p => p.NamberContract).AsParallel());
            return namberConToGrid;
        }

        public ObservableCollection<string> NameOrgToGrid()
        {
            var nameOrgToGrid = new ObservableCollection<string>(dbClients.Clients.Select(p => p.NameOrg).AsParallel());
            return nameOrgToGrid;
        }

        public ObservableCollection<string> TypeWorkToGrid()
        {
            var typeWorkToGrid = new ObservableCollection<string>(dbClients.Clients.Select(p => p.TypeWork).AsParallel());
            return typeWorkToGrid;
        }

        public ObservableCollection<DateTime> DateEndConToGrid()
        {
            var dateEndConToGrid = new ObservableCollection<DateTime>(dbClients.Clients.Select(p => p.DateEndContract).AsParallel());
            return dateEndConToGrid;
        }
        
        public ObservableCollection<string> StatusConontract()
        {
            var statusConToGrid = new ObservableCollection<string>(dbClients.Clients.Select(p => p.StatusContract).AsParallel());
            return statusConToGrid;
        }
    }
}
