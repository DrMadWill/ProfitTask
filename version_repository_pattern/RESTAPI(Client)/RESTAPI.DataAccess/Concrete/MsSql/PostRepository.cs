using RESTAPI.DataAccess.Abstract;
using RESTAPI.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPI.DataAccess.Concrete.MsSql
{
    public class PostRepository :BaseRepository<Post,PostDbContext>, IPostRepository
    {
        public PostRepository(PostDbContext dbContext):base(dbContext) { }

    }
}
