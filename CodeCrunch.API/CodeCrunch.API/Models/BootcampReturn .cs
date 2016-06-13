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
    public class BootcampReturn
    {
        public string Id { get; set;}
        public string BootcampName { get; set; }
        public string BootcampSite { get; set; }
        public string BootcampCity { get; set; }
        public string BootcampState { get; set; }
        public string BootcampAddress { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
    }
}