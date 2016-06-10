using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class ModuleForm
    {
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
    }
}
