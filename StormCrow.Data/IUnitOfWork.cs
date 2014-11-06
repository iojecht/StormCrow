using StormCrow.Data.Contract;
using StormCrow.Domain;

namespace StormCrow.Data
{
    public interface IUnitOfWork
    {
        void Commit();

        IRepository<Organization> Organizations { get; }
        IRepository<Product> Products { get; }
        IRepository<Pallet> Pallets { get; }
        IItemRepository Items { get; }
    }
}