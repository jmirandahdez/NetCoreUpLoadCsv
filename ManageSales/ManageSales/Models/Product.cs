using System.Collections.Generic;

namespace ManageSales.Models
{
    public class Product : CatalogCommon
    {
        public int ProductSubcategoryID { get; set; }
        public int ProductContainerID { get; set; }
        public double BaseMargin { get; set; }
        public double UnitPrice { get; set; }

        public ProductSubCategory ProductSubCategory { get; set; }
        public ProductContainer ProductContainer { get; set; }
        ICollection<Orders> Orders { get; set; }
    }
}
