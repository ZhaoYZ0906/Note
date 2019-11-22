using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
