using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StormCrow.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
