using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class AnswerFactory
    {
        public ModuleAnswer FormToModel(AnswerForm form, string Id)
        {
            return new ModuleAnswer()
            {
                ModuleQuestionId = form.ModuleQuestionId,
                UserId = Id,
                CreatedDate = DateTime.Now,
                UpVote = 0,
                DownVote = 0,
                Text = form.Text
            };
        }

        public AnswerReturn ModelToReturn(ModuleAnswer a)
        {     
            return new AnswerReturn()
            {
                Text = a.Text,
                UserName = (a.User != null) ? a.User.UserName : HttpContext.Current.User.Identity.Name,
                UpVote = a.UpVote,
                DownVote = a.DownVote,
                CreatedDate = a.CreatedDate
            };
        }
    }
}