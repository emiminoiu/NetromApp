using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? UserId { get; set; }
        public int? AnnounceId { get; set; }
        public string Description { get; set; }

        public Announce Announce { get; set; }
        public User User { get; set; }
    }
}
