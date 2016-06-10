using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCrunch.API.Models
{
    public class ModelFactory
    {



        // MODULE

        public Module FormToModel(ModuleForm form, string id)
        {
            return new Module()
            {
                BootcampId = id,
                ModuleDescription = form.ModuleDescription,
                ModuleName = form.ModuleName
            };
        }

        public ModuleReturn ModelToReturn(Module module)
        {
            List<QuestionReturn> questionsList = new List<QuestionReturn>();
            foreach(ModuleQuestion q in module.Questions)
            {
                QuestionReturn newReturn = ModelToReturn(q);
                questionsList.Add(newReturn);
            }
            return new ModuleReturn()
            {
                CreatorName = (module.Bootcamp != null) ? module.Bootcamp.UserName : HttpContext.Current.User.Identity.Name,
                Questions = questionsList,
                ModuleName = module.ModuleName,
                Bootcamp = module.Bootcamp
            };
        }

////////MODULEQUESTION

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
                    var newAnswer = ModelToReturn(a);
                    returnAnswers.Add(newAnswer);
                }
            }

            QuestionReturn returnModel = new QuestionReturn()
            {
                ModuleQuestionId = q.ModuleQuestionId,
                Text = q.Text,
                UserName = (q.User != null) ? q.User.UserName : HttpContext.Current.User.Identity.Name,
                UpVote = q.UpVote,
                DownVote = q.DownVote,
                ModuleAnswers = returnAnswers,
                CreatedDate = q.CreatedDate
            };

            return returnModel;
        }

/// ////////////  MODULE ANSWER

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
                UserName = (a.User == null) ? HttpContext.Current.User.Identity.Name : a.User.UserName,
                UpVote = a.UpVote,
                DownVote = a.DownVote,
                CreatedDate = a.CreatedDate
            };
        }
    }
}