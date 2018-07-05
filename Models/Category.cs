using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Category
    {
        public Category()
        {
            Announce = new HashSet<Announce>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Announce> Announce { get; set; }
    }
}
