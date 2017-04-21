using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LINQ101MVC.Controllers;

namespace LINQ101MVC.Models
{
    [Table("Sales.CreditCard")]
    public partial class CreditCard
    {
        public int CreditCardID { get; set; }

        [Required]
        [StringLength(50)]
        public string CardType { get; set; }

        [Required]
        [StringLength(25)]
        public string CardNumber { get; set; }

        public byte ExpMonth { get; set; }

        public short ExpYear { get; set; }

        public DateTime ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage","CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();
    }
}
