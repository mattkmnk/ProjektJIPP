using PostHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub
{
    public interface ICommentManager
    {
        public CommentManager PublishPost(CommentModel comment);

        public List<CommentModel> GetAllCommentsForPost(int id);
    }
}
