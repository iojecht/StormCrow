using System.Data.Entity.ModelConfiguration;
using StormCrow.Domain;

namespace StormCrow.Data.Configuration
{
    public class PalletConfiguration
        : EntityTypeConfiguration<Pallet>
    {
        public PalletConfiguration()
        {
            HasRequired(p => p.OwnerOrganization)
                .WithMany(s => s.Pallets)
                .HasForeignKey(p => p.OwnerOrganizationId)
                .WillCascadeOnDelete(false);
        }
    }
}