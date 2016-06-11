using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CodeCrunch.API.Infrastructure;
using CodeCrunch.API.Models;
using System.Web;

namespace CodeCrunch.API.Controllers
{
    public class ModuleQuestionsController : BaseApiController
    {
        private UserContext db = new UserContext();

        [HttpGet]
        [Route("api/Module/{moduleId}/Questions", Name = "GetQuestionsForModule")]
        public List<QuestionReturn> GetQuestionsForModule(int moduleId)
        {
            var data = db.ModuleQuestions.Where(q => q.ModuleId == moduleId).ToList();

            var result = new List<QuestionReturn>();
            foreach (ModuleQuestion q in data)
            {
                QuestionFactory factory = new QuestionFactory();
                var returnModel = factory.ModelToReturn(q);

                result.Add(returnModel);
            }

            return result;
        }

        [HttpPost]
        [Route("api/Module/{moduleId}/Questions", Name = "PostQuestionsForModule")]
        public async Task<IHttpActionResult> PostQuestionsForModule(QuestionForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the user's id from the token
            string name = HttpContext.Current.User.Identity.Name;
            User user = await _repo.FindUserByName(name);

            QuestionFactory factory = new QuestionFactory();
            ModuleQuestion newQuestion = factory.FormToModel(form, user.Id);

            db.ModuleQuestions.Add(newQuestion);
            await db.SaveChangesAsync();

            QuestionReturn questionReturn = factory.ModelToReturn(newQuestion);

            return CreatedAtRoute("PostQuestionsForModule", new { moduleId = newQuestion.ModuleQuestionId }, questionReturn);
        }

        // PUT: downvote
        [HttpPut]
        [Route("api/Module/{moduleId}/Question/{questionId}/DownVote",
            Name = "DownVoteQuestion")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DownVoteQuestion(int questionId)
        {
            ModuleQuestion question = await db.ModuleQuestions.FindAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }

            question.DownVote++;

            db.Entry(question).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleQuestionExists(questionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: upvote
        [HttpPut]
        [Route("api/Module/{moduleId}/Question/{questionId}/UpVote",
            Name = "UpVoteQuestion")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpVoteQuestion(int questionId)
        {
            ModuleQuestion question = await db.ModuleQuestions.FindAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }

            question.UpVote++;

            db.Entry(question).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleQuestionExists(questionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }



        // GET: api/ModuleQuestions
        public List<QuestionReturn> GetModuleQuestions()
        {
            var data = db.ModuleQuestions.ToList();

            var result = new List<QuestionReturn>();
            foreach (ModuleQuestion q in data)
            {
                QuestionFactory factory = new QuestionFactory();
                var returnModel = factory.ModelToReturn(q);

                result.Add(returnModel);
            }

            return result;
        }
        
        // GET: api/ModuleQuestions/5
        [ResponseType(typeof(QuestionReturn))]
        [Route("api/ModuleQuestions/{id}", Name = "GetModuleQuestion")]
        public async Task<IHttpActionResult> GetModuleQuestion(int id)
        {
            ModuleQuestion moduleQuestion = await db.ModuleQuestions.FindAsync(id);
            if (moduleQuestion == null)
            {
                return NotFound();
            }

            QuestionFactory factory = new QuestionFactory();
            QuestionReturn returnModel = factory.ModelToReturn(moduleQuestion);
            
            return Ok(returnModel);
        }

        // PUT: api/ModuleQuestions/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModuleQuestion(int id, ModuleQuestion moduleQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moduleQuestion.ModuleQuestionId)
            {
                return BadRequest();
            }

            db.Entry(moduleQuestion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleQuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        

        // DELETE: api/ModuleQuestions/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(ModuleQuestion))]
        public async Task<IHttpActionResult> DeleteModuleQuestion(int id)
        {
            ModuleQuestion moduleQuestion = await db.ModuleQuestions.FindAsync(id);
            if (moduleQuestion == null)
            {
                return NotFound();
            }

            db.ModuleQuestions.Remove(moduleQuestion);
            await db.SaveChangesAsync();

            return Ok(moduleQuestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleQuestionExists(int id)
        {
            return db.ModuleQuestions.Count(e => e.ModuleQuestionId == id) > 0;
        }
    }
}