using CodeCrunch.Core.Domain;
using CodeCrunch.Core.Infrastructure;
using CodeCrunch.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CodeCrunch.API.Controllers
{
    public class ModulesController : ApiController
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ModulesController(IModuleRepository moduleRepository, IUnitOfWork unitOfWork)
        {
            _moduleRepository = moduleRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Modules
        public IEnumerable<Module> GetModules()
        {
            return _moduleRepository.GetAll();
        }

        // GET: api/Modules/5
        [ResponseType(typeof(Module))]
        public IHttpActionResult GetModule(int id)
        {
            Module module = _moduleRepository.GetById(id);
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

            _moduleRepository.Update(module);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
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

            _moduleRepository.Add(module);
            _unitOfWork.Commit();

            return CreatedAtRoute("DefaultApi", new { id = module.ModuleId }, module);
        }

        // DELETE: api/Modules/5
        [ResponseType(typeof(Module))]
        public IHttpActionResult DeleteModule(int id)
        {
            Module module = _moduleRepository.GetById(id);
            if (module == null)
            {
                return NotFound();
            }

            _moduleRepository.Delete(module);
            _unitOfWork.Commit();

            return Ok(module);
        }

        private bool ModuleExists(int id)
        {
            return _moduleRepository.Any(e => e.ModuleId == id);
        }
    }
}