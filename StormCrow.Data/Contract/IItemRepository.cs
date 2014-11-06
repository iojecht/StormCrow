using System.Linq;
using StormCrow.Domain;

namespace StormCrow.Data.Contract
{
    public interface IItemRepository : IRepository<Item>
    {
        IQueryable<Item> GetBySSCC(int id);
        IQueryable<Item> GetByProductId(int id);
        Item GetByIds(int sscc, int productId);
        void Delete(int sscc, int productId);
    }
}