using System;
using System.Data.Entity;
using System.Linq;
using StormCrow.Data.Contract;
using StormCrow.Domain;

namespace StormCrow.Data
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DbContext context) : base(context) { }

        [Obsolete("Item Table has multiple key, please use GetByIds")]
        public override Item GetById(int id)
        {
            return base.GetById(id);
        }

        [Obsolete("Item Table has multiple key, please use other overload")]
        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> GetBySSCC(int id)
        {
            return DbSet.Where(p => p.SerialShippingContainerCode == id);
        }

        public IQueryable<Item> GetByProductId(int id)
        {
            return DbSet.Where(p => p.ProductId == id);
        }

        public Item GetByIds(int sscc, int productId)
        {
            return DbSet.FirstOrDefault(p => p.SerialShippingContainerCode == sscc && p.ProductId == productId);
        }

        public void Delete(int sscc, int productId)
        {
            var entity = GetByIds(sscc,productId);
            if (entity == null) return;
            Delete(entity);
        }
    }
}