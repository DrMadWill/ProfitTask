using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using RESTAPI_Client_.Models;
using Microsoft.Extensions.Configuration;
using RESTAPI_Client_.ViewModels;
using RESTAPI.Entity.Models;
using RESTAPI.DataAccess.Abstract;

namespace RESTAPI_Client_.Controllers
{
    public class DataController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IConfiguration _configuration;
        public DataController(IPostRepository postRepository, IConfiguration configuration)
        {
            _postRepository = postRepository;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var postsCount = await _postRepository.GetCount();
            DataSeedVM dataSeedVM = new DataSeedVM();
            if (postsCount == 0)
            {
                List<Post> posts;
                using (var httpClient = new HttpClient())
                {
                    string api = _configuration.GetSection("Apis")["Post"];
                    using var response = await httpClient.GetAsync(api);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    posts = JsonConvert.DeserializeObject<List<Post>>(apiResponse);
                }


                if (posts.Count > 0)
                {
                    foreach (var item in posts)
                    {
                        item.Id = 0;
                    }

                    var resault = await _postRepository.CreateByAddRange(posts);
                    if(resault)
                    {
                        dataSeedVM.IsError = false;
                        dataSeedVM.Description = "Success. Data Database Saved";
                    }
                    else
                    {
                        dataSeedVM.IsError = true;
                        dataSeedVM.Description = "Database Error";
                    }
                   
                    
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
