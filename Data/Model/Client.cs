using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiteCRM.Data.Model
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string NamberContract { get; set; }
        [Required]
        public string FIOClient { get; set; }
        [Column]
        public string NameOrg { get; set; }
        [Required]
        public string TypeWork { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public string MobilePhone { get; set; }
        [Required]
        public DateTime? DateStartContract { get; set; }
        [Required]
        public DateTime? DateEndContract { get; set; }
        [Required]
        public double SymmaContract { get; set; }
        [Column]
        public string StatusContract { get; set; }
        [Required]
        public DateTime? RegistrDate { get; set; }

    }
}
