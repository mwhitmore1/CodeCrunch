using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CodeCrunch.API.Infrastructure;
using CodeCrunch.API.Models;
using System.Web;
using System.Threading.Tasks;

namespace CodeCrunch.API.Controllers
{
    public class ModulesController : BaseApiController
    {
        private UserContext db = new UserContext();

        // GET: api/Modules
        public IEnumerable<Module> GetModules()
        {
            return db.Modules.ToList();
        }

        [Route("api/Modules/CurrentUser", Name = "GetCurrentUserModules")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCurrentUserModules()
        {
            string userId = await _repo.GetUserIdAsync();
            if (userId == null)
            {
                return NotFound();
            }

            List<Module> modules = db.Modules.Where(m => (m.BootcampId == userId)).ToList();
            var moduleReturns = new List<Object>(); 
            foreach(Module m in modules)
            {
                List<Object> chapterReturns = new List<Object>();
                foreach (Chapter c in m.Chapters)
                {
                    Object newChapter = new
                    {
                        ChapterId = c.ChapterId,
                        ChapterName = c.ChapterName,
                        ChapterContent = c.ChapterContent,
                        ChapterDescription = c.ChapterDescription
                    };

                    chapterReturns.Add(newChapter);
                }

                object returnModule = new
                {
                    ModuleName = m.ModuleName,
                    ModuleId = m.ModuleId,
                    ModuleDescription = m.ModuleDescription,
                    Chapters = chapterReturns
                };

                moduleReturns.Add(returnModule);
            }

            return Ok(moduleReturns);
        }

        // GET: api/Modules/5
        [ResponseType(typeof(Module))]
        public IHttpActionResult GetModule(int id)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // PUT: api/Modules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModule(int id, Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != module.ModuleId)
            {
                return BadRequest();
            }

            db.Entry(module).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/Modules
        [ResponseType(typeof(Module))]
        public IHttpActionResult PostModule(Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modules.Add(module);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = module.ModuleId }, module);
        }

        // DELETE: api/Modules/5
        [ResponseType(typeof(Module))]
        public IHttpActionResult DeleteModule(int id)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }

            db.Modules.Remove(module);
            db.SaveChanges();

            return Ok(module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleExists(int id)
        {
            return db.Modules.Count(e => e.ModuleId == id) > 0;
        }
    }
}