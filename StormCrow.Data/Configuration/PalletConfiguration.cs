using System.Data.Entity.ModelConfiguration;
using StormCrow.Domain;

namespace StormCrow.Data.Configuration
{
    public class PalletConfiguration
        : EntityTypeConfiguration<Pallet>
    {
        public PalletConfiguration()
        {
            HasMany(p => p.Items)
                .WithRequired(p => p.Pallet)
                .HasForeignKey(p => p.SerialShippingContainerCode)
                .WillCascadeOnDelete(false);
        }
    }
}