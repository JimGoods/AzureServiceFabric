using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiService.Messages;

namespace WebApiService.Controllers
{
    public class AddressLookupInboundController : ApiController
    {
        [ResponseType(typeof(AddressLookupInboundResponse))]
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]AddressLookupInboundRequest request)
        {
            var response = new AddressLookupInboundResponse
            {
                Addresses = new List<string> { "Address 1", "Address 2" }
            };
            return Ok(response);
        }
    }
}
