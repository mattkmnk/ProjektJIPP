using PostHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub
{
    public class CommentManager : ICommentManager
    {
        public CommentManager PublishPost(CommentModel comment)
        {

            using (var context = new PostContext())
            {
                comment.ID = 0;
                comment.PublishDate = DateTime.Now;
                context.Comments.Add(comment);
                context.SaveChanges();
            }

            return this;
        }

        public List<CommentModel> GetAllCommentsForPost(int id)
        {
            using (var context = new PostContext())
            {
                return context.Comments.Where(x => x.PostModelId == id).ToList();
            }
        }
    }
}
