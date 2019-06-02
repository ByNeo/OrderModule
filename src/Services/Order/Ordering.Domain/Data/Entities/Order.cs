using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ordering.Domain.Data.Entities
{
    [Table("OBOP_ORDER")]
    public class Order
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("ACCOUNT_ID")]
        public long AccountId { get; set; }

        [Column("NUMBER")]
        public string Number { get; set; }

        [Column("REVISION_NO")]
        public int RevisionNo { get; set; }

        [Column("TIME", TypeName = "datetime")]
        public DateTime Time { get; set; }

        [Column("ORDER_TYPE_ID")]
        public long OrderTypeId { get; set; }

        [Column("ON_HOLD")]
        public bool? OnHold { get; set; }

        [Column("ORDER_QUANTITY")]
        public int? OrderQuantity { get; set; }

        [Column("PLANNED_SHIPMENT_TIME", TypeName = "datetime")]
        public DateTime? PlannedShipmentTime { get; set; }

        [Column("PLANNED_DELIVERY_TIME", TypeName = "datetime")]
        public DateTime? PlannedDeliveryTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
