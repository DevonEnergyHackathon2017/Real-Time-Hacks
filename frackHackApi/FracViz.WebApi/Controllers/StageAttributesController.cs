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
    //[RoutePrefix("api/stageAttributes")]
    public class StageAttributesController : ApiController
    {
        private FracVizDbContext db = new FracVizDbContext();

        // GET: api/StageAttributes
        public IQueryable<StageAttribute> GetStageAttributes()
        {
            return db.StageAttributes;
        }

        // GET: api/StageAttributes/5
        [ResponseType(typeof(StageAttribute))]
        public async Task<IHttpActionResult> GetStageAttribute(int id)
        {
            StageAttribute stageAttribute = await db.StageAttributes.FindAsync(id);
            if (stageAttribute == null)
            {
                return NotFound();
            }

            return Ok(stageAttribute);
        }

        // PUT: api/StageAttributes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStageAttribute(int id, StageAttribute stageAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stageAttribute.Id)
            {
                return BadRequest();
            }

            db.Entry(stageAttribute).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StageAttributeExists(id))
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

        // POST: api/StageAttributes
        [ResponseType(typeof(StageAttribute))]
        public async Task<IHttpActionResult> PostStageAttribute(StageAttribute stageAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StageAttributes.Add(stageAttribute);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stageAttribute.Id }, stageAttribute);
        }

        // DELETE: api/StageAttributes/5
        [ResponseType(typeof(StageAttribute))]
        public async Task<IHttpActionResult> DeleteStageAttribute(int id)
        {
            StageAttribute stageAttribute = await db.StageAttributes.FindAsync(id);
            if (stageAttribute == null)
            {
                return NotFound();
            }

            db.StageAttributes.Remove(stageAttribute);
            await db.SaveChangesAsync();

            return Ok(stageAttribute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StageAttributeExists(int id)
        {
            return db.StageAttributes.Count(e => e.Id == id) > 0;
        }
    }
}