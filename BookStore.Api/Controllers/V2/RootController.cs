using System.Web.Http;

namespace BookStore.Api.Controllers.V2
{
    public class RootController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Book Store Inventory API V2");
        }
    }
}