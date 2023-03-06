﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheBookStore.Models.Authentication
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
