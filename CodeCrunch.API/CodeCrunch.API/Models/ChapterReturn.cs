using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace CodeCrunch.API.Models
{
    public class ChapterReturn
    {
        public int ChapterId { get; set; }

        //Other fields related to model
        public bool CurrentChapter { get; set; }
        public string ChapterName { get; set; }
        public string ChapterDescription { get; set; }
        public int Likes { get; set; }
        public string ChapterContent { get; set; }
    }
}