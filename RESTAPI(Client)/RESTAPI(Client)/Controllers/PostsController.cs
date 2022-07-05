using Microsoft.AspNetCore.Mvc;
using RESTAPI_Client_.Data;
using System.Threading.Tasks;

namespace RESTAPI_Client_.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostDbContext _postDbContext;
        public PostsController(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

       
    }
}
