using CRUDwithWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDwithWebAPI.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options) { 
        
        }
        public DbSet<Product> students { get; set; }
    }
}
