namespace LINQ101MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.Product")]
    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Number")]
        public string ProductNumber { get; set; }

        [Display(Name = "Mk. Flg.")]
        public bool MakeFlag { get; set; }

        [Display(Name = "F. Good Flg.")]
        public bool FinishedGoodsFlag { get; set; }

        [StringLength(15)]
        public string Color { get; set; }

        [Display(Name = "Safety Stock L.")]
        public short SafetyStockLevel { get; set; }

        [Display(Name = "Reorder P.")]
        public short ReorderPoint { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Std. Cost")]
        public decimal StandardCost { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Lst. Price")]
        public decimal ListPrice { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        [StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }

        [StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }

        public decimal? Weight { get; set; }

        [Display(Name = "Days to Manufact.")]
        public int DaysToManufacture { get; set; }

        [Display(Name = "Line")]
        [StringLength(2)]
        public string ProductLine { get; set; }

        [StringLength(2)]
        public string Class { get; set; }

        [StringLength(2)]
        public string Style { get; set; }

        [Display(Name = "Sub Category")]
        public int? ProductSubcategoryID { get; set; }

        public int? ProductModelID { get; set; }

        [Display(Name = "Sell Start Date")]
        public DateTime SellStartDate { get; set; }

        [Display(Name = "Sell End Date")]
        public DateTime? SellEndDate { get; set; }

        [Display(Name = "Discont. Date")]
        public DateTime? DiscontinuedDate { get; set; }

        public Guid rowguid { get; set; } = Guid.NewGuid();

        [Display(Name = "Modif. Date")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public ProductSubcategory ProductSubcategory { get; set; }

        // Todo: Add IsDeletable property here with private setter
        /*
         * The property will take a private stored list of 
         * entities in which to check if the current value
         * for he ProductID has occurrences in it, is so
         * the values of this property will be "false"
         */

    }
}
