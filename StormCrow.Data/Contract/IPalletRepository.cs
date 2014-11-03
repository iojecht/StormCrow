using System.Linq;
using StormCrow.Domain;

namespace StormCrow.Data.Contract
{
    public interface IItemRepository : IRepository<Item>
    {
        IQueryable<Item> GetBySSCC();
    }
}