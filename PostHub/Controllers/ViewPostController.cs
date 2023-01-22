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
        private readonly IPostManager postManager;
        private readonly ICommentManager commentManager;

        public ViewPostController(ICommentManager cmanager, IPostManager pmanager)
        {
            commentManager = cmanager;
            postManager = pmanager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "HomePage");
        }

        [HttpGet]
        public IActionResult DisplayPost(int id)
        {
            ViewBag.Comments = commentManager.GetAllCommentsForPost(id);
            var post = postManager.GetPost(id);
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
            return RedirectToAction("DisplayPost", new { id = comment.PostModelId });
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
            return RedirectToAction("Index", "HomePage");
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
            return RedirectToAction("DisplayPost", new { id = post.ID });
        }
    }
}
