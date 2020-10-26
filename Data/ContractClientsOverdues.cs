using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LiteCRM.Data.Context;
using LiteCRM.Data.Model;
using LiteCRM.ViewModels.Base;

namespace LiteCRM.Data
{
    public class ContractClientsOverdues : BaseViewModel
    {
        
        public string NamberContracts { get; set; }
        
        public string NamaeOrgsnization { get; set; }

        public string TypeWorks { get; set; }

        public DateTime DateEndContracts { get; set; }

        public string StatysContract { get; set; }

        public int DayOverdue { get; set; }


    }
}