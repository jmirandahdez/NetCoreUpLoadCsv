using System.Collections.Generic;

namespace ManageSales.Models
{
    public class ShipMode : CatalogCommon
    {

        ICollection<Orders> Orders { get; set; }
    }
}
