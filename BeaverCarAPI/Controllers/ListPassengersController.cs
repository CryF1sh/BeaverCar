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
using BeaverCarAPI.Entities;
using BeaverCarAPI.Models;

namespace BeaverCarAPI.Controllers
{
    public class ListPassengersController : ApiController
    {
        private BeaverCarDBEntities db = new BeaverCarDBEntities();

        // GET: api/ListPassengers
        [ResponseType(typeof(List<ListPassengerModels>))]
        public IHttpActionResult GetListPassengers()
        {
            return Ok(db.ListPassengers.ToList().ConvertAll(l => new ListPassengerModels(l)));
        }

        // GET: api/ListPassengers/5
        [ResponseType(typeof(ListPassenger))]
        public async Task<IHttpActionResult> GetListPassenger(int id)
        {
            ListPassenger listPassenger = await db.ListPassengers.FindAsync(id);
            if (listPassenger == null)
            {
                return NotFound();
            }

            return Ok(listPassenger);
        }

        // PUT: api/ListPassengers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutListPassenger(int id, ListPassenger listPassenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listPassenger.id)
            {
                return BadRequest();
            }

            db.Entry(listPassenger).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListPassengerExists(id))
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

        // POST: api/ListPassengers
        [ResponseType(typeof(ListPassenger))]
        public async Task<IHttpActionResult> PostListPassenger(ListPassenger listPassenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListPassengers.Add(listPassenger);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = listPassenger.id }, listPassenger);
        }

        // DELETE: api/ListPassengers/5
        [ResponseType(typeof(ListPassenger))]
        public async Task<IHttpActionResult> DeleteListPassenger(int id)
        {
            ListPassenger listPassenger = await db.ListPassengers.FindAsync(id);
            if (listPassenger == null)
            {
                return NotFound();
            }

            db.ListPassengers.Remove(listPassenger);
            await db.SaveChangesAsync();

            return Ok(listPassenger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListPassengerExists(int id)
        {
            return db.ListPassengers.Count(e => e.id == id) > 0;
        }
    }
}