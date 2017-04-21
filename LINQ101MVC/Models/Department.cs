using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ101MVC.Models
{
    [Table("HumanResources.Department")]
    public partial class Department
    {
        public short DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
