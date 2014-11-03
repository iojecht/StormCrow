using System;
using System.Data.Entity;
using StormCrow.Domain;

namespace StormCrow.Data
{
    public class StormCrowDatabaseInitializer : DropCreateDatabaseIfModelChanges<StormCrowDbContext>
    {
        protected override void Seed(StormCrowDbContext context)
        {
            context.Products.Add(
            new Product()
            {
                Id = 1, 
                Description = "Product Description 1",
                Name = "XXX-XXX-XXX-XX",
                ShortName = "XXXXXX"
            });

            context.Items.Add(new Item()
            {
                SerialShippingContainerCode = 1234567890,
                ProductId = 1, 
                //BatchCode = "BATCHCODE-XXXXXX", 
                Product = context.Products.Find(1),
                //ReceiptDate = DateTime.Now,
            });

            context.Pallets.Add(new Pallet()
            {
                OwnerOrganizationId = 1,
                BatchCode = "BATCHCODE-XXXXXX",
                ManufactureDate = DateTime.Now,
                ReceiptDate = DateTime.Now,
                SerialShippingContainerCode = 1234567890
            });
        }
    }
}