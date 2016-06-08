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

namespace CodeCrunch.API.Controllers
{
    public class ModuleQuestionsController : ApiController
    {
        private UserContext db = new UserContext();

        // GET: api/ModuleQuestions
        public IQueryable<ModuleQuestion> GetModuleQuestions()
        {
            return db.ModuleQuestions;
        }

        // GET: api/ModuleQuestions/5
        [ResponseType(typeof(ModuleQuestion))]
        public async Task<IHttpActionResult> GetModuleQuestion(int id)
        {
            ModuleQuestion moduleQuestion = await db.ModuleQuestions.FindAsync(id);
            if (moduleQuestion == null)
            {
                return NotFound();
            }

            return Ok(moduleQuestion);
        }

        // PUT: api/ModuleQuestions/5
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
        public async Task<IHttpActionResult> PostModuleQuestion(ModuleQuestion moduleQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModuleQuestions.Add(moduleQuestion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = moduleQuestion.ModuleQuestionId }, moduleQuestion);
        }

        // DELETE: api/ModuleQuestions/5
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