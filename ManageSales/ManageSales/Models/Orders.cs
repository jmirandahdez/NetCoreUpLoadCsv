using System;

namespace ManageSales.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int OrdersID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderPriorityID { get; set; }
        public double OrderQuantity { get; set; }
        public double Sales { get; set; }
        public double Discount { get; set; }
        public int ShipModeID { get; set; }
        public double Profit { get; set; }
        public double ShippingCost { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime ShipDate { get; set; }

        public OrderPriority OrderPriority { get; set; }
        public Product Product { get; set; }
        public ShipMode ShipMode { get; set; }
        public Customer Customer { get; set; }
    }
}
