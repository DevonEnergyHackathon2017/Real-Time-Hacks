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
    //[RoutePrefix("api/rateUnitsOfMeasure")]
    public class RateUnitOfMeasuresController : ApiController
    {
        private FracVizDbContext db = new FracVizDbContext();

        // GET: api/RateUnitOfMeasures
        public IQueryable<RateUnitOfMeasure> GetRateUnitOfMeasures()
        {
            return db.RateUnitOfMeasures;
        }

        // GET: api/RateUnitOfMeasures/5
        [ResponseType(typeof(RateUnitOfMeasure))]
        public async Task<IHttpActionResult> GetRateUnitOfMeasure(int id)
        {
            RateUnitOfMeasure rateUnitOfMeasure = await db.RateUnitOfMeasures.FindAsync(id);
            if (rateUnitOfMeasure == null)
            {
                return NotFound();
            }

            return Ok(rateUnitOfMeasure);
        }

        // PUT: api/RateUnitOfMeasures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRateUnitOfMeasure(int id, RateUnitOfMeasure rateUnitOfMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rateUnitOfMeasure.Id)
            {
                return BadRequest();
            }

            db.Entry(rateUnitOfMeasure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateUnitOfMeasureExists(id))
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

        // POST: api/RateUnitOfMeasures
        [ResponseType(typeof(RateUnitOfMeasure))]
        public async Task<IHttpActionResult> PostRateUnitOfMeasure(RateUnitOfMeasure rateUnitOfMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RateUnitOfMeasures.Add(rateUnitOfMeasure);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rateUnitOfMeasure.Id }, rateUnitOfMeasure);
        }

        // DELETE: api/RateUnitOfMeasures/5
        [ResponseType(typeof(RateUnitOfMeasure))]
        public async Task<IHttpActionResult> DeleteRateUnitOfMeasure(int id)
        {
            RateUnitOfMeasure rateUnitOfMeasure = await db.RateUnitOfMeasures.FindAsync(id);
            if (rateUnitOfMeasure == null)
            {
                return NotFound();
            }

            db.RateUnitOfMeasures.Remove(rateUnitOfMeasure);
            await db.SaveChangesAsync();

            return Ok(rateUnitOfMeasure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RateUnitOfMeasureExists(int id)
        {
            return db.RateUnitOfMeasures.Count(e => e.Id == id) > 0;
        }
    }
}