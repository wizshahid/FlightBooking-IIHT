using System;
using System.ComponentModel.DataAnnotations;
using Utility.Enums;

namespace AuthService.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public Guid Id { get; set; }

        public UserRole UserRole { get; set; }
    }

    public class AuthRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
