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
​
namespace CodeCrunch.API.Controllers
{
    public class StudentsController : BaseApiController
    {
        private UserContext db = new UserContext();
​
        // GET: api/Students
        public IQueryable<Student> GetUsers()
        {
            return db.Students;
        }
​
        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(string id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
​
            return Ok(student);
        }
​
        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(string id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
​
            if (id != student.Id)
            {
                return BadRequest();
            }
​
            db.Entry(student).State = EntityState.Modified;
​
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
​
            return StatusCode(HttpStatusCode.NoContent);
        }
​
        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
​
            db.Users.Add(student);
​
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
​
            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }
​
        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(string id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
​
            db.Users.Remove(student);
            db.SaveChanges();
​
            return Ok(student);
        }
​
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
​
        private bool StudentExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}