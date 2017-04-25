namespace LINQ101MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.ProductCategory")]
    public partial class ProductCategory : IProductCategory
    {
        public int ProductCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid rowguid { get; set; } = Guid.NewGuid();

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new HashSet<ProductSubcategory>();
    }

    public interface IProductCategory
    {
        int ProductCategoryID { get; set; }

        string Name { get; set; }

        Guid rowguid { get; set; }

        DateTime ModifiedDate { get; set; }
    }

    /*
    public class  ProductCategoryDto : IProductCategory
    {
        public int ProductCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
    */

}
