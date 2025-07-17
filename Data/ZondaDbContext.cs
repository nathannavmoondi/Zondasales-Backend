using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZondaAPI.Models;

namespace ZondaAPI.Data
{
    public class ZondaDbContext : IdentityDbContext
    {
        public ZondaDbContext(DbContextOptions<ZondaDbContext> options) : base(options) { }

        public DbSet<ZondaCustomer> ZondaCustomers { get; set; }
        public DbSet<ZondaProduct> ZondaProducts { get; set; }
    }
} 