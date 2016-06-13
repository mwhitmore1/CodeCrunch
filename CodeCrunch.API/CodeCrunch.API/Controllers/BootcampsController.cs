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
using System.Threading.Tasks;
using System.Reflection;

namespace CodeCrunch.API.Controllers
{
    public class BootcampsController : BaseApiController
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

        [HttpGet]
        [Route("api/Bootcamps/Profile")]
        public async Task<IHttpActionResult> GetBootcampProfile()
        {
            string userId = await _repo.GetUserIdAsync();
            if (userId == null)
            {
                return NotFound();
            }

            var bootcamp = db.Bootcamps.First(b => b.Id == userId);
            return Ok(bootcamp);
        }

        // PUT: api/Bootcamps/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/Bootcamps/profile/{id}", Name = "PutCurrentBootcamp")]
        public async Task<IHttpActionResult> PutCurrentBootcamp(string id, BootcampEditForm bootcampEditForm)
        {
            if (bootcampEditForm == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = await _repo.GetUserIdAsync();
            if (userId == null)
            {
                return NotFound();
            }

            if (userId != id)
            {
                return BadRequest();
            }

            var bootcamp = await db.Bootcamps.FirstAsync(b => b.Id == userId);

            bootcamp.BootcampName = bootcampEditForm.BootcampName ?? bootcamp.BootcampName;
            bootcamp.BootcampSite = bootcampEditForm.BootcampSite ?? bootcamp.BootcampSite;
            bootcamp.BootcampCity = bootcampEditForm.BootcampCity ?? bootcamp.BootcampCity;
            bootcamp.BootcampState = bootcampEditForm.BootcampState ?? bootcamp.BootcampState;
            bootcamp.BootcampAddress = bootcampEditForm.BootcampAddress ?? bootcamp.BootcampAddress;
            bootcamp.UserName = bootcampEditForm.UserName ?? bootcamp.UserName;
            bootcamp.Email = bootcampEditForm.Email ?? bootcamp.Email;
            bootcamp.LinkedIn = bootcampEditForm.LinkedIn ?? bootcamp.LinkedIn;

            db.Entry(bootcamp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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