using System.Collections.Generic;

namespace ManageSales.Models
{
    public class ProductContainer : CatalogCommon
    {

        ICollection<Product> Products { get; set; }
    }
}
