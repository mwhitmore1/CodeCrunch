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

        // POST: api/ModuleQuestions
        [ResponseType(typeof(ModuleQuestion))]
        public async Task<IHttpActionResult> PostModuleQuestion(QuestionForm form)
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

            return CreatedAtRoute("DefaultApi", new { id = newQuestion.ModuleQuestionId }, questionReturn);
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