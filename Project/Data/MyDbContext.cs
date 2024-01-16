using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DTO;
using Project.Models;

namespace Project.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<RoleStore> roleStores { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<OwnerData> ownerdatas {get; set ;}

    }
}
