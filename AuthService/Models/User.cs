using System;
using Utility.Enums;

namespace AuthService.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
