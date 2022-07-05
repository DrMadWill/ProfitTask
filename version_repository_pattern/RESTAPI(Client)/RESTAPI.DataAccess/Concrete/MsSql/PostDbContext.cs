using Microsoft.EntityFrameworkCore;
using RESTAPI.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTAPI.DataAccess.Concrete.MsSql
{
    public class PostDbContext:DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }

    }
}
