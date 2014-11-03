using System.Collections.Generic;

namespace StormCrow.Domain
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pallet> Pallets  { get; set; }
    }
}