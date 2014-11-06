using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StormCrow.Data;

namespace StormCrow.Web.Controllers
{
    public class OrganizationController : ApiController
    {
        private IUnitOfWork Uow { get; set; }

        public OrganizationController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET: api/Organization
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Organization/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Organization
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Organization/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Organization/5
        public void Delete(int id)
        {
        }
    }
}
