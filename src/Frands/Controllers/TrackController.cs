using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Frands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Frands.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class TrackController : Controller
    {
        private FrandsDbContext _context;

        public TrackController(FrandsDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery] int TrackId, [FromQuery] int ListenerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Track> tracks = from track in _context.Track
                                     select new Track
                                     {
                                         TrackId = track.TrackId,
                                        
                                         AlbumId = track.AlbumId,
                                         Artist = track.Artist,
                                         TracksHref = String.Format("/api/Track?TrackId={0}", track.TrackId)
                                     };

            if (tracks != null)
            {
                tracks = tracks.Where(g => g.TrackId == TrackId);
            }

            return Ok(tracks);
        }



        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var existingUser = from g in _context.Track
                               where g.TrackId == track.TrackId
                               select g;

            if (existingUser.Count<Track>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }


            _context.Track.Add(track);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrackExists(track.TrackId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTrack", new { id = track.TrackId }, track);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != track.TrackId)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(track.TrackId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Track track = _context.Track.Single(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Track.Remove(track);
            _context.SaveChanges();

            return Ok(track);
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Count(e => e.TrackId == id) > 0;
        }

    }
}