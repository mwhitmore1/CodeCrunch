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
    public class ModuleAnswersController : BaseApiController
    {
        private UserContext db = new UserContext();

        // GET: api/ModuleAnswers
        public List<AnswerReturn> GetModuleAnswers()
        {
            var data = db.ModuleAnswers.ToList();

            var result = new List<AnswerReturn>();
            foreach (ModuleAnswer q in data)
            {
                var returnModel = modelFactory.ModelToReturn(q);

                result.Add(returnModel);
            }

            return result;
        }

        // GET: api/ModuleAnswers/5
        [ResponseType(typeof(AnswerReturn))]
        public async Task<IHttpActionResult> GetModuleAnswer(int id)
        {
            ModuleAnswer moduleAnswer = await db.ModuleAnswers.FindAsync(id);
            if (moduleAnswer == null)
            {
                return NotFound();
            }

            AnswerReturn returnModel = modelFactory.ModelToReturn(moduleAnswer);

            return Ok(returnModel);
        }

        // PUT: upvote
        [HttpPut]
        [Route("api/Modules/{moduleId}/Answers/{answerId}/UpVote",
            Name = "UpVoteAnswer")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpVoteAnswer(int answerId)
        {
            ModuleAnswer answer = await db.ModuleAnswers.FindAsync(answerId);
            if (answer == null)
            {
                return NotFound();
            }

            answer.UpVote++;

            db.Entry(answer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleAnswerExists(answerId))
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

        // PUT: downvote
        [HttpPut]
        [Route("api/Modules/{moduleId}/Answers/{answerId}/DownVote",
            Name = "DownVoteAnswer")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DownVoteAnswer(int answerId)
        {
            ModuleAnswer answer = await db.ModuleAnswers.FindAsync(answerId);
            if (answer == null)
            {
                return NotFound();
            }

            answer.DownVote++;

            db.Entry(answer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleAnswerExists(answerId))
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

        // POST: api/ModuleAnswers
        [HttpPost]
        [Route("api/ModuleAnswers", Name = "PostModuleAnswer")]
        [ResponseType(typeof(AnswerReturn))]
        public async Task<IHttpActionResult> PostModuleAnswer(AnswerForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get the user's id from the token
            string name = HttpContext.Current.User.Identity.Name;
            User user = await _repo.FindUserByName(name);

            ModuleAnswer newAnswer = modelFactory.FormToModel(form, user.Id);

            db.ModuleAnswers.Add(newAnswer);
            await db.SaveChangesAsync();

            AnswerReturn answerReturn = modelFactory.ModelToReturn(newAnswer);

            return CreatedAtRoute("PostModuleAnswer", new { id = newAnswer.ModuleAnswerId }, answerReturn);
        }

        // DELETE: api/ModuleAnswers/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(ModuleAnswer))]
        public async Task<IHttpActionResult> DeleteModuleAnswer(int id)
        {
            ModuleAnswer moduleAnswer = await db.ModuleAnswers.FindAsync(id);
            if (moduleAnswer == null)
            {
                return NotFound();
            }

            db.ModuleAnswers.Remove(moduleAnswer);
            await db.SaveChangesAsync();

            return Ok(moduleAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleAnswerExists(int id)
        {
            return db.ModuleAnswers.Count(e => e.ModuleAnswerId == id) > 0;
        }
    }
}