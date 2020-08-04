using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventMessagingDemo.Models
{
    public class OrderModel
    {
        public long OrderId { get; set; }
        public string ProductName { get; set; }       
        public long Quantity { get; set; }
        public string Status { get; set; } = "Ordered";
    }
}
