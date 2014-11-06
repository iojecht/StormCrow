using System.Data.Entity.ModelConfiguration;
using StormCrow.Domain;

namespace StormCrow.Data.Configuration
{
    public class ProductConfiguration
        : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Code).IsRequired();
        }
    }
}