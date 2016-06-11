using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace CodeCrunch.API.Models
{
    public class BootcampEditForm
    {
        public string BootcampName { get; set; }
        public string BootcampSite { get; set; }
        public string BootcampCity { get; set; }
        [StringLength(2)]
        public string BootcampState { get; set; }
        public string BootcampAddress { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Url)]
        public string LinkedIn { get; set; }
    }
}