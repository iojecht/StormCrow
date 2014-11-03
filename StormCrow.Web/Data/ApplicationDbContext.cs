using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StormCrow.Domain;

namespace StormCrow.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
            
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}