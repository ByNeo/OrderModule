using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModels
{
    public class OrderDetail
    {
        public virtual long Id { get; set; }

        public virtual long OrderId { get; set; }

        public virtual string LineNumber { get; set; }

        public virtual long ItemMasterId { get; set; }

        public virtual int Quantity { get; set; }
    }
}
