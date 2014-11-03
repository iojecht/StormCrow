using System.Data.Entity;
using System.Linq;
using StormCrow.Data.Contract;
using StormCrow.Domain;

namespace StormCrow.Data
{
    public class ItemRepository : StormCrowRepository<Item>, IItemRepository
    {
        public ItemRepository(DbContext context) : base(context) { }

        public IQueryable<Item> GetBySSCC()
        {
            throw new System.NotImplementedException();
        }
    }
}