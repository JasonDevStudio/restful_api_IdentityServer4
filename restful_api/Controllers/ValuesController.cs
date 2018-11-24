using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace restful_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<IEnumerable<(string token, string expires_in, string token_type)>> Get(int id)
        {
            var args = new List<(string token, string expires_in, string token_type)>();

            for (int i = 0; i < id; i++)
            {
                args.Add((token: "eyJhbGciOiJSUzI1NiIsImtpZCI6IjQzYWFlMjk0NDIwODUyMmFlMTI2MjMyOWIzMWRkYjAwIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NDMwODU4OTksImV4cCI6MTU0MzA4OTQ5OSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgzIiwiYXVkIjpbImh0dHA6Ly9sb2NhbGhvc3Q6ODA4My9yZXNvdXJjZXMiLCJWYWx1ZXNBcGkiXSwiY2xpZW50X2lkIjoiYXBwX2xkcyIsInNjb3BlIjpbIlZhbHVlc0FwaSJdfQ.kydBkpekYGX3eLamtnoXPAMJcfeiHd1p69eUiRAO9rFmgid3SF-UtfKHMV1tpesepnD7F1jgjpTBC8940aw0HSnlnxvVQ__MzudT6XSsVJDMpGDPWz1ZaZQTABhFrjYjcIdl3jboOsVqbSsvG5g9YmGpix4vohZJFI-jhx4IWQi6ITEN2AI8GHZEgRxmcvL13dlShqStPSh9TpxUFmGdpJL5STUrtZE4R1FvX0HPdghKjW5xBCuNdYG_bigwCVfLTPM5sMhVcDf_IQFx0DXM5oS9PITbgGFm1hx1IG_uZe68mot5MB7fG2uD97FzOFidKW_fN2aiNKZhGwRZs7bfCQ", expires_in: $"{DateTime.Now:yyyy-MM-dd HH:mm:ss:ffff}", token_type: "Bearer"));
            }


            return args;
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
