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
using FracViz.WebApi.DataAccess;

namespace FracViz.WebApi.Controllers
{
    //[RoutePrefix("api/thresholds")]
    public class ThresholdsController : ApiController
    {
        private FracVizDbContext db = new FracVizDbContext();

        // GET: api/Thresholds
        public IQueryable<Threshold> GetThresholds()
        {
            return db.Thresholds;
        }

        // GET: api/Thresholds/5
        [ResponseType(typeof(Threshold))]
        public async Task<IHttpActionResult> GetThreshold(int id)
        {
            Threshold threshold = await db.Thresholds.FindAsync(id);
            if (threshold == null)
            {
                return NotFound();
            }

            return Ok(threshold);
        }

        // PUT: api/Thresholds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutThreshold(int id, Threshold threshold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != threshold.Id)
            {
                return BadRequest();
            }

            db.Entry(threshold).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThresholdExists(id))
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

        // POST: api/Thresholds
        [ResponseType(typeof(Threshold))]
        public async Task<IHttpActionResult> PostThreshold(Threshold threshold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Thresholds.Add(threshold);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThresholdExists(threshold.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = threshold.Id }, threshold);
        }

        // DELETE: api/Thresholds/5
        [ResponseType(typeof(Threshold))]
        public async Task<IHttpActionResult> DeleteThreshold(int id)
        {
            Threshold threshold = await db.Thresholds.FindAsync(id);
            if (threshold == null)
            {
                return NotFound();
            }

            db.Thresholds.Remove(threshold);
            await db.SaveChangesAsync();

            return Ok(threshold);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThresholdExists(int id)
        {
            return db.Thresholds.Count(e => e.Id == id) > 0;
        }
    }
}