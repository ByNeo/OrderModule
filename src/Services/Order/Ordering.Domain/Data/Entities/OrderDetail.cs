using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ordering.Domain.Data.Entities
{
    [Table("OBOP_ORDER_DETAIL")]
    public class OrderDetail
    {
        [Column("ID")]
        public virtual long Id { get; set; }

        [Column("ORDER_ID")]
        public virtual long OrderId { get; set; }

        [Column("LINE_NUMBER")]
        public virtual string LineNumber { get; set; }

        [Column("ITEM_MASTER_ID")]
        public virtual long ItemMasterId { get; set; }

        [Column("QUANTITY")]
        public virtual int Quantity { get; set; }
    }

}
