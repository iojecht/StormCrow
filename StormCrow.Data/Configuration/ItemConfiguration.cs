using System.Data.Entity.ModelConfiguration;
using StormCrow.Domain;

namespace StormCrow.Data.Configuration
{
    public class ItemConfiguration
        : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasKey(p => new {p.SerialShippingContainerCode, p.ProductId});

            HasRequired(p => p.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.ProductId)
                .WillCascadeOnDelete(false);
                
            HasRequired(p => p.Pallet)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.SerialShippingContainerCode)
                .WillCascadeOnDelete(false);
        }
    }
}