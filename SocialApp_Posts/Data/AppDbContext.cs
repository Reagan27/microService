using Microsoft.EntityFrameworkCore;
using MicroService_Posts.Models;

namespace MicroService_Posts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }

    }
}
