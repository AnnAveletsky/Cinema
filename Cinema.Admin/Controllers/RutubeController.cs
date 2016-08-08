using Cinema.Models;
using Cinema.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace Cinema.Admin.Controllers
{
    public class RutubeController : ApiController
    {
        // GET: api/Rutube
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rutube/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rutube
        public async void Post([FromUri]GetRutubeTV getRutubeTV)
        {
                await Rutube.GetTV(getRutubeTV);
        }

        // PUT: api/Rutube/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rutube/5
        public void Delete(int id)
        {
        }
    }
}
