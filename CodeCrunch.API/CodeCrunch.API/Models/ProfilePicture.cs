using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class ProfilePicture
    {
        // Primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfilePictureId { get; set; }

        // Foreign key
        public string UserId { get; set; }

        // Other fields related to the model
        public string ImageUrl { get; set; }

        // Relationships
        public virtual User User { get; set; }
    }
}