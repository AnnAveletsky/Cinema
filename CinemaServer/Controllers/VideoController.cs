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
    [RoutePrefix("api/Video")]
    public class VideoController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Video
        public IEnumerable<Video> Get(int page, int count)
        {
            return db.Videos.Skip((page - 1) * count).Take(count).ToList();
        }

        // GET: api/Video/5
        public Task<Video> Get(int id)
        {
            return db.Videos.FindAsync(id);
        }

        // POST: api/Video
        public HttpStatusCode Post([FromBody]Video video)
        {
            try
            {
                db.Videos.Add(video);
                db.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.Conflict;
            }
        }

        // PUT: api/Video/5
        public HttpStatusCode Put(int id, [FromBody]Video newVideo)
        {
            try
            {
                Video oldVideo = db.Videos.FindAsync(id).Result;
                oldVideo.Update(newVideo);
                db.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.Conflict;
            }
        }

        // DELETE: api/Video/5
        public HttpStatusCode Delete(int id)
        {
            try
            {
                Video video = db.Videos.FindAsync(id).Result;
                db.Videos.Remove(video);
                db.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.Conflict;
            }
        }
    }
}
