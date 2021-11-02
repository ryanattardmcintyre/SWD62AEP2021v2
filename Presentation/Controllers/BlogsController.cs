using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class BlogsController : Controller
    {
        private IBlogsService blogsService;
        private ICategoriesService categoriesService;
        public BlogsController(IBlogsService _blogsService, ICategoriesService _categoriesService)
        { 
            blogsService = _blogsService;
            categoriesService = _categoriesService;
        }

        public IActionResult Index()
        {
            var list = blogsService.GetBlogs();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        //called before the Add Page is loaded/rendered
        public IActionResult Create()
        {
            var categories = categoriesService.GetCategories();
            ViewBag.Categories = categories;
            //CreateBlogModel myModel = new CreateBlogModel() { Categories = categories };
            return View();
        }
    }
}
