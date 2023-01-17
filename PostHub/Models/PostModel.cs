using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub.Models
{
    public class PostModel
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public ICollection<CommentModel> Comments { get; set; }

    }
}
