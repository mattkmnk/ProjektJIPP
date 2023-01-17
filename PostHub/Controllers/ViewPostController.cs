using Microsoft.AspNetCore.Mvc;
using PostHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub.Controllers
{
    public class ViewPostController : Controller
    {
        private IPostManager postManager;
        public CommentManager commentManager = new CommentManager();

        public ViewPostController(IPostManager manager)
        {
            postManager = manager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "HomePage");
        }

        [HttpGet]
        public IActionResult DisplayPost(PostModel post)
        {
            var postId = post.ID;
            ViewBag.Comments = commentManager.GetAllCommentsForPost(postId);
            return View(post);
        }

        [HttpGet]
        public IActionResult CreateComment(PostModel post)
        {
            ViewBag.PostID = post.ID;
            return View();
        }

        [HttpPost]
        public IActionResult CreateComment(CommentModel comment)
        {
            commentManager.PublishPost(comment);
            return RedirectToAction($"DisplayPost");
        }
    }
}
