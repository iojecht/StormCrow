using System.Data.Entity.ModelConfiguration;
using StormCrow.Domain;

namespace StormCrow.Data.Configuration
{
    public class ItemConfiguration
        : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasKey(a => new {a.SerialShippingContainerCode, a.ProductId});

            HasRequired(p => p.Pallet)
                .WithMany(s => s.Items)
                .HasForeignKey(p => p.SerialShippingContainerCode)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Product)
                .WithMany(s => s.Items)
                .HasForeignKey(p => p.ProductId)
                .WillCascadeOnDelete(false);
                
        }
    }
}