using System.Collections.Generic;

namespace ManageSales.Models
{
    public class OrderPriority : CatalogCommon
    {
        
        ICollection<Orders> Orders { get; set; }
    }
}
