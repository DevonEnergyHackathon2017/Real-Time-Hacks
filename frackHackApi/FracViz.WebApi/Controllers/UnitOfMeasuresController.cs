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
    //[RoutePrefix("api/unitsOfMeasure")]
    public class UnitOfMeasuresController : ApiController
    {
        private FracVizDbContext db = new FracVizDbContext();

        // GET: api/UnitOfMeasures
        public IQueryable<UnitOfMeasure> GetUnitOfMeasures()
        {
            return db.UnitOfMeasures;
        }

        // GET: api/UnitOfMeasures/5
        [ResponseType(typeof(UnitOfMeasure))]
        public async Task<IHttpActionResult> GetUnitOfMeasure(int id)
        {
            UnitOfMeasure unitOfMeasure = await db.UnitOfMeasures.FindAsync(id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return Ok(unitOfMeasure);
        }

        // PUT: api/UnitOfMeasures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnitOfMeasure(int id, UnitOfMeasure unitOfMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitOfMeasure.Id)
            {
                return BadRequest();
            }

            db.Entry(unitOfMeasure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitOfMeasureExists(id))
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

        // POST: api/UnitOfMeasures
        [ResponseType(typeof(UnitOfMeasure))]
        public async Task<IHttpActionResult> PostUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnitOfMeasures.Add(unitOfMeasure);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = unitOfMeasure.Id }, unitOfMeasure);
        }

        // DELETE: api/UnitOfMeasures/5
        [ResponseType(typeof(UnitOfMeasure))]
        public async Task<IHttpActionResult> DeleteUnitOfMeasure(int id)
        {
            UnitOfMeasure unitOfMeasure = await db.UnitOfMeasures.FindAsync(id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            db.UnitOfMeasures.Remove(unitOfMeasure);
            await db.SaveChangesAsync();

            return Ok(unitOfMeasure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitOfMeasureExists(int id)
        {
            return db.UnitOfMeasures.Count(e => e.Id == id) > 0;
        }
    }
}