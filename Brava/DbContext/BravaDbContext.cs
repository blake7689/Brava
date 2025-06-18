using Brava.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Brava.DbContext
{
    public class BravaDbContext : IdentityDbContext
    {
        public BravaDbContext(DbContextOptions<BravaDbContext> options) : base(options)
        {
        }

        public DbSet<Gummie> Gummies { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<FAQItem> FAQItems { get; set; }
        public DbSet<FAQCategory> FAQCategories { get; set; }
    }
}
