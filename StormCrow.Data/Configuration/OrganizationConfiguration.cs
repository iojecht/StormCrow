using System.Data.Entity.ModelConfiguration;
using StormCrow.Domain;

namespace StormCrow.Data.Configuration
{
    public class OrganizationConfiguration
        : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            HasMany(p => p.Pallets)
                .WithRequired(p => p.OwnerOrganization)
                .HasForeignKey(p => p.OwnerOrganizationId)
                .WillCascadeOnDelete(false);
        }
    }
}