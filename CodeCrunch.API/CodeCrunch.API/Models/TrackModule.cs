using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class TrackModule
    {
        //Composite Key


        //Other fields related to model
        public Chapter Chapter { get; set; }
        public Module Module { get; set; }
    }
}