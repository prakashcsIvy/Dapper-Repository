using System;
using System.Collections.Generic;
using System.Text;

namespace DWC.Models.Models
{
    public class Common_Model
    {
        public List<KeyValueEntity> keyValues { get; set; }
    }
    public class KeyValueEntity
    {
        public int Key { get; set; }
        public string Values { get; set; }
    }

    public class ProductsDataModel
    {
        public List<KeyValueEntity> VendorList;
    }

    public class Product
    {
        public int ProductId { get; set; }
    }

    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceItemName { get; set; }
    }

    public class Invoice
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public string InvoiceName { get; set; }
    }

    public class AccessDetailsDataModel
    {
    }
}
