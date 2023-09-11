using Microsoft.EntityFrameworkCore;
using MicroService_Comments.Models;

namespace MicroService_Comments.Data
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
           public DbSet<Comment> Comments { get; set; }         
        }
}
