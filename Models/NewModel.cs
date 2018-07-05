using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NewModel { 
    
    public NewModel()
    {
        Comment = new HashSet<Comment>();
    }
        public int AnnounceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpiringDate { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public IFormFile Poza { get; set; }
        public string NumeleCategoriei { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
