using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeCrunch.API.Models
{
    public class BootcampRegistrationModel : RegistrationModel
    {
        [Required]
        [Display(Name = "Bootcamp name")]
        [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters")]
        public string BootcampName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters")]
        public string BootcampState { get; set; }
    }
}