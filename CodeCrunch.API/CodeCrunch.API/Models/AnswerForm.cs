using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeCrunch.API.Models
{
    public class AnswerForm
    {
        [Required]
        public int ModuleQuestionId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}