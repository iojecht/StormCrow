using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StormCrow.Domain
{
    public class Item
    {
        [ForeignKey("Pallet")]
        public int SerialShippingContainerCode { get; set; }
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        public virtual Pallet Pallet { get; set; }
    }
}
