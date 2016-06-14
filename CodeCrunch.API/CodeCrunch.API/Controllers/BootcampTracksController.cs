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

namespace CodeCrunch.API.Controllers
{   [Authorize]
     
    public class BootcampTracksController : BaseApiController
    {
        private UserContext db = new UserContext();

        // GET: api/Tracks
        [Route("api/bootcamp/tracks")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTracks()
        {
            string userId = await _repo.GetUserIdAsync();
            if (userId == null)
            {
                return NotFound();
            }
           var result = db.Tracks.Where(t => (t.BootcampId == userId)).ToList();
            return Ok(result);
        }

        // GET: api/Tracks/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult GetTrack(int id)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        // PUT: api/Tracks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrack(int id, Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.TrackId)
            {
                return BadRequest();
            }

            db.Entry(track).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/Tracks
        [ResponseType(typeof(Track))]
        public IHttpActionResult PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tracks.Add(track);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = track.TrackId }, track);
        }

        // DELETE: api/Tracks/5
        [ResponseType(typeof(Track))]
        public IHttpActionResult DeleteTrack(int id)
        {
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return NotFound();
            }

            db.Tracks.Remove(track);
            db.SaveChanges();

            return Ok(track);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackExists(int id)
        {
            return db.Tracks.Count(e => e.TrackId == id) > 0;
        }
    }
}