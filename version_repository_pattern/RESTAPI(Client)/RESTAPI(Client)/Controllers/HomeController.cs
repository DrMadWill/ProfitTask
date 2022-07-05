﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RESTAPI.DataAccess.Abstract;
using RESTAPI.Entity.Models;
using RESTAPI_Client_.Extensions;
using RESTAPI_Client_.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI_Client_.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _postRepository;

        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index(int? index,string search)
        {

            IQueryable<Post> postQuery;
            if (string.IsNullOrEmpty(search))
            {
                postQuery = _postRepository.GetAllQuery() ;
            }
            else
            {
                postQuery = _postRepository.GetAllQuery().Where(post => post.Title.Contains(search)).AsQueryable();
            }
                    
            var data = await PaginationList<Post>.CreateAsync(postQuery, index ?? 1, 10, "/Home/Index?index=page&search="+search);
            return View(data);
        }

        public async Task<IActionResult> UseJavaScript()
        {

            var data = await _postRepository.GetAll();
            return View(data);
        }

        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
