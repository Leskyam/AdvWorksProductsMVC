using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LINQ101MVC.Controllers;

namespace LINQ101MVC.Models
{
    [Table("Sales.Customer")]
    public partial class Customer
    {
        public int CustomerID { get; set; }

        public int? PersonID { get; set; }

        public int? StoreID { get; set; }

        public int? TerritoryID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [StringLength(10)]
        public string AccountNumber { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage","CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();
    }
}
