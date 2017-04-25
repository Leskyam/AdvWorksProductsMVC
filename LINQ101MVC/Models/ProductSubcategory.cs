using System.Data;

namespace LINQ101MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.ProductSubcategory")]
    public partial class ProductSubcategory : IProductSubCategory
    {
        public int ProductSubcategoryID { get; set; }

        [Display(Name = "Category")]
        public int ProductCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid rowguid { get; set; } = Guid.NewGuid();

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public ProductCategory ProductCategory { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }

    public interface IProductSubCategory
    {
        int ProductSubcategoryID { get; set; }

        int ProductCategoryID { get; set; }

        string Name { get; set; }

        Guid rowguid { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
