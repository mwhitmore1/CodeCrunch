﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeCrunch.API.Models
{
    public class RegistrationModel
    {
        [Required]
        [Display(Name = "Bootcamp name")]
        [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters")]
        public string BootcampName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The (0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters")]
        public string BootcampState { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters")]
        public string EmailAddress { get; set; }
    }
}