using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StormCrow.Domain
{
    public class Pallet
    {
        [Key]
        public int SerialShippingContainerCode { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string BatchCode { get; set; }
        public virtual int OwnerOrganizationId { get; set; }

        public virtual Organization OwnerOrganization { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}