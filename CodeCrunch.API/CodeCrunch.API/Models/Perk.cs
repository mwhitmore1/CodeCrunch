using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class Perk
    {
        // Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerkId { get; set; }

        // Foreign key
        public string BootcampId { get; set; }

        // Properties
        public string Name { get; set; }

        // Relationship
        public virtual Bootcamp Bootcamp { get; set; }
    }
}