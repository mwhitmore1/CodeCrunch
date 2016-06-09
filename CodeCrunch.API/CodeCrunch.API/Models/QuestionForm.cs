using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeCrunch.API.Models
{
    public class QuestionForm
    {
        [Required]
        public int ModuleId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}