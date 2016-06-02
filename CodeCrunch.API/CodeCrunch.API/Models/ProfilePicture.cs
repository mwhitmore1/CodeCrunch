using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class ProfilePicture
    {
        // Primary key.
        public int ProfilePictureId { get; set; }
        public string UserId { get; set; }
        public byte[] Image { get; set; }
    }
}