using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class QuestionFactory
    {
        public ModuleQuestion FormToModel(QuestionForm form, string Id)
        {
            return new ModuleQuestion()
            {
                ModuleId = form.ModuleId,
                UserId = Id,
                CreatedDate = DateTime.Now,
                UpVote = 0,
                DownVote = 0,
                Text = form.Text
            };
        }

        public QuestionReturn ModelToReturn(ModuleQuestion q)
        {
            List<AnswerReturn> returnAnswers = new List<AnswerReturn>();

            if (q.ModuleAnswers != null)
            {
                foreach (ModuleAnswer a in q.ModuleAnswers)
                {
                    var newAnswer = new AnswerReturn()
                    {
                        Text = a.Text,
                        UserName = a.User.UserName,
                        UpVote = a.UpVote,
                        DownVote = a.DownVote,
                        CreatedDate = a.CreatedDate
                    };

                    returnAnswers.Add(newAnswer);
                }
            }
            
            QuestionReturn returnModel = new QuestionReturn()
            {
                Text = q.Text,
                UserName = (q.User != null) ? q.User.UserName : HttpContext.Current.User.Identity.Name,
                UpVote = q.UpVote,
                DownVote = q.DownVote,
                ModuleAnswers = returnAnswers,
                CreatedDate = q.CreatedDate
            };

            return returnModel;
        }
    }
}