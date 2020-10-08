using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiteCRM.BaseWork.Model
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        [Column]
        public string NamberContract { get; set; }
        [Column]
        public string FIOClient { get; set; }
        [Column]
        public string NameOrg { get; set; }
        [Column]
        public string TypeWork { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public string MobilePhone { get; set; }
        [Column]
        public DateTime? DateStartContract { get; set; }
        [Column]
        public DateTime? DateEndContract { get; set; }
        [Column]
        public float? SymmaContract { get; set; }
        [Column]
        public string StatusContract { get; set; }
        [Column]
        public DateTime RegistrDate { get; set; }

    }
}
