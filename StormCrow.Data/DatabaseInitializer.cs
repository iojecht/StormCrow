﻿using System;
using System.Data.Entity;
using StormCrow.Domain;

namespace StormCrow.Data
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<StormCrowDbContext>
    {
        protected override void Seed(StormCrowDbContext context)
        {
            context.Products.Add(new Product()
            {
                Id = 1, 
                Code = "XXX-XXX-XXX-XX",
                Description = "Product Description 1",
                Name = "XXX-XXX-XXX-XX",
                ShortName = "XXXXXX"
            });

            context.Pallets.Add(new Pallet()
            {
                OwnerOrganizationId = 1,
                BatchCode = "BATCHCODE-XXXXXX",
                ManufactureDate = DateTime.Now,
                ReceiptDate = DateTime.Now,
                SerialShippingContainerCode = 1234567890
            });

            context.Organizations.Add(new Organization()
            {
                Id = 1,
                Name = "Storm Crow Corp"
            });

            var pallet = context.Pallets.Find(1234567890);
            var product = context.Products.Find(1);

            context.Items.Add(new Item()
            {
                Pallet = pallet,
                SerialShippingContainerCode = pallet.SerialShippingContainerCode,
                Product = product,
                ProductId = product.Id,
                CurrentQuantity = 1000,
                OriginalQuantity = 1000
            });
        }
    }
}