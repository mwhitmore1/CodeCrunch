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

namespace CodeCrunch.API.Controllers
{
    public class BootcampsController : ApiController
    {
        private UserContext db = new UserContext();

        // GET: api/Bootcamps
        public IQueryable<Bootcamp> GetUsers()
        {
            return db.Bootcamps;
        }

        // GET: api/Bootcamps/5
        [ResponseType(typeof(Bootcamp))]
        public IHttpActionResult GetBootcamp(string id)
        {
            Bootcamp bootcamp = db.Bootcamps.Find(id);
            if (bootcamp == null)
            {
                return NotFound();
            }

            return Ok(bootcamp);
        }

        // PUT: api/Bootcamps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBootcamp(string id, Bootcamp bootcamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bootcamp.Id)
            {
                return BadRequest();
            }

            db.Entry(bootcamp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BootcampExists(id))
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

        // POST: api/Bootcamps
        [ResponseType(typeof(Bootcamp))]
        public IHttpActionResult PostBootcamp(Bootcamp bootcamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(bootcamp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BootcampExists(bootcamp.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bootcamp.Id }, bootcamp);
        }

        // DELETE: api/Bootcamps/5
        [ResponseType(typeof(Bootcamp))]
        public IHttpActionResult DeleteBootcamp(string id)
        {
            Bootcamp bootcamp = db.Bootcamps.Find(id);
            if (bootcamp == null)
            {
                return NotFound();
            }

            db.Users.Remove(bootcamp);
            db.SaveChanges();

            return Ok(bootcamp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BootcampExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}