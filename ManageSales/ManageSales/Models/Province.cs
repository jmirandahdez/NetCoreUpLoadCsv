using System.Collections.Generic;

namespace ManageSales.Models
{
    public class Province : CatalogCommon
    {

        ICollection<Region> Regions { get; set; }
    }
}
