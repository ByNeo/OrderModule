using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModels
{
    public class Order
    {
        public long Id { get; set; }

        public long AccountId { get; set; }

        public string Number { get; set; }

        public int RevisionNo { get; set; }

        public DateTime Time { get; set; }

        public long OrderTypeId { get; set; }

        public bool? OnHold { get; set; }

        public int? OrderQuantity { get; set; }

        public DateTime? PlannedShipmentTime { get; set; }

        public DateTime? PlannedDeliveryTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
