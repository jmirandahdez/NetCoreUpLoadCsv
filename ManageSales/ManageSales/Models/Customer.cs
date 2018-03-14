using System.Collections.Generic;

namespace ManageSales.Models
{
    public class Customer : CatalogCommon
    {
        public int RegionID { get; set; }
        public int SegmentID { get; set; }

        public Region Region { get; set; }
        public Segment Segment { get; set; }
        ICollection<Orders> Orders { get; set; }
    }
}
