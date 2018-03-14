using System.Collections.Generic;

namespace ManageSales.Models
{
    public class ProductSubCategory : CatalogCommon
    {
        public int ProductCategoryID { get; set; }

        public ProductCategory ProductCategory { get; set; }
        ICollection<Product> Products { get; set; }
    }
}
