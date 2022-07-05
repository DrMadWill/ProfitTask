using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI_Client_.Data;
using RESTAPI_Client_.Extensions;
using RESTAPI_Client_.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI_Client_.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostDbContext _postDbContext;

        public HomeController(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        // Index | GET
        [HttpGet]
        public async Task<IActionResult> Index(int? index,string search)
        {
            
            IQueryable<Post> postQuery;
            // Check search value
            if (string.IsNullOrEmpty(search))
            {
                postQuery = _postDbContext.Posts.AsQueryable() ;
            }
            else
            {
                // Search Candition
                postQuery = _postDbContext.Posts.Where(post => post.Title.Contains(search)).AsQueryable();
            }
            // My Extension
            var data = await PaginationList<Post>.CreateAsync(postQuery, index ?? 1, 10, "/Home/Index?index=page&search="+search);
            return View(data);
        }

        // UseJavaScript | GET
        public async Task<IActionResult> UseJavaScript()
        {
            // Select all data send Front
            var data = await _postDbContext.Posts.ToListAsync();
            return View(data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
