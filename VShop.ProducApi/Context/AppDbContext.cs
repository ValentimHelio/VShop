using Microsoft.EntityFrameworkCore;
using VShop.ProducApi.Models;

namespace VShop.ProducApi.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Category> Categores { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
