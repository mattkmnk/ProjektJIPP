using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub.Models
{
    public class CommentModel
    {

        public int ID { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public int PostModelId { get; set; }

    }
}
