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
    //[RoutePrefix("api/costStructures")]
    public class CostStructuresController : ApiController
    {
        private FracVizDbContext db = new FracVizDbContext();

        // GET: api/CostStructures
        public IQueryable<CostStructure> GetCostStructures()
        {
            return db.CostStructures;
        }

        // GET: api/CostStructures/5
        [ResponseType(typeof(CostStructure))]
        public async Task<IHttpActionResult> GetCostStructure(int id)
        {
            CostStructure costStructure = await db.CostStructures.FindAsync(id);
            if (costStructure == null)
            {
                return NotFound();
            }

            return Ok(costStructure);
        }

        // PUT: api/CostStructures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCostStructure(int id, CostStructure costStructure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costStructure.Id)
            {
                return BadRequest();
            }

            db.Entry(costStructure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostStructureExists(id))
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

        // POST: api/CostStructures
        [ResponseType(typeof(CostStructure))]
        public async Task<IHttpActionResult> PostCostStructure(CostStructure costStructure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CostStructures.Add(costStructure);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = costStructure.Id }, costStructure);
        }

        // DELETE: api/CostStructures/5
        [ResponseType(typeof(CostStructure))]
        public async Task<IHttpActionResult> DeleteCostStructure(int id)
        {
            CostStructure costStructure = await db.CostStructures.FindAsync(id);
            if (costStructure == null)
            {
                return NotFound();
            }

            db.CostStructures.Remove(costStructure);
            await db.SaveChangesAsync();

            return Ok(costStructure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CostStructureExists(int id)
        {
            return db.CostStructures.Count(e => e.Id == id) > 0;
        }
    }
}