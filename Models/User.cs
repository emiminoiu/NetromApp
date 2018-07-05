using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class User
    {
        public User()
        {
            Announce = new HashSet<Announce>();
            Comment = new HashSet<Comment>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Announce> Announce { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
