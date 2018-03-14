using System.Collections.Generic;

namespace ManageSales.Models
{
    public class Segment : CatalogCommon
    {

        ICollection<Customer> Customers { get; set; }
    }
}
