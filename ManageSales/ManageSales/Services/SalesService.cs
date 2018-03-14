using System;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;
using ManageSales.Data;
using ManageSales.Models;
using Microsoft.Extensions.Logging;

namespace ManageSales.Services
{
    public class SalesService : ISaleServices
    {
        private readonly SalesContext _context;
        private readonly ILogger _logger;

        public SalesService(SalesContext context, ILogger<SalesService> logger){
            this._context = context;
            this._logger = logger;
        }

        public void SaveData(Stream stream)
        {
            using (CsvReader csv = new CsvReader(new StreamReader(stream), true))
            {
                int fieldCount = csv.FieldCount;

                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    var order = ParseData(headers, csv, fieldCount);
                    this._context.Orders.Add(order);
                    this._context.SaveChanges();
                }
            }
        }

        private Orders ParseData(string[] headers, CsvReader csv, int fieldCount){

            var order = new Orders();
            var customer = new Customer();
            var product = new Product();
            var province = new Province();
            var region = new Region();
            var segment = new Segment();
            var productCategory = new ProductCategory();
            var productSubCategory = new ProductSubCategory();
            var productContainer = new ProductContainer();

            for (int i = 0; i < fieldCount; i++)
            {
                try
                {
                    switch (headers[i])
                    {
                        case "Row ID":
                            break;
                        case "Order ID":
                            order.OrdersID = Int32.Parse(csv[i]);
                            break;
                        case "Order Date":
                            order.OrderDate = DateTime.Parse(csv[i]);
                            break;
                        case "Order Priority":
                            var orderPriority = this._context.OrderPriorities.Where(x => x.Name.Equals(csv[i])).FirstOrDefault<OrderPriority>();
                            if (orderPriority != null)
                            {
                                order.OrderPriorityID = orderPriority.ID;
                            }
                            else
                            {
                                order.OrderPriority = new OrderPriority{ Name = csv[i] };
                            }
                            break;
                        case "Order Quantity":
                            order.OrderQuantity = Double.Parse(csv[i]);
                            break;
                        case "Sales":
                            order.Sales = Double.Parse(csv[i]);
                            break;
                        case "Discount":
                            order.Discount = Double.Parse(csv[i]);
                            break;
                        case "Ship Mode":
                            var shipMode = this._context.ShipModes.Where(x => x.Name.Equals(csv[i])).FirstOrDefault<ShipMode>();
                            if (shipMode != null)
                            {
                                order.ShipModeID = shipMode.ID;
                            }
                            else
                            {
                                order.ShipMode = new ShipMode(){ Name = csv[i] };
                            }
                            break;
                        case "Profit":
                            order.Profit = Double.Parse(csv[i]);
                            break;
                        case "Unit Price":
                            product.UnitPrice = Double.Parse(csv[i]);
                            break;
                        case "Shipping Cost":
                            order.ShippingCost = Double.Parse(csv[i]);
                            break;
                        case "Customer Name":
                            customer.Name = csv[i];
                            break;
                        case "Province":
                            province.Name = csv[i];
                            break;
                        case "Region":
                            region.Name = csv[i];
                            break;
                        case "Customer Segment":
                            segment.Name = csv[i];
                            break;
                        case "Product Category":
                            productCategory.Name = csv[i];
                            break;
                        case "Product Sub-Category":
                            productSubCategory.Name = csv[i];
                            break;
                        case "Product Name":
                            product.Name = csv[i];
                            break;
                        case "Product Container":
                            productContainer.Name = csv[i];
                            break;
                        case "Product Base Margin":
                            product.BaseMargin = Double.Parse(csv[i]);
                            break;
                        case "Ship Date":
                            order.ShipDate = DateTime.Parse(csv[i]);
                            break;
                    }
                }catch(Exception ex){
                    this._logger.LogWarning(string.Format("{0} - {1}", ex.Message, csv[i]));
                }
            }

            var productCategoryVal = this._context.ProductCategories.Where(x => x.Name.Equals(productCategory.Name)).FirstOrDefault<ProductCategory>();
            if(productCategoryVal != null){
                productSubCategory.ProductCategoryID = productCategoryVal.ID;
            }else{
                productSubCategory.ProductCategory = productCategory;    
            }

            var productSubCategoryVal = this._context.ProductSubCategories.Where(x => x.Name.Equals(productSubCategory.Name)).FirstOrDefault<ProductSubCategory>();
            if (productSubCategoryVal != null)
            {
                product.ProductSubcategoryID = productSubCategoryVal.ID;
            }
            else
            {
                product.ProductSubCategory = productSubCategory;
            }

            var productContainerVal = this._context.ProductContainers.Where(x => x.Name.Equals(productContainer.Name)).FirstOrDefault<ProductContainer>();
            if (productContainerVal != null)
            {
                product.ProductContainerID = productContainerVal.ID;
            }
            else
            {
                product.ProductContainer = productContainer;
            }

            var provinceVal = this._context.Provinces.Where(x => x.Name.Equals(province.Name)).FirstOrDefault<Province>();
            if (provinceVal != null)
            {
                region.ProvinceID = provinceVal.ID;
            }
            else
            {
                region.Province = province;
            }

            var segmentVal = this._context.Segments.Where(x => x.Name.Equals(segment.Name)).FirstOrDefault<Segment>();
            if (segmentVal != null)
            {
                customer.SegmentID = segmentVal.ID;
            }
            else
            {
                customer.Segment = segment;
            }

            var regionVal = this._context.Regions.Where(x => x.Name.Equals(segment.Name)).FirstOrDefault<Region>();
            if (regionVal != null)
            {
                customer.RegionID = regionVal.ID;
            }
            else
            {
                customer.Region = region;
            }

            var customerVal = this._context.Customers.Where(x => x.Name.Equals(customer.Name)).FirstOrDefault<Customer>();
            if (customerVal != null)
            {
                order.CustomerID = customerVal.ID;
            }
            else
            {
                order.Customer = customer;
            }

            var productVal = this._context.Products.Where(x => x.Name.Equals(product.Name)).FirstOrDefault<Product>();
            if (productVal != null)
            {
                order.ProductID = productVal.ID;
            }
            else
            {
                order.Product = product;
            }

            return order;
        }
    }
}
