using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace pegabicho.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("teste")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var v1 = Environment.UserDomainName;
            var v2 = Environment.UserName;
            var v3 = Request.Host.ToString();
            var v4 = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var v5 = Request.HttpContext.Connection.LocalIpAddress.ToString();
            var v6 = Request.HttpContext.Connection.RemotePort.ToString();

            var list = new List<string>(){ v1, v2, v3, v4, v5, v6 };

            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
