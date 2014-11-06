using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StormCrow.Domain
{
    public class Item
    {
        public int SerialShippingContainerCode { get; set; }
        public int ProductId { get; set; }

        public double CurrentQuantity { get; set; }
        public double OriginalQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Pallet Pallet { get; set; }
    }
}
