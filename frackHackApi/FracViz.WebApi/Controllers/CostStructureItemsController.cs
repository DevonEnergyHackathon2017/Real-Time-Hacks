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
    //[RoutePrefix("api/costStructureItems")]
    public class CostStructureItemsController : ApiController
    {
        private FracVizDbContext db = new FracVizDbContext();

        // GET: api/CostStructureItems
        public IQueryable<CostStructureItem> GetCostStructureItems()
        {
            return db.CostStructureItems;
        }

        // GET: api/CostStructureItems/5
        [ResponseType(typeof(CostStructureItem))]
        public async Task<IHttpActionResult> GetCostStructureItem(int id)
        {
            CostStructureItem costStructureItem = await db.CostStructureItems.FindAsync(id);
            if (costStructureItem == null)
            {
                return NotFound();
            }

            return Ok(costStructureItem);
        }

        // PUT: api/CostStructureItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCostStructureItem(int id, CostStructureItem costStructureItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costStructureItem.Id)
            {
                return BadRequest();
            }

            db.Entry(costStructureItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostStructureItemExists(id))
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

        // POST: api/CostStructureItems
        [ResponseType(typeof(CostStructureItem))]
        public async Task<IHttpActionResult> PostCostStructureItem(CostStructureItem costStructureItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CostStructureItems.Add(costStructureItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = costStructureItem.Id }, costStructureItem);
        }

        // DELETE: api/CostStructureItems/5
        [ResponseType(typeof(CostStructureItem))]
        public async Task<IHttpActionResult> DeleteCostStructureItem(int id)
        {
            CostStructureItem costStructureItem = await db.CostStructureItems.FindAsync(id);
            if (costStructureItem == null)
            {
                return NotFound();
            }

            db.CostStructureItems.Remove(costStructureItem);
            await db.SaveChangesAsync();

            return Ok(costStructureItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CostStructureItemExists(int id)
        {
            return db.CostStructureItems.Count(e => e.Id == id) > 0;
        }
    }
}