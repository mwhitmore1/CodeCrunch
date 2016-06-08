using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class Language
    {
        // Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId { get; set; }

        // Properties
        public string Name { get; set; }

        // Relationships
        public virtual ICollection<Bootcamp> Bootcamps { get; set; }
    }
}