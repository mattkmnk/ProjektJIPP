using Microsoft.AspNetCore.Mvc;
using PostHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub.Controllers
{
    public class HomePageController : Controller
    {
        private IPostManager postManager;

        public HomePageController(IPostManager manager)
        {
            postManager = manager;
        }

        public IActionResult Index()
        {
            return View(postManager.GetAllPosts());
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(PostModel post)
        {
            postManager.PublishPost(post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RemovePost(int id)
        {
            var post = postManager.GetPost(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult RemovePostConfirmation(int id)
        {
            postManager.RemovePost(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            var post = postManager.GetPost(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult EditPost(PostModel post)
        {
            postManager.EditPost(post);
            return RedirectToAction("Index");
        }

        public IActionResult PostView(int id)
        {
            var post = postManager.GetPost(id);
            return RedirectToAction("DisplayPost", "ViewPost", post);
        }

    }
}
