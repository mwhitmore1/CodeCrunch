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
    public class ModuleAnswersController : ApiController
    {
        private UserContext db = new UserContext();

        // GET: api/ModuleAnswers
        public IQueryable<ModuleAnswer> GetModuleAnswers()
        {
            return db.ModuleAnswers;
        }

        // GET: api/ModuleAnswers/5
        [ResponseType(typeof(ModuleAnswer))]
        public async Task<IHttpActionResult> GetModuleAnswer(int id)
        {
            ModuleAnswer moduleAnswer = await db.ModuleAnswers.FindAsync(id);
            if (moduleAnswer == null)
            {
                return NotFound();
            }

            return Ok(moduleAnswer);
        }

        // PUT: api/ModuleAnswers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModuleAnswer(int id, ModuleAnswer moduleAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moduleAnswer.ModuleAnswerId)
            {
                return BadRequest();
            }

            db.Entry(moduleAnswer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleAnswerExists(id))
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
        [ResponseType(typeof(ModuleAnswer))]
        public async Task<IHttpActionResult> PostModuleAnswer(ModuleAnswer moduleAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModuleAnswers.Add(moduleAnswer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = moduleAnswer.ModuleAnswerId }, moduleAnswer);
        }

        // DELETE: api/ModuleAnswers/5
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