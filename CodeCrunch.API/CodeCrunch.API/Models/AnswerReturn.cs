using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class AnswerReturn
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
    }
}