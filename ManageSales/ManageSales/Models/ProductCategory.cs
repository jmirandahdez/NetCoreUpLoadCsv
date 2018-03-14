using System.Collections.Generic;

namespace ManageSales.Models
{
    public class ProductCategory : CatalogCommon
    {

        ICollection<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
