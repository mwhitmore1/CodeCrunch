using CodeCrunch.Core.Domain;
using CodeCrunch.Core.Infrastructure;
using CodeCrunch.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeCrunch.API.Controllers
{
    public class TracksController : ApiController
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TracksController(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            _trackRepository = trackRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tracks
        public IEnumerable<Track> Get()
        {
            return _trackRepository.GetAll();
        }

        // GET: api/Tracks/5
        public Track Get(int id)
        {
            return _trackRepository.GetById(id);
        }

        // POST: api/Tracks
        public void Post(Track track)
        {
            _trackRepository.Add(track);

            _unitOfWork.Commit();
        }

        // PUT: api/Tracks/5
        public void Put(int id, Track track)
        {
            _trackRepository.Update(track);

            _unitOfWork.Commit();
        }

        // DELETE: api/Tracks/5
        public void Delete(int id)
        {
            _trackRepository.Delete(_trackRepository.GetById(id));

            _unitOfWork.Commit();
        }
    }
}
