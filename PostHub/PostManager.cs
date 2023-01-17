using PostHub.Controllers;
using PostHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub
{
    public class PostManager : IPostManager
    {

        public PostManager PublishPost(PostModel post)
        {

            using (var context = new PostContext())
            {
                post.PublishDate = DateTime.Now;
                context.Posts.Add(post);
                context.SaveChanges();
            }

            return this;
        }

        public PostModel GetPost(int id)
        {
            using (var context = new PostContext())
            {
                return context.Posts.SingleOrDefault(x => x.ID == id);
            }
        }

        public List<PostModel> GetAllPosts()
        {
            using (var context = new PostContext())
            {
                return context.Posts.ToList();
            }
        }

        public PostManager RemovePost(int id)
        {
            using (var context = new PostContext())
            {
                var postToRemove = context.Posts.SingleOrDefault(x => x.ID == id);
                context.Posts.Remove(postToRemove);
                context.SaveChanges();
            }
            return this;
        }

        public PostManager EditPost(PostModel post)
        {

            using (var context = new PostContext())
            {
                context.Posts.Update(post);
                context.SaveChanges();
            }

            return this;
        }
    }
}
