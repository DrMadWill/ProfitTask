using Microsoft.EntityFrameworkCore;
using RESTAPI_Client_.Models;

namespace RESTAPI_Client_.Data
{
    public class PostDbContext:DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
