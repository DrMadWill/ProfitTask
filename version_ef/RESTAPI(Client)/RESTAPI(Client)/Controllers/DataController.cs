using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RESTAPI_Client_.Data;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using RESTAPI_Client_.Models;
using Microsoft.Extensions.Configuration;
using RESTAPI_Client_.ViewModels;

namespace RESTAPI_Client_.Controllers
{
    public class DataController : Controller
    {
        private readonly PostDbContext _postDbContext;
        private readonly IConfiguration _configuration;
        public DataController(PostDbContext postDbContext, IConfiguration configuration)
        {
            _postDbContext = postDbContext;
            _configuration = configuration;
        }


        // Index | GET
        public async Task<IActionResult> Index()
        {
            // Post All Data Count
            var postsCount = await _postDbContext.Posts.CountAsync();
            
            DataSeedVM dataSeedVM = new DataSeedVM();
            
            // Check Table Empty
            if (postsCount == 0)
            {
                List<Post> posts = new List<Post>();
                // Connect Api 
                using (var httpClient = new HttpClient())
                {
                    string api = _configuration.GetSection("Apis")["Post"];
                    using var response = await httpClient.GetAsync(api);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    posts = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
                }

                // Data Check
                if (posts.Count > 0)
                {
                    foreach (var item in posts)
                    {
                        item.Id = 0;
                    }

                    await _postDbContext.Posts.AddRangeAsync(posts);
                    await _postDbContext.SaveChangesAsync();
                    dataSeedVM.IsError = false;
                    dataSeedVM.Description = "Success. Data Database Saved";
                }
                else
                {
                    dataSeedVM.IsError = true;
                    dataSeedVM.Description = "Api Not Connected";
                }
            }
            else
            {
                dataSeedVM.IsError = true;
                dataSeedVM.Description = "Already Data Add";
            }
           
            return View(dataSeedVM);
        }
    }
}
