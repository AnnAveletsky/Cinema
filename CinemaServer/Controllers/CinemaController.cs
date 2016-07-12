using CinemaServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemaServer.Controllers
{
    [RoutePrefix("api/Cinema")]
    public class CinemaController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Cinema
        [HttpGet]
        public List<Cinema> Get(int page, int count)
        {
            return db.Сinemas.Skip((page - 1) * count).Take(count).ToList();
        }

        // GET: api/Cinema/5
        [HttpGet]
        public Task<Cinema> Get(int id)
        {
            return db.Сinemas.FindAsync(id);
        }

        // POST: api/Cinema
        [HttpPost]
        public bool Post([FromBody]Cinema cinema)
        {
            try
            {
                db.Сinemas.Add(cinema);
                db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // PUT: api/Cinema/5
        [HttpPut]
        public bool Put(int id, [FromBody]Cinema newCinema)
        {
            try
            {
                Cinema oldCinema = db.Сinemas.FindAsync(id).Result;
                oldCinema.Update(newCinema);
                db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // DELETE: api/Cinema/5
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                Cinema cinema = db.Сinemas.FindAsync(id).Result;
                db.Сinemas.Remove(cinema);
                db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
