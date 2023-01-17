using PostHub.Models;
using System.Collections.Generic;

namespace PostHub.Controllers
{
    public interface IPostManager
    {
        public PostManager PublishPost(PostModel post);

        public PostModel GetPost(int id);

        public List<PostModel> GetAllPosts();

        public PostManager RemovePost(int id);

        public PostManager EditPost(PostModel post);
    }
}