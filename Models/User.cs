using System;

namespace EasyEv3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        // Plain-text password (insecure) — project preference
        public string Password { get; set; } = "";
        public UserRole Role { get; set; } = UserRole.User;
        public DateTime CreatedAt { get; set; }
    }
}