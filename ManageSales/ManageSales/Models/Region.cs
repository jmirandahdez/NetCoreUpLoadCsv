using System.Collections.Generic;

namespace ManageSales.Models
{
    public class Region : CatalogCommon
    {
        public int ProvinceID { get; set; }

        public Province Province { get; set; }
        ICollection<Customer> Customers { get; set; }
    }
}
